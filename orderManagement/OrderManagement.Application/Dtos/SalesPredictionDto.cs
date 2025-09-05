namespace OrderManagement.Application.Dtos
{
    public class SalesPredictionDto
    {
        public int? CustId { get; set; }
        public string? CustomerName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}
