using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.Interface.Currency
{
    public interface ICurrencyRepository
    {
        Task<bool> AddCurrency(ICollection<GetTTRateResult> model);
        Task<bool> AddRequestBodyAsync(ICollection<CurrencyRequest> requestIds);
        Task<ICollection<GetTTRateResult>> GetAllCurrencyAsync();
        Task<ICollection<CurrencyCode>> GetCurrencyCodes();
        Task<ICollection<CurrencyRequest>> GetCurrencyRequestIdsAsync();
        Task<CurrencyRequest> GetLatestCurrencyRequestId();
        Task<bool> AddRequestIdAsync(CurrencyRequest model);
        Task<long> GetRequestByRequestId(long id);
        Task<bool> AddGetTRetResult(GetTTRateResult requests);
        Task<bool> RemoveAllCurrency(ICollection<GetTTRateResult> data);
        Task<bool> AddCurrencycodeAsync(CurrencyCode model);
    }
}
