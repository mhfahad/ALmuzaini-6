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
using System.Diagnostics;

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

        public Task<ICollection<GetTTRateResult>> GetAllCurrencyAsync()
        {
            return _repo.GetAllCurrencyAsync();
        }

        public async Task<bool> GetCurrencySync()
        {
            var _httpClient = _httpClientFactory.CreateClient("GetTTRate");
            List<GetTTRateRequestDto> requestDto = new List<GetTTRateRequestDto>(); 
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
                //RequestIds.Remove(RequestIds.FirstOrDefault());
                 //currencyRequest = await _repo.GetLatestCurrencyRequestId();

                var RequestBody = new CurrencyRequest();
                

                if (currencyRequest != null)
                {
                    RequestBody = new CurrencyRequest
                    {
                        RequestId = currencyRequest.RequestId,
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
                var data = await Recall(RequestBody);
            }
            return true;
        }

        private async Task<Root> Recall(CurrencyRequest model)
        {
            var _httpClient = _httpClientFactory.CreateClient("GetTTRate");
            _httpClient.DefaultRequestHeaders.Add("RequestID", $"{model.RequestId++}");
            var newPostJson = JsonConvert.SerializeObject(model);
            var payload = new StringContent(newPostJson, Encoding.UTF8, Application.Json);
            var response = await _httpClient.PostAsync(_httpClient.BaseAddress, payload);
            if (response.IsSuccessStatusCode)
            {
                var responseResult = await response.Content.ReadAsStringAsync();
                var dRate = JsonConvert.DeserializeObject<Root>(responseResult);
                await _repo.AddRequestIdAsync(model);
                if (dRate!.responseHeader.responseCode == "R997")
                {
                    await Recall(model);
                }
                //dRate.GetTTRateResult.currencyCode = model.
                await _repo.AddGetTRetResult(dRate!.GetTTRateResult);
                return dRate;
            }
            return null;
        }

        public async Task<long> GetLatestCurrencyRequestId()
        {
            var data = await _repo.GetLatestCurrencyRequestId();
            return data.RequestId;
        }
        
    }
}
