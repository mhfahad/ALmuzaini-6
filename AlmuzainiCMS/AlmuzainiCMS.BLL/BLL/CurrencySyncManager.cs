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
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICurrencyRepository _repo;
        public CurrencySyncManager(IHttpClientFactory httpClientFactory, ICurrencyRepository repo)
        {
            _httpClientFactory = httpClientFactory;
            _repo = repo;
        }

        public async Task<bool> AddRequestIdAsync(CurrencyRequestCreateDto model)
        {
            var existingData = await _repo.GetRequestByRequestId(model.RequestId);
            if(existingData < 0)
            {
                var data = new CurrencyRequest
                {
                    RequestId = model.RequestId,
                    SessionId = model.SessionId,
                    CreatedOn = DateTime.UtcNow,
                };
                return await _repo.AddRequestIdAsync(data);
            }
            return false;
        }

        public Task<ICollection<CurrencyRate>> GetAllCurrencyAsync()
        {
            return _repo.GetAllCurrencyAsync();
        }

        public async Task<bool> GetCurrencySync()
        {
            var _httpClient = _httpClientFactory.CreateClient("GetTTRate");
            List<GetTTRateRequestDto> requestDto = new List<GetTTRateRequestDto>();
            List<CurrencyRate> currencyRates = new List<CurrencyRate>();   
            List<CurrencyRequest> RequestIds = new List<CurrencyRequest>();

            var currencyCodes = await _repo.GetCurrencyCodes();

            foreach (var currencyCode in currencyCodes)
            {
                GetTTRateRequestDto data = new GetTTRateRequestDto
                {
                    CurrenyCode = currencyCode.CurrencyCodeName,
                    Amount = "1",
                    CalcType = "FC",
                    Entity = "110"
                };
                requestDto.Add(data);
            }

            var currencyRequest = await _repo.GetLatestCurrencyRequestId();

            foreach (var item in requestDto)
            {
                var RequestBody = new CurrencyRequest();

                if (currencyRequest != null)
                {
                    RequestBody = new CurrencyRequest
                    {
                        RequestId = currencyRequest.RequestId++,
                        CreatedOn = DateTime.Now,
                        SessionId = currencyRequest.SessionId,
                    };
                    RequestIds.Add(RequestBody);
                }
                else
                {
                    RequestBody = new CurrencyRequest
                    {
                        RequestId = 8764130000000004,
                        CreatedOn = DateTime.Now,
                        SessionId = "",
                    };
                    RequestIds.Add(RequestBody);
                }

                _httpClient.DefaultRequestHeaders.Add("RequestID", $"{RequestBody.RequestId}");

                var newPostJson = JsonConvert.SerializeObject(item);
                var payload = new StringContent(newPostJson, Encoding.UTF8, Application.Json);
                //var buffer = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(item));
                //var byteContent = new ByteArrayContent(buffer);
                var response = await _httpClient.PostAsync(_httpClient.BaseAddress, payload);
                if (response.IsSuccessStatusCode)
                {
                    var responseResult = await response.Content.ReadAsStringAsync();
                    var dRate = JsonConvert.DeserializeObject<CurrencyRate>(responseResult);
                    currencyRates.Add(dRate);
                    await _repo.AddRequestBodyAsync(RequestIds);
                    var result = await _repo.AddCurrency(currencyRates);
                    if (result) return result;
                    return result;
                }
                return false;
            }
            return false;
        }

        public async Task<long> GetLatestCurrencyRequestId()
        {
            var data = await _repo.GetLatestCurrencyRequestId();
            return data.RequestId;
        }
        
    }
}
