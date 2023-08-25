using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.Interface
{
    public interface ICompanyHistoryRepository  
    {
        Task<bool> UpdateCompanyHistorySection(CompanyHistory companyHistory);
        Task<bool> UpdateExpertise(CompanyHistory companyHistory);
        Task<bool> UpdateWorkforce(CompanyHistory companyHistory);   
        Task<bool> UpdateTechnology(CompanyHistory companyHistory);   
        Task<bool> UpdateCompanyHistoryImagePath(CompanyHistory companyHistory);   
        Task<bool> UpdateCompanyProfileBannerImagePath(CompanyHistory companyHistory);   
        Task<bool> UpdateChairmanInfo(ChairmanMessage chairmanMessage);  
        Task<bool> UpdateChairmanMessage(ChairmanMessage chairmanMessage);    
        Task<ChairmanMessage> GetChairmanMessage();  
        
        Task<CompanyHistory> GetCompanyHistorySection();
    }
}
