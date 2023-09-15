namespace Application.Cars.Queries
{
    public class CongestionTaxResult
    {
        public Guid CarId { get; set; }
        public string CarPlate { get; set; }
        public decimal TotalTaxAmount { get; set; }
    }
}
