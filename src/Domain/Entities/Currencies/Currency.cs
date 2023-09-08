using Domain.SeedWork;

namespace Domain.Entities.Currencies
{
    public class Currency : BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; } // AUD,USD,SEK,...
        public string Symbol { get; set; } // $,₡,£,€,...
    }
}
