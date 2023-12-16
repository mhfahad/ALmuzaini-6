using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.Interface
{
    public interface IKoiskRepository
    {
        //Top Banner

        KoiskBanner GetKoiskTopBanner();
        Task<bool> UpdateKoiskBannerImagePath(KoiskBanner koiskBanner);

        //Koisk Details

        Task<bool> AddKoiskDetail(KoiskDetail koiskDetail);
        List<KoiskDetail> GetKoiskDetail();
    }
}
