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
        Task<string> GetCurrencySync();
        Task<ICollection<CurrencyRate>> GetAllCurrencyAsync();
    }
}
