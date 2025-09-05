namespace OrderManagement.Application.Dtos
{
    public class OrderWithDetailDto
    {
        public int EmpId { get; set; }
        public int ShipperId { get; set; }
        public string? ShipName { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipCity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public decimal Freight { get; set; }
        public string? ShipCountry { get; set; }
        public List<OrderDetailDto>? OrderDetails { get; set; }
    }
}
