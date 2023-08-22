using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.DAL.DAL;
using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.BLL
{
    public class CompanyHistoryManager : ICompanyHistoryManager
    {
        private readonly ICompanyHistoryRepository _repository;

        public CompanyHistoryManager(ICompanyHistoryRepository repository)
        {
            this._repository = repository;     
        }

        public async Task<CompanyHistory> GetCompanyHistorySection()
        {
            CompanyHistory companyHistory = new CompanyHistory();

            companyHistory = await _repository.GetCompanyHistorySection();
            return await Task.FromResult(companyHistory); 
        }

        public async Task<bool> UpdateCompanyHistorySection(CompanyHistory companyHistory)
        {
            try
            {
                bool result = await _repository.UpdateCompanyHistorySection(companyHistory);   

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                //throw new Exception("Add News Failed");
                return await Task.FromResult(false);

            }
        }
    }
}
