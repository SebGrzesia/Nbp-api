namespace NBP_api.Models
{
    public class MinAndMaxExchangeRateResponse
    {
        public List<ExchangeRateResponse> Rates { get; set; }
    }
    public class ExchangeRateResponse 
    {
        public decimal Mid { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}