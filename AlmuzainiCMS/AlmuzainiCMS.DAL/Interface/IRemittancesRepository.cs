using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.Interface
{
    public interface IRemittancesRepository
    {
        Task<Remittences> GetRemittances();        
        Task<bool> UpdateBannerImagePath(Remittences remittances);
        Task<bool> UpdateFirstSectionLeft(Remittences remittances);
        Task<bool> UpdateFirstSectionRight(Remittences remittancesmodel);
        Task<bool> UpdateFourthSection(Remittences remittancesmodel);
        Task<bool> UpdateRemitNow(Remittences remittancesmodel);
        Task<bool> UpdateInnerSection(Remittences remittances);
        Task<bool> UpdateSecondSection(Remittences remittancesmodel);
        Task<bool> UpdateSliderImageFile(Remittences remittances);
        Task<bool> UpdateThirdSection(Remittences remittancesmodel);
        Task<bool> UpdateVideoLink(Remittences remittances);
    }
}
