using AlmuzainiCMS.DataBaseContext.DataBaseContext;
using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.Interface
{
    public interface ICorporateSocialResponsibilityRepository
    {
        Task<bool> UpdateCorporateSocialResponsibilityImage(CorporateSocialResponsibility corporateSocialResponsibility);
        Task<bool> UpdateCorporateSocialResponsibilitySection(CorporateSocialResponsibility corporateSocialResponsibility);
        Task<CorporateSocialResponsibility> GetCorporateSocialResponsibility();


        //Top Banner

        CorporateSocialRespBanner GetCorporateSocialRespBanner();
        Task<bool> UpdateCorporateSocialRespBanner(CorporateSocialRespBanner corporateSocialRespBanner);

    }
}
