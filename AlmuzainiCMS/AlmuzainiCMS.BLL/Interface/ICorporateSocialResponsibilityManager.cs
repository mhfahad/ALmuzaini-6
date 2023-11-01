using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.Interface
{
    public interface ICorporateSocialResponsibilityManager  
    {
        Task<bool> UpdateCorporateSocialResponsibilityImage(CorporateSocialResponsibility corporateSocialResponsibility); 
        Task<bool> UpdateCorporateSocialResponsibilitySection(CorporateSocialResponsibility corporateSocialResponsibility);
        Task<CorporateSocialResponsibility> GetCorporateSocialResponsibility();    
    }
}
