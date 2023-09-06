using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.DataBaseContext.DataBaseContext;
using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models.RequestDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.DAL
{
    public class ForeignCurrencyRepository : IForeignCurrencyRepository
    {
        private readonly ProjectDbContext _context;
        public ForeignCurrencyRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public  Task<Corporate> GetCorporate()
        {
            Corporate corporate = _context.Corporate.FirstOrDefault();
            return  Task.FromResult(corporate);  
        }

        public Task<ForeignCurrency> GetForeignCurrency()
        {
            ForeignCurrency foreignCurrency = _context.ForeignCurrency.FirstOrDefault();
            return Task.FromResult(foreignCurrency);   
        }
        public async Task<bool> UpdateRequiredDociuments(RequiredDocument requiredDocument)  
        {
            int count = _context.RequiredDocuments.Count();
            requiredDocument.SerialNo = count + 1;


            _context.RequiredDocuments.AddRange(requiredDocument);
            return await _context.SaveChangesAsync() > 0;


        }

        public async Task<bool> DeleteRequiredDocuments(RequiredDocument requiredDocument)
        {
            var itemToDelete = _context.RequiredDocuments.Find(requiredDocument.Id);
            if (itemToDelete != null)
            {
                _context.RequiredDocuments.Remove(itemToDelete);
                return await _context.SaveChangesAsync() > 0;
            }

            return await Task.FromResult(false);



        }




        public Task<RequiredDocument> GetRequiredDocumentsBySerialNo(int serialNo)
        {
            RequiredDocument requiredDocuments = new RequiredDocument();
            if (_context.RequiredDocuments.Count() > 0)
            {
                requiredDocuments = _context.RequiredDocuments.Where(a => a.SerialNo == serialNo).FirstOrDefault();
            }

            return Task.FromResult(requiredDocuments);   
        }
        public Task<ICollection<RequiredDocument>> GetRequiredDocuments()
        {
            ICollection<RequiredDocument> requiredDocuments = _context.RequiredDocuments.OrderBy(a => a.SerialNo).ToList();
            return Task.FromResult(requiredDocuments);   
        }

        public async Task<bool> UpdateBranchImageFile(ForeignCurrency foreignCurrency)
        {
            var count = _context.ForeignCurrency?.Count();
            if (count > 0)
            {
                var foreignCurrencyToUpdate = _context.ForeignCurrency?.First();

                foreignCurrencyToUpdate.BranchImagePath = foreignCurrency.BranchImagePath;

                _context.Entry(foreignCurrencyToUpdate).Property(i => i.BranchImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ForeignCurrency?.Add(foreignCurrency);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateCurrencyBannerImagePath(ForeignCurrency foreignCurrency)
        {
            var count = _context.ForeignCurrency?.Count();
            if (count > 0)
            {
                var foreignCurrencyToUpdate = _context.ForeignCurrency?.First();

                foreignCurrencyToUpdate.CashCurrencyBannerImagePath = foreignCurrency.CashCurrencyBannerImagePath;

                _context.Entry(foreignCurrencyToUpdate).Property(i => i.CashCurrencyBannerImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ForeignCurrency?.Add(foreignCurrency);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateFCDeliveryImageFile(ForeignCurrency foreignCurrency)
        {
            var count = _context.ForeignCurrency?.Count();
            if (count > 0)
            {
                var foreignCurrencyToUpdate = _context.ForeignCurrency?.First();

                foreignCurrencyToUpdate.FCDeliveryImagePath = foreignCurrency.FCDeliveryImagePath;

                _context.Entry(foreignCurrencyToUpdate).Property(i => i.FCDeliveryImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ForeignCurrency?.Add(foreignCurrency);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateForeignCurrencySection(ForeignCurrency foreignCurrency)
        {
            var count = _context.ForeignCurrency?.Count();

            if (count > 0)
            {
                var foreignCurrencyToUpdate = _context.ForeignCurrency?.FirstOrDefault();


                foreignCurrencyToUpdate.InnerSectionPageHeader = foreignCurrency.InnerSectionPageHeader;
                foreignCurrencyToUpdate.InnerSectionPageDescription = foreignCurrency.InnerSectionPageDescription;
                foreignCurrencyToUpdate.FCDeliveryText = foreignCurrency.FCDeliveryText;
                foreignCurrencyToUpdate.FCExchangeTextFirstSection = foreignCurrency.FCExchangeTextFirstSection;
                foreignCurrencyToUpdate.FCExchangeTextSecondSection = foreignCurrency.FCExchangeTextSecondSection;
                foreignCurrencyToUpdate.FCExchangeTextThirdSection = foreignCurrency.FCExchangeTextThirdSection;
                foreignCurrencyToUpdate.BuySellCurrencyText = foreignCurrency.BuySellCurrencyText;
                foreignCurrencyToUpdate.BuySellCurrencyLinkOneText = foreignCurrency.BuySellCurrencyLinkOneText;
                foreignCurrencyToUpdate.BuySellCurrencyLinkOne = foreignCurrency.BuySellCurrencyLinkOne;
                foreignCurrencyToUpdate.BuySellCurrencyLinkTwoText = foreignCurrency.BuySellCurrencyLinkTwoText;
                foreignCurrencyToUpdate.BuySellCurrencyLinkTwo = foreignCurrency.BuySellCurrencyLinkTwo;
                foreignCurrencyToUpdate.BuySellCurrencyORText = foreignCurrency.BuySellCurrencyORText;
                foreignCurrencyToUpdate.ORDescriptionText = foreignCurrency.ORDescriptionText;

                //_context.Entry(foreignCurrencyToUpdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.Entry(foreignCurrencyToUpdate).Property(i => i.InnerSectionPageHeader).IsModified = true;
                _context.Entry(foreignCurrencyToUpdate).Property(i => i.InnerSectionPageDescription).IsModified = true;
                _context.Entry(foreignCurrencyToUpdate).Property(i => i.FCDeliveryText).IsModified = true;
                _context.Entry(foreignCurrencyToUpdate).Property(i => i.FCExchangeTextFirstSection).IsModified = true;
                _context.Entry(foreignCurrencyToUpdate).Property(i => i.FCExchangeTextSecondSection).IsModified = true;
                _context.Entry(foreignCurrencyToUpdate).Property(i => i.FCExchangeTextThirdSection).IsModified = true;
                _context.Entry(foreignCurrencyToUpdate).Property(i => i.BuySellCurrencyText).IsModified = true;
                _context.Entry(foreignCurrencyToUpdate).Property(i => i.BuySellCurrencyLinkOneText).IsModified = true;
                _context.Entry(foreignCurrencyToUpdate).Property(i => i.BuySellCurrencyLinkOne).IsModified = true;
                _context.Entry(foreignCurrencyToUpdate).Property(i => i.BuySellCurrencyLinkTwoText).IsModified = true;
                _context.Entry(foreignCurrencyToUpdate).Property(i => i.BuySellCurrencyLinkTwo).IsModified = true;
                _context.Entry(foreignCurrencyToUpdate).Property(i => i.BuySellCurrencyORText).IsModified = true;
                _context.Entry(foreignCurrencyToUpdate).Property(i => i.ORDescriptionText).IsModified = true;
                return await _context.SaveChangesAsync() > 0;

            }
            else
            {
                _context.ForeignCurrency?.Add(foreignCurrency);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateQRCodeImageFile(ForeignCurrency foreignCurrency)
        {
            var count = _context.ForeignCurrency?.Count();
            if (count > 0)
            {
                var foreignCurrencyToUpdate = _context.ForeignCurrency?.First();

                foreignCurrencyToUpdate.QRCodeImagePath = foreignCurrency.QRCodeImagePath;

                _context.Entry(foreignCurrencyToUpdate).Property(i => i.QRCodeImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ForeignCurrency?.Add(foreignCurrency);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateSliderImageFile(ForeignCurrency foreignCurrency)
        {
            var count = _context.ForeignCurrency?.Count();
            if (count > 0)
            {
                var foreignCurrencyToUpdate = _context.ForeignCurrency?.First();

                if (!string.IsNullOrEmpty(foreignCurrency.SlideImageFileOnePath))
                {
                    foreignCurrencyToUpdate.SlideImageFileOnePath = foreignCurrency.SlideImageFileOnePath;
                    _context.Entry(foreignCurrencyToUpdate).Property(i => i.SlideImageFileOnePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(foreignCurrency.SlideImageFileTwoPath))
                {
                    foreignCurrencyToUpdate.SlideImageFileTwoPath = foreignCurrency.SlideImageFileTwoPath;
                    _context.Entry(foreignCurrencyToUpdate).Property(i => i.SlideImageFileTwoPath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(foreignCurrency.SlideImageFileThreePath))
                {
                    foreignCurrencyToUpdate.SlideImageFileThreePath = foreignCurrency.SlideImageFileThreePath;
                    _context.Entry(foreignCurrencyToUpdate).Property(i => i.SlideImageFileThreePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(foreignCurrency.SlideImageFileFourPath))
                {
                    foreignCurrencyToUpdate.SlideImageFileFourPath = foreignCurrency.SlideImageFileFourPath;
                    _context.Entry(foreignCurrencyToUpdate).Property(i => i.SlideImageFileFourPath).IsModified = true;
                }

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ForeignCurrency?.Add(foreignCurrency);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateCorporateBanner(Corporate corporate)
        {
            var count = _context.Corporate?.Count();
            if (count > 0)
            {
                var corporateToUpdate = _context.Corporate?.First();

                corporateToUpdate.BannerImagePath = corporate.BannerImagePath;

                _context.Entry(corporateToUpdate).Property(i => i.BannerImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.Corporate?.Add(corporate);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateCorporateSection(Corporate model)
        {
            var count = _context.Corporate?.Count();

            if (count > 0)
            {
                var corporateToUpdate = _context.Corporate?.FirstOrDefault();


                corporateToUpdate.InnerSectionTitle = model.InnerSectionTitle;
                corporateToUpdate.InnerSectionDescription = model.InnerSectionDescription;
                corporateToUpdate.CorporateClientsText = model.CorporateClientsText;
                corporateToUpdate.ContactsText = model.ContactsText;
                

                _context.Entry(corporateToUpdate).Property(i => i.InnerSectionTitle).IsModified = true;
                _context.Entry(corporateToUpdate).Property(i => i.InnerSectionDescription).IsModified = true;
                _context.Entry(corporateToUpdate).Property(i => i.CorporateClientsText).IsModified = true;
                _context.Entry(corporateToUpdate).Property(i => i.ContactsText).IsModified = true;
               
                return await _context.SaveChangesAsync() > 0;

            }
            else
            {
                _context.Corporate?.Add(model);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateCorporateSliderImageFile(Corporate corporate)
        {
            var count = _context.Corporate?.Count();
            if (count > 0)
            {
                var corporateToUpdate = _context.Corporate?.First();

                if (!string.IsNullOrEmpty(corporate.SliderOneImagePath))
                {
                    corporateToUpdate.SliderOneImagePath = corporate.SliderOneImagePath;
                    _context.Entry(corporateToUpdate).Property(i => i.SliderOneImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(corporate.SliderTwoImagePath))
                {
                    corporateToUpdate.SliderTwoImagePath = corporate.SliderTwoImagePath;
                    _context.Entry(corporateToUpdate).Property(i => i.SliderTwoImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(corporate.SliderThreeImagePath))
                {
                    corporateToUpdate.SliderThreeImagePath = corporate.SliderThreeImagePath;
                    _context.Entry(corporateToUpdate).Property(i => i.SliderThreeImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(corporate.SliderFourImagePath))
                {
                    corporateToUpdate.SliderFourImagePath = corporate.SliderFourImagePath;
                    _context.Entry(corporateToUpdate).Property(i => i.SliderFourImagePath).IsModified = true;
                }

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.Corporate?.Add(corporate);
                return await _context.SaveChangesAsync() > 0;
            }
        }
    }
}
