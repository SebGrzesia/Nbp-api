namespace NBP_api.Models
{
    public class ExchangeRatesTable
    {
        public List<Rate> Rates { get; set; }
    }
    public class Rate
    {
        public string Currency { get; set; }
        public decimal Mid { get; set; }
    }
}
