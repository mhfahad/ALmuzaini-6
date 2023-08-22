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
        Task<CompanyHistory> GetCompanyHistorySection();
    }
}
