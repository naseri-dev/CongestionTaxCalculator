namespace Domain.Entities.MaximumTaxes.Dtos
{
    public class MaximumTaxDto
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public Guid YearId { get; set; }
        public decimal Amount { get; set; }
    }
}
