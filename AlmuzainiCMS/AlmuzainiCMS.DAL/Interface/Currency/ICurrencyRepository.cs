using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.Interface.Currency
{
    public interface ICurrencyRepository
    {
        Task<bool> AddCurrency(ICollection<CurrencyRate> model);
        Task<bool> AddRequestIdsAsync(ICollection<long> requestIds);
        Task<ICollection<CurrencyRate>> GetAllCurrencyAsync();
        Task<ICollection<CurrencyCode>> GetCurrencyCodes();
    }
}
