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

        public async Task<string> GetCurrencySync()
        {
            List<GetTTRateRequestDto> requestDto = new List<GetTTRateRequestDto>();
            List<CurrencyRate> currencyRates = new List<CurrencyRate>();

            ICollection<CurrencyCode> currencyCodes = await _repo.GetCurrencyCodes();

            foreach (CurrencyCode currencyCode in currencyCodes)
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
            string URL = $"";

            foreach (var item in requestDto)
            {
                var buffer = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(item));
                var byteContent = new ByteArrayContent(buffer);
                var response = await _httpClientFactory.PostAsync(URL, byteContent);
                var responseResult = await response.Content.ReadAsStringAsync();
                currencyRates.Add(JsonConvert.DeserializeObject<CurrencyRate>(responseResult));
            }

            var result = await _repo.AddCurrency(currencyRates);
            if (result) return "Ok";
            return "False";
        
        }
    }
}
