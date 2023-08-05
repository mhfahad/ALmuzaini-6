using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.DAL.Interface.Currency;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace AlmuzainiCMS.BLL.BLL
{
    public class CurrencySyncManager : ICurrencySyncManager
    {
        private readonly HttpClient _httpClientFactory;
        private readonly ICurrencyRepository _repo;
        public CurrencySyncManager(IHttpClientFactory httpClientFactory, ICurrencyRepository repo)
        {
            _httpClientFactory = httpClientFactory.CreateClient("GetTTRate");
            _repo = repo;
        }

        public Task<ICollection<CurrencyRate>> GetAllCurrencyAsync()
        {
            return _repo.GetAllCurrencyAsync();
        }

        public async Task<bool> GetCurrencySync()
        {
            List<GetTTRateRequestDto> requestDto = new List<GetTTRateRequestDto>();
            List<CurrencyRate> currencyRates = new List<CurrencyRate>();   
            List<long> RequestIds = new List<long>();

            var currencyCodes = await _repo.GetCurrencyCodes();

            foreach (var currencyCode in currencyCodes)
            {
                GetTTRateRequestDto data = new GetTTRateRequestDto
                {
                    Amount = 1,
                    CurrenyCode = currencyCode.CurrencyCodeName,
                    CalcType = "FC",
                    Entity = "110"
                };

                requestDto.Add(data);
            }

            //var requestId = $"123XYA-{Guid.NewGuid()}-{DateTime.UtcNow.Ticks}";
            var requestId = 8764130000000002;

            foreach (var item in requestDto)
            { 
                _httpClientFactory.DefaultRequestHeaders.Add("RequestID", $"{requestId}");
                var buffer = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(item));
                //var todoItemJson = new StringContent(JsonSerializer.Serialize(item),Encoding.UTF8,Application.Json);
                var byteContent = new ByteArrayContent(buffer);
                var response = await _httpClientFactory.PostAsync(_httpClientFactory.BaseAddress, byteContent);
                if (response.IsSuccessStatusCode)
                {
                    var responseResult = await response.Content.ReadAsStringAsync();
                    currencyRates.Add(JsonConvert.DeserializeObject<CurrencyRate>(responseResult));
                }
                RequestIds.Add(requestId);
                requestId++;
            }

            await _repo.AddRequestIdsAsync(RequestIds);
            var result = await _repo.AddCurrency(currencyRates);
            if (result) return result;
            return result;
        }
    }
}
