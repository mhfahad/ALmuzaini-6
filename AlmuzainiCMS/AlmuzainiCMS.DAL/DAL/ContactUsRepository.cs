using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.DataBaseContext.DataBaseContext;
using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.DAL
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly ProjectDbContext _context;

        public ContactUsRepository(ProjectDbContext context)
        {
            _context = context;
        }
        public async
            Task<ContactUs> GetContactUs()
        {
            ContactUs contactUs = _context.ContactUs.FirstOrDefault();
            return await Task.FromResult(contactUs);
        }

        public async Task<bool> UpdateBannerImagePath(ContactUs contactUS)
        {
            var count = _context.ContactUs.Count();
            if (count > 0)
            {
                var contactUsToUpdate = _context.ContactUs?.First();

                contactUsToUpdate.BannerImagePath = contactUS.BannerImagePath;

                _context.Entry(contactUsToUpdate).Property(i => i.BannerImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {  
                _context.ContactUs?.Add(contactUS);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateInnerSection(ContactUs contactUs)
        {
            var count = _context.ContactUs.Count();
            if (count > 0)
            {
                var contactUsToUpdate = _context.ContactUs?.First();

                contactUsToUpdate.InnerSectionTitle = contactUs.InnerSectionTitle;



                _context.Entry(contactUsToUpdate).Property(i => i.InnerSectionTitle).IsModified = true;

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ContactUs?.Add(contactUs);  
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateRightSection(ContactUs contactUS)
        {
            var count = _context.ContactUs.Count();
            if (count > 0)
            {
                var contactUsToUpdate = _context.ContactUs?.First();

                contactUsToUpdate.RightSectionTitle = contactUS.RightSectionTitle;
                contactUsToUpdate.RightSubOneSectionTitle = contactUS.RightSubOneSectionTitle;
                contactUsToUpdate.RightSubOneSectionText = contactUS.RightSubOneSectionText;
                contactUsToUpdate.RightSubTwoSectionTitle = contactUS.RightSubTwoSectionTitle;
                contactUsToUpdate.RightSubTwoSectionText = contactUS.RightSubTwoSectionText;
                contactUsToUpdate.RightSubThreeSectionTitle = contactUS.RightSubThreeSectionTitle;
                contactUsToUpdate.RightSubThreeSectionText = contactUS.RightSubThreeSectionText;
                contactUsToUpdate.RightSubFourSectionTitle = contactUS.RightSubFourSectionTitle;
                contactUsToUpdate.RightSubFourSectionText = contactUS.RightSubFourSectionText;
               

                _context.Entry(contactUsToUpdate).Property(i => i.RightSectionTitle).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.RightSubOneSectionTitle).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.RightSubOneSectionText).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.RightSubTwoSectionTitle).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.RightSubTwoSectionText).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.RightSubThreeSectionTitle).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.RightSubThreeSectionText).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.RightSubFourSectionTitle).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.RightSubFourSectionText).IsModified = true;
               



                if (!string.IsNullOrEmpty(contactUS.RightSubOneSectionIconPath))
                {
                    contactUsToUpdate.RightSubOneSectionIconPath = contactUS.RightSubOneSectionIconPath;
                    _context.Entry(contactUsToUpdate).Property(i => i.RightSubOneSectionIconPath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(contactUS.RightSubTwoSectionIconPath))
                {
                    contactUsToUpdate.RightSubTwoSectionIconPath = contactUS.RightSubTwoSectionIconPath;
                    _context.Entry(contactUsToUpdate).Property(i => i.RightSubTwoSectionIconPath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(contactUS.RightSubThreeSectionIconPath))
                {
                    contactUsToUpdate.RightSubThreeSectionIconPath = contactUS.RightSubThreeSectionIconPath;
                    _context.Entry(contactUsToUpdate).Property(i => i.RightSubThreeSectionIconPath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(contactUS.RightSubFourSectionIconPath))
                {
                    contactUsToUpdate.RightSubFourSectionIconPath = contactUS.RightSubFourSectionIconPath;
                    _context.Entry(contactUsToUpdate).Property(i => i.RightSubFourSectionIconPath).IsModified = true;
                }
               
                   

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ContactUs?.Add(contactUS);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateNewsSection(ContactUs contactUS)
        {
            var count = _context.ContactUs.Count();
            if (count > 0)
            {
                var contactUsToUpdate = _context.ContactUs?.First();

                contactUsToUpdate.NewsSectionOneTitle = contactUS.NewsSectionOneTitle;
                contactUsToUpdate.NewsSectionOneText = contactUS.NewsSectionOneText;
                contactUsToUpdate.NewsSectionTwoTitle = contactUS.NewsSectionTwoTitle;
                contactUsToUpdate.NewsSectionTwoText = contactUS.NewsSectionTwoText;
                contactUsToUpdate.NewsSectionThreeTitle = contactUS.NewsSectionThreeTitle;
                contactUsToUpdate.NewsSectionThreeText = contactUS.NewsSectionThreeText;
                contactUsToUpdate.NewsSectionFourTitle = contactUS.NewsSectionFourTitle;
                contactUsToUpdate.NewsSectionFourText = contactUS.NewsSectionFourText;
                contactUsToUpdate.NewsSectionFiveTitle = contactUS.NewsSectionFiveTitle;
                contactUsToUpdate.NewsSectionFiveText = contactUS.NewsSectionFiveText;

                _context.Entry(contactUsToUpdate).Property(i => i.NewsSectionOneTitle).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.NewsSectionOneText).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.NewsSectionTwoTitle).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.NewsSectionTwoText).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.NewsSectionThreeTitle).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.NewsSectionThreeText).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.NewsSectionFourTitle).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.NewsSectionFourText).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.NewsSectionFiveText).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.NewsSectionFiveTitle).IsModified = true;
              


                if (!string.IsNullOrEmpty(contactUS.NewsSectionOneImageath))
                {
                    contactUsToUpdate.NewsSectionOneImageath = contactUS.NewsSectionOneImageath;
                    _context.Entry(contactUsToUpdate).Property(i => i.NewsSectionOneImageath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(contactUS.NewsSectionTwoImageath))
                {
                    contactUsToUpdate.NewsSectionTwoImageath = contactUS.NewsSectionTwoImageath;
                    _context.Entry(contactUsToUpdate).Property(i => i.NewsSectionTwoImageath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(contactUS.NewsSectionThreeImageath))
                {
                    contactUsToUpdate.NewsSectionThreeImageath = contactUS.NewsSectionThreeImageath;
                    _context.Entry(contactUsToUpdate).Property(i => i.NewsSectionThreeImageath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(contactUS.NewsSectionFourImageath))
                {
                    contactUsToUpdate.NewsSectionFourImageath = contactUS.NewsSectionFourImageath;
                    _context.Entry(contactUsToUpdate).Property(i => i.NewsSectionFourImageath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(contactUS.NewsSectionFiveImageath))
                {
                    contactUsToUpdate.NewsSectionFiveImageath = contactUS.NewsSectionFiveImageath;
                    _context.Entry(contactUsToUpdate).Property(i => i.NewsSectionFiveImageath).IsModified = true;
                }



                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ContactUs?.Add(contactUS);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateLeftSection(ContactUs contactUS)   
        {
            var count = _context.ContactUs.Count();
            if (count > 0)
            {
                var contactUsToUpdate = _context.ContactUs?.First();

                contactUsToUpdate.LeftSectionTitle = contactUS.LeftSectionTitle;
                contactUsToUpdate.LeftSubOneSectionTitle = contactUS.LeftSubOneSectionTitle;
                contactUsToUpdate.LeftSubOneSectionText = contactUS.LeftSubOneSectionText;
                contactUsToUpdate.LeftSubTwoSectionTitle = contactUS.LeftSubTwoSectionTitle;
                contactUsToUpdate.LeftSubTwoSectionText = contactUS.LeftSubTwoSectionText;
                contactUsToUpdate.LeftSubThreeSectionTitle = contactUS.LeftSubThreeSectionTitle;
                contactUsToUpdate.LeftSubThreeSectionText = contactUS.LeftSubThreeSectionText;
                contactUsToUpdate.LeftSubFourSectionTitle = contactUS.LeftSubFourSectionTitle;
                contactUsToUpdate.LeftSubFourSectionText = contactUS.LeftSubFourSectionText;
                contactUsToUpdate.LeftSubFiveSectionTitle = contactUS.LeftSubFiveSectionTitle;
                contactUsToUpdate.LeftSubFiveSectionText = contactUS.LeftSubFiveSectionText;

                _context.Entry(contactUsToUpdate).Property(i => i.LeftSectionTitle).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.LeftSubOneSectionTitle).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.LeftSubOneSectionText).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.LeftSubTwoSectionTitle).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.LeftSubTwoSectionText).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.LeftSubThreeSectionTitle).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.LeftSubThreeSectionText).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.LeftSubFourSectionTitle).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.LeftSubFourSectionText).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.LeftSubFiveSectionTitle).IsModified = true;
                _context.Entry(contactUsToUpdate).Property(i => i.LeftSubFiveSectionText).IsModified = true;




                if (!string.IsNullOrEmpty(contactUS.LeftSubOneSectionIconPath))
                {
                    contactUsToUpdate.LeftSubOneSectionIconPath = contactUS.LeftSubOneSectionIconPath;
                    _context.Entry(contactUsToUpdate).Property(i => i.LeftSubOneSectionIconPath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(contactUS.LeftSubTwoSectionIconPath))
                {
                    contactUsToUpdate.LeftSubTwoSectionIconPath = contactUS.LeftSubTwoSectionIconPath;
                    _context.Entry(contactUsToUpdate).Property(i => i.LeftSubTwoSectionIconPath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(contactUS.LeftSubThreeSectionIconPath))
                {
                    contactUsToUpdate.LeftSubThreeSectionIconPath = contactUS.LeftSubThreeSectionIconPath;
                    _context.Entry(contactUsToUpdate).Property(i => i.LeftSubThreeSectionIconPath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(contactUS.LeftSubFourSectionIconPath))
                {
                    contactUsToUpdate.LeftSubFourSectionIconPath = contactUS.LeftSubFourSectionIconPath;
                    _context.Entry(contactUsToUpdate).Property(i => i.LeftSubFourSectionIconPath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(contactUS.LeftSubFiveSectionIconPath))
                {
                    contactUsToUpdate.LeftSubFiveSectionIconPath = contactUS.LeftSubFiveSectionIconPath;
                    _context.Entry(contactUsToUpdate).Property(i => i.LeftSubFiveSectionIconPath).IsModified = true;
                }



                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ContactUs?.Add(contactUS);
                return await _context.SaveChangesAsync() > 0;
            }
        }
    }
}
