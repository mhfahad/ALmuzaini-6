using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.Interface
{
    public interface ICompanyHistoryManager
    {
        Task<bool> UpdateCompanyHistorySection(CompanyHistory companyHistory);
        Task<bool> UpdateExpertise(CompanyHistory companyHistory);
        Task<bool> UpdateWorkforce(CompanyHistory companyHistory);   
        Task<bool> UpdateTechnology(CompanyHistory companyHistory);   
        Task<bool> UpdateCompanyHistoryImagePath(CompanyHistory companyHistory);     
        Task<bool> UpdateCompanyProfileBannerImagePath(CompanyHistory companyHistory);        
       
        Task<CompanyHistory> GetCompanyHistorySection();
    }
}
