namespace Domain.Entities.Currencies.Dtos
{
    public class CurrencyDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; } 
        public string Symbol { get; set; } 
    }
}
