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
    public class KoiskRepository : IKoiskRepository
    {
        private readonly ProjectDbContext _context;
        public KoiskRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddKoiskDetail(KoiskDetail koiskDetail)
        {
            _context.KoiskDetails.Add(koiskDetail);
            return await _context.SaveChangesAsync() > 0;
        }

        public List<KoiskDetail> GetKoiskDetail()
        {
            List<KoiskDetail> koiskDetail = _context.KoiskDetails.ToList() ?? new List<KoiskDetail>();

            return koiskDetail;
        }

        public KoiskBanner GetKoiskTopBanner()
        {
            KoiskBanner koiskBanner = _context.KoiskBanners.FirstOrDefault();
            return koiskBanner;
        }

        public async Task<bool> UpdateKoiskBannerImagePath(KoiskBanner koiskBanner)
        {
            var count = _context.KoiskBanners.Count();
            if (count > 0)
            {
                var koiskToUpdate = _context.KoiskBanners?.First();

                koiskToUpdate.KoiskTopBannerImagePath = koiskBanner.KoiskTopBannerImagePath;

                _context.Entry(koiskToUpdate).Property(i => i.KoiskTopBannerImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.KoiskBanners?.Add(koiskBanner);
                return await _context.SaveChangesAsync() > 0;
            }
        }
    }
}
