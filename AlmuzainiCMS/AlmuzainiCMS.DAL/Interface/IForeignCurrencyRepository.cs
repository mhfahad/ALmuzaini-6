using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.Interface
{
    public interface IForeignCurrencyRepository
    {
        Task<Corporate> GetCorporate();
        Task<ForeignCurrency> GetForeignCurrency();
        Task<ICollection<RequiredDocument>> GetRequiredDocuments();
        Task<bool> UpdateRequiredDociuments(RequiredDocument requiredDocument);
        Task<bool> DeleteRequiredDocuments(RequiredDocument requiredDocument);
        Task<RequiredDocument> GetRequiredDocumentsBySerialNo(int serialNo);
        
        Task<bool> UpdateBranchImageFile(ForeignCurrency foreignCurrency);
        Task<bool> UpdateCurrencyBannerImagePath(ForeignCurrency foreignCurrency);
        Task<bool> UpdateFCDeliveryImageFile(ForeignCurrency foreignCurrency);
        Task<bool> UpdateForeignCurrencySection(ForeignCurrency foreignCurrency);
        Task<bool> UpdateQRCodeImageFile(ForeignCurrency foreignCurrency);
        Task<bool> UpdateSliderImageFile(ForeignCurrency foreignCurrency);
        Task<bool> UpdateCorporateBanner(Corporate corporate);
        Task<bool> UpdateCorporateSection(Corporate model);
        Task<bool> UpdateCorporateSliderImageFile(Corporate corporate);
    }
}
