using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.Interface
{
    public interface IRemittancesManager
    {
        Task<Remittences> GetRemittances();
        Task<bool> UpdateBannerImagePath(Remittences remittances);
        Task<bool> UpdateFirstSectionLeft(Remittences remittances);
        Task<bool> UpdateFirstSectionRight(Remittences remittancesmodel);
        Task<bool> UpdateFourthSection(Remittences remittancesmodel);
        Task<bool> UpdateInnerSection(Remittences remittances);
        Task<bool> UpdateRemitNow(Remittences remittancesmodel);
        
        Task<bool> UpdateSecondSection(Remittences remittancesmodel);
        Task<bool> UpdateSliderImageFile(Remittences remittances);
        Task<bool> UpdateThirdSection(Remittences remittancesmodel);
        Task<bool> UpdateVideoLink(Remittences remittances);
    }
}
