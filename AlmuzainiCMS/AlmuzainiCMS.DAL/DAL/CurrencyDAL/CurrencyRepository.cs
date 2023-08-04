using AlmuzainiCMS.DAL.Interface.Currency;
using AlmuzainiCMS.DataBaseContext.DataBaseContext;
using AlmuzainiCMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.DAL.CurrencyDAL
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly ProjectDbContext _db;
        public CurrencyRepository(ProjectDbContext db)
        {
            _db = db;
        }
        public async Task<bool> AddCurrency(ICollection<CurrencyRate> model)
        {
            var result = await _db.CurrencyRates.ToListAsync();
            if (result.Count is not 0)
            {
                _db.RemoveRange(result);
            }

            await _db.AddRangeAsync(model);
            return await _db.SaveChangesAsync() > 0;  
        }

        public async Task<ICollection<CurrencyRate>> GetAllCurrencyAsync()
        {
            return await _db.CurrencyRates.ToListAsync();
        }

        public async Task<ICollection<CurrencyCode>> GetCurrencyCodes()
        {
            return await _db.CurrenyCodes.ToListAsync();
        }
    }
}
