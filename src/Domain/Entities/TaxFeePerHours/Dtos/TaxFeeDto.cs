namespace Domain.Entities.TaxFeePerHours.Dtos
{
    public class TaxFeeDto
    {
        public DateTime Date { get; set; }
        public decimal TaxAmount { get; set; }
        public long Ticks { get; set; }
    }
}
