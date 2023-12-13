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
    public class HomeRepository : IHomeRepository
    {
        private readonly ProjectDbContext _context;
        public HomeRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddHomeCompanyDetail(HomeCompanyDetail compDetail)
        {
            _context.HomeCompanyDetails.Add(compDetail);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddHomeMidSlide(HomeMidSlide midSlide)
        {
            _context.HomeMidSlides.Add(midSlide);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddHomeVUrlText(HomeVUrl topText)
        {
            _context.HomeVUrls.Add(topText);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddRateCalculatorNote(RateCalculatorNote note)
        {
            _context.RateCalculatorNotes.Add(note);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteHomeMidSlideById(Guid id)
        {
            var mSlide = await _context.HomeMidSlides.FindAsync(id);
            if (mSlide != null)
            {
                _context.HomeMidSlides.Remove(mSlide);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteVideoById(Guid id)
        {
            var vUrl = await _context.HomeVUrls.FindAsync(id);
            if (vUrl != null)
            {
                _context.HomeVUrls.Remove(vUrl);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public List<HomeCompanyDetail> GetHomeCompanyDetail()
        {
            List<HomeCompanyDetail> compDetailList = _context.HomeCompanyDetails.ToList() ?? new List<HomeCompanyDetail>();

            return compDetailList;
        }

        public List<HomeMidSlide> GetHomeMidSlide()
        {
            List<HomeMidSlide> mSlideList = _context.HomeMidSlides.ToList() ?? new List<HomeMidSlide>();

            return mSlideList;
        }

        public async Task<HomeMidSlide> GetHomeMidSlideById(Guid id)
        {
            return await _context.HomeMidSlides.FirstOrDefaultAsync(b => b.Id == id);
        }

        public List<HomeVUrl> GetHomeVUrl()
        {
            List<HomeVUrl> topTextList = _context.HomeVUrls.ToList() ?? new List<HomeVUrl>();

            return topTextList;
        }

        public List<RateCalculatorNote> GetRateCalculatorNote()
        {
            List<RateCalculatorNote> notes = _context.RateCalculatorNotes.ToList() ?? new List<RateCalculatorNote>();

            return notes;
        }

        public async Task<HomeVUrl> GetVideoById(Guid id)
        {
            return await _context.HomeVUrls.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<bool> UpdateHomeMidSlide(HomeMidSlide upMidSlide)
        {
            _context.HomeMidSlides.Update(upMidSlide);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
