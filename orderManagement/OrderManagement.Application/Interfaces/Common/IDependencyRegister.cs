using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace OrderManagement.Application.Interfaces.Common
{
    public interface IDependencyRegister
    {
        void RegisterDependencies(IConfiguration configuration, IServiceCollection services);
    }
}
