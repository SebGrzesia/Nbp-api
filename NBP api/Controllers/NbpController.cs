using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBP_api.Models;
using System.Globalization;

namespace NBP_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NbpController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public NbpController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [HttpGet("getExchangeRate")]
        public async Task<IEnumerable<ExchangeRatesTable>> GetExchangeRates(DateTime date)
        {
            var response = await _httpClient.GetAsync($"http://api.nbp.pl/api/exchangerates/tables/A/{date.Year}-{date.Month.ToString("00")}-{date.Day.ToString("00")}/");
            var exchangeRate = await response.Content.ReadFromJsonAsync<IEnumerable<ExchangeRatesTable>>(new System.Text.Json.JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return exchangeRate;
        }
        [HttpGet("minmax")]
        public async Task<IActionResult> GetMinAndMaxExchangeRateForGivenCurrency(string currencyCode, int daysBack)
        {
            if(daysBack > 255)
            {
                return BadRequest("DaysBack was above 255");
            }
            var response = await _httpClient.GetAsync($"http://api.nbp.pl/api/exchangerates/rates/a/{currencyCode}/last/{daysBack}/");
            var exchangeRates = await response.Content.ReadFromJsonAsync<MinAndMaxExchangeRateResponse>(new System.Text.Json.JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            decimal minValue = exchangeRates.Rates.Min(r => r.Mid);
            decimal maxValue = exchangeRates.Rates.Max(q => q.Mid);

            return Ok(new MinMaxEndpointResponse()
            {
                MaxValue = maxValue,
                MinValue = minValue
            });
        }
        [HttpGet("bid")]
        public async Task<IActionResult> GetBiggestBidAskDifference(string currencyCode, int daysBack)
        {
            if(daysBack > 255)
            {
                return BadRequest("DaysBack was above 255");
            }
            var response = await _httpClient.GetAsync($"https://api.nbp.pl/api/exchangerates/rates/c/{currencyCode}/last/{daysBack}/");
            var exchangeRates = await response.Content.ReadFromJsonAsync<BidAskResponse>(new System.Text.Json.JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            var difference = exchangeRates.Rates.Select(m => m.Ask - m.Bid).Max();
            return Ok(difference);
        }
    }
} 
