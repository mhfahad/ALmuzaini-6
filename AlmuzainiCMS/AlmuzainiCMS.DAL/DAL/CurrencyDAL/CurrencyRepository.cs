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
        public async Task<bool> AddCurrency(ICollection<GetTTRateResult> model)
        {
            var result = await _db.GetTrateResults.ToListAsync() ?? Enumerable.Empty<GetTTRateResult>().ToList();
            if (result.Count is not 0)
            {
                _db.RemoveRange(result);
            }

            await _db.AddRangeAsync(model);
            return await _db.SaveChangesAsync() > 0;  
        }

        public async Task<bool> AddRequestBodyAsync(ICollection<CurrencyRequest> requests)
        {
            await _db.AddRangeAsync(requests);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddGetTRetResult(GetTTRateResult requests)
        {
            await _db.AddAsync(requests);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddRequestIdAsync(CurrencyRequest model)
        {
            await _db.AddAsync(model);
            return await _db.SaveChangesAsync()>0;
        }

        public async Task<ICollection<GetTTRateResult>> GetAllCurrencyAsync()
        {
            return await _db.GetTrateResults.ToListAsync() ?? Enumerable.Empty<GetTTRateResult>().ToList();
        }

        public async Task<ICollection<CurrencyCode>> GetCurrencyCodes()
        {
            return await _db.CurrenyCodes.ToListAsync() ?? Enumerable.Empty<CurrencyCode>().ToList();
        }

        public async Task<ICollection<CurrencyRequest>> GetCurrencyRequestIdsAsync()
        {
            return await _db.CurrencyRequests.ToListAsync() ?? Enumerable.Empty<CurrencyRequest>().ToList();
        }

        public async Task<CurrencyRequest> GetLatestCurrencyRequestId()
        {
            return await _db.CurrencyRequests.OrderByDescending(c=>c.RequestId).FirstOrDefaultAsync();
        }

        public async Task<long> GetRequestByRequestId(long id)
        {
            return await _db.CurrencyRequests.Where(c=>c.Equals(id)).Select(c=>c.RequestId).FirstAsync();
        }

        public async Task<bool> RemoveAllCurrency(ICollection<GetTTRateResult> data)
        {
            //var data = await _db.GetTrateResults.ToListAsync();
            _db.RemoveRange(data);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}
