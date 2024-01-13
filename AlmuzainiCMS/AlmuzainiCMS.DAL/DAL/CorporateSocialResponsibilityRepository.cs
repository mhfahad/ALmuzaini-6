using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.DataBaseContext.DataBaseContext;
using AlmuzainiCMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.DAL
{
    public class CorporateSocialResponsibilityRepository : ICorporateSocialResponsibilityRepository
    {
        private readonly ProjectDbContext _context;
        public CorporateSocialResponsibilityRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public CorporateSocialRespBanner GetCorporateSocialRespBanner()
        {
            CorporateSocialRespBanner corporateSocialRespBanner = _context.CorporateSocialRespBanners.FirstOrDefault();
            return corporateSocialRespBanner;
        }

        public async Task<CorporateSocialResponsibility> GetCorporateSocialResponsibility()
        {
            CorporateSocialResponsibility corporateSocialResponsibility = _context.CorporateSocialResponsibilities.FirstOrDefault();
            return await Task.FromResult(corporateSocialResponsibility);  
        }

        public async Task<bool> UpdateCorporateSocialRespBanner(CorporateSocialRespBanner corporateSocialRespBanner)
        {
            var count = _context.CorporateSocialRespBanners.Count();
            if (count > 0)
            {
                var csrToUpdate = _context.CorporateSocialRespBanners?.First();

                csrToUpdate.CorporateSocialRespBannerImagePath = corporateSocialRespBanner.CorporateSocialRespBannerImagePath;

                _context.Entry(csrToUpdate).Property(i => i.CorporateSocialRespBannerImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.CorporateSocialRespBanners?.Add(corporateSocialRespBanner);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateCorporateSocialResponsibilityImage(CorporateSocialResponsibility corporateSocialResponsibility)
        {
            var count = _context.CorporateSocialResponsibilities?.Count();
            if (count > 0)
            {
                var csrToUpdate = _context.CorporateSocialResponsibilities?.First();

                csrToUpdate.CorporateSocialResponsibilityImagePath = corporateSocialResponsibility.CorporateSocialResponsibilityImagePath;

                _context.Entry(csrToUpdate).Property(i => i.CorporateSocialResponsibilityImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {  
                _context.CorporateSocialResponsibilities?.Add(corporateSocialResponsibility);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateCorporateSocialResponsibilitySection(CorporateSocialResponsibility corporateSocialResponsibility)
        {
            var count = _context.CorporateSocialResponsibilities?.Count();

            if (count > 0)
            {
                var csrToUpdate = _context.CorporateSocialResponsibilities?.FirstOrDefault();


                csrToUpdate.FirstSection = corporateSocialResponsibility.FirstSection;
                csrToUpdate.SecondSection = corporateSocialResponsibility.SecondSection;
                csrToUpdate.ThirdSection = corporateSocialResponsibility.ThirdSection;
                csrToUpdate.FourthSection = corporateSocialResponsibility.FourthSection;
                csrToUpdate.FifthSection = corporateSocialResponsibility.FifthSection;
                csrToUpdate.SixthSection = corporateSocialResponsibility.SixthSection;
                csrToUpdate.SeventhSection = corporateSocialResponsibility.SeventhSection;

                _context.Entry(csrToUpdate).State = EntityState.Modified;

               
                return await _context.SaveChangesAsync() > 0;

            }
            else
            {
                _context.CorporateSocialResponsibilities?.Add(corporateSocialResponsibility);
                return await _context.SaveChangesAsync() > 0;
            }
        }
    }
}
