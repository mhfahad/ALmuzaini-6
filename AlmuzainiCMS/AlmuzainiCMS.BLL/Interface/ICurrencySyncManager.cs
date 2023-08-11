using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.Interface
{
    public interface ICurrencySyncManager
    {
        Task<bool> GetCurrencySync();
        Task<ICollection<GetTTRateResult>> GetAllCurrencyAsync();
        Task<long> GetLatestCurrencyRequestId();
        Task<bool> AddRequestIdAsync(CurrencyRequestCreateDto model);
    }
}
