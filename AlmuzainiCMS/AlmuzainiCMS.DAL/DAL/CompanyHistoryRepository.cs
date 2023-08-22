using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.DataBaseContext.DataBaseContext;
using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.DAL
{
    public class CompanyHistoryRepository : ICompanyHistoryRepository
    {
        private readonly ProjectDbContext _context;

        public CompanyHistoryRepository(ProjectDbContext context)   
        {
            _context = context;
        }

        public Task<CompanyHistory> GetCompanyHistorySection()
        {
            CompanyHistory companyHistory = _context.CompanyHistory.First();    
            return Task.FromResult(companyHistory);
        }

        public async Task<bool> UpdateCompanyHistorySection(CompanyHistory companyHistory)
        {
            var count = _context.CompanyHistory?.Count();

            if (count > 0)
            {
                var companyHistoryToUpdate = _context.CompanyHistory?.FirstOrDefault();

                
                companyHistoryToUpdate.FirstSection = companyHistory.FirstSection;
                companyHistoryToUpdate.SecondSection = companyHistory.SecondSection;
                companyHistoryToUpdate.ThirdSection = companyHistory.ThirdSection;
                companyHistoryToUpdate.FourthSection = companyHistory.FourthSection;

                _context.Entry(companyHistoryToUpdate).Property(i => i.FirstSection).IsModified = true;
                _context.Entry(companyHistoryToUpdate).Property(i => i.SecondSection).IsModified = true;
                _context.Entry(companyHistoryToUpdate).Property(i => i.ThirdSection).IsModified = true;
                _context.Entry(companyHistoryToUpdate).Property(i => i.FourthSection).IsModified = true;
                return await _context.SaveChangesAsync() > 0;

            }
            else
            {
                _context.CompanyHistory?.Add(companyHistory);
                return await _context.SaveChangesAsync() > 0;
            }

           
        }
    }
}
