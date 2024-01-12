
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
    public class PromotionRepository : IPromotionRepository
    {
        private readonly ProjectDbContext _context;
        public PromotionRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddPromotionNews(PromotionNews news)
        {
            _context.PromotionNews.Add(news);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteLatestPromotionsById(Guid id)
        {
            var pNews = await _context.PromotionNews.FindAsync(id);
            if (pNews != null)
            {
                _context.PromotionNews.Remove(pNews);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public Promotion GetBannerAndInnerSectionTitle()
        {
            Promotion promotion = _context.Promotions.FirstOrDefault();
            return promotion;
        }

        public async Task<PromotionNews> GetLatestPromotionById(Guid id)
        {
            return await _context.PromotionNews.FirstOrDefaultAsync(b => b.Id == id);
        }

        public List<PromotionNews> GetPromotionNews()
        {
            List<PromotionNews> newsList = _context.PromotionNews.ToList() ?? new List<PromotionNews>();

            return newsList;
        }

        public async Task<bool> UpdateBannerImagePath(Promotion promotion)
        {
            var count = _context.Promotions.Count();
            if (count > 0)
            {
                var promotionToUpdate = _context.Promotions?.First();

                promotionToUpdate.BannerImagePath = promotion.BannerImagePath;

                _context.Entry(promotionToUpdate).Property(i => i.BannerImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.Promotions?.Add(promotion);  
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateInnerSection(Promotion promotion)
        {
            var count = _context.Promotions.Count();
            if (count > 0)
            {
                var promotionToUpdate = _context.Promotions?.First();

                promotionToUpdate.InnerSectionTitle = promotion.InnerSectionTitle;
              


                _context.Entry(promotionToUpdate).Property(i => i.InnerSectionTitle).IsModified = true;
                

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.Promotions?.Add(promotion);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateLatestPromotion(PromotionNews latestPromo)
        {
            _context.PromotionNews.Update(latestPromo);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
