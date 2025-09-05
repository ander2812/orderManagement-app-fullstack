using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OrderManagement.Application.Auth;
using OrderManagement.Application.Interfaces.Common;
using OrderManagement.Application.Interfaces.Context;
using OrderManagement.Application.Interfaces.Repositories;
using OrderManagement.Application.Interfaces.Services;
using OrderManagement.Application.Mappings;
using OrderManagement.Application.Services;
using OrderManagement.Infrastructure.Data;
using OrderManagement.Infrastructure.DependencyInjection;
using OrderManagement.Infrastructure.Repositories;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

IDependencyRegister dependencyRegister = new DependencyRegister();
dependencyRegister.RegisterDependencies(builder.Configuration, builder.Services);

builder.Services.AddAutoMapper(typeof(CustomerProfile).Assembly);
builder.Services.AddAutoMapper(typeof(OrderProfile).Assembly);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddScoped<ICustomerService, CustomerService>()
    .AddScoped<IOrderService, OrderService>()
    .AddScoped<IShipperService, ShipperService>()
    .AddScoped<IProductService, ProductService>()
    .AddScoped<IEmployeeService, EmployeeService>()
    .AddScoped<IOrderDetailService, OrderDetailService>()
    .AddScoped<ICustomerOrderService, CustomerOrderService>();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
    {
        var cfg = builder.Configuration.GetSection("Jwt");
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = cfg["Issuer"],
            ValidAudience = cfg["Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(cfg["Key"]!))
        };

        o.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = ctx =>
            {
                Console.WriteLine($"[JWT FAIL] {ctx.Exception.GetType().Name}: {ctx.Exception.Message}");
                return Task.CompletedTask;
            },
            OnChallenge = ctx =>
            {
                ctx.ErrorDescription ??= ctx.AuthenticateFailure?.Message;
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserContext, HttpUserContext>();
builder.Services.AddScoped<IPasswordService, BcryptPasswordService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new() { Title = "API", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new()
    {
        Description = "JWT Authorization header usando el esquema Bearer. Ej: 'Bearer {token}'",
        Name = "Authorization",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });
    opt.AddSecurityRequirement(new()
    {
        {
            new() { Reference = new() { Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme, Id = "Bearer" } },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:7200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("AllowAngularApp");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularApp");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "¡API corriendo correctamente!");

app.Run();