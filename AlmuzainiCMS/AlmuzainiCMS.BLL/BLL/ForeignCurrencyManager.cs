using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.BLL
{
    public class ForeignCurrencyManager : IForeignCurrencyManager
    {
        private IForeignCurrencyRepository _foreignCurrencyRepository;
        public ForeignCurrencyManager(IForeignCurrencyRepository foreignCurrencyRepository)
        {
            _foreignCurrencyRepository = foreignCurrencyRepository; 
        }

        public async Task<bool> DeleteRequiredDocuments(RequiredDocument requiredDocument)
        {
            bool result = await _foreignCurrencyRepository.DeleteRequiredDocuments(requiredDocument);
            return await Task.FromResult(result);
        }

        public async Task<Corporate> GetCorporate()
        {
            Corporate corporate = new Corporate();

            corporate = await _foreignCurrencyRepository.GetCorporate();
            return await Task.FromResult(corporate);
        }

        public async Task<ForeignCurrency> GetForeignCurrency()
        {
            ForeignCurrency foreignCurrency = new ForeignCurrency();

            foreignCurrency = await _foreignCurrencyRepository.GetForeignCurrency();
            return await Task.FromResult(foreignCurrency);
        }

        public async Task<ICollection<RequiredDocument>> GetRequiredDocuments()
        {
            try
            {
                ICollection<RequiredDocument> requiredDocuments = new List<RequiredDocument>();
                requiredDocuments = await _foreignCurrencyRepository.GetRequiredDocuments();
                return await Task.FromResult(requiredDocuments);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new List<RequiredDocument>());
            }
        }

        public async Task<RequiredDocument> GetRequiredDocumentsBySerialNo(int serialNo)
        {
            RequiredDocument requiredDocument = await _foreignCurrencyRepository.GetRequiredDocumentsBySerialNo(serialNo);
            return await Task.FromResult(requiredDocument);
        }

        public async Task<bool> UpdateBranchImageFile(ForeignCurrency foreignCurrency)
        {
            try
            {
                bool result = await _foreignCurrencyRepository.UpdateBranchImageFile(foreignCurrency);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateCorporateBanner(Corporate corporate)
        {
            try
            {
                bool result = await _foreignCurrencyRepository.UpdateCorporateBanner(corporate);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateCorporateSection(Corporate model)  
        {
            try
            {
                bool result = await _foreignCurrencyRepository.UpdateCorporateSection(model);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateCorporateSliderImageFile(Corporate corporate)
        {
            try
            {
                bool result = await _foreignCurrencyRepository.UpdateCorporateSliderImageFile(corporate);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateCurrencyBannerImagePath(ForeignCurrency foreignCurrency)
        {
            try
            {
                bool result = await _foreignCurrencyRepository.UpdateCurrencyBannerImagePath(foreignCurrency);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
            //return  await Task.FromResult(true);
        }

        public async Task<bool> UpdateFCDeliveryImageFile(ForeignCurrency foreignCurrency)
        {
            try
            {
                bool result = await _foreignCurrencyRepository.UpdateFCDeliveryImageFile(foreignCurrency);    
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateForeignCurrencySection(ForeignCurrency foreignCurrency)
        {
            try
            {
                bool result = await _foreignCurrencyRepository.UpdateForeignCurrencySection(foreignCurrency);    
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateQRCodeImageFile(ForeignCurrency foreignCurrency)
        {
            try
            {
                bool result = await _foreignCurrencyRepository.UpdateQRCodeImageFile(foreignCurrency);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateRequiredDociuments(RequiredDocument requiredDocument)
        {
            try
            {
                bool result = await _foreignCurrencyRepository.UpdateRequiredDociuments(requiredDocument);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateSliderImageFile(ForeignCurrency foreignCurrency)
        {
            try
            {
                bool result = await _foreignCurrencyRepository.UpdateSliderImageFile(foreignCurrency);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
