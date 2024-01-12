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
    public class NewsPageRepository : INewsPageRepository
    {
        private readonly ProjectDbContext _context;
        public NewsPageRepository(ProjectDbContext context)  
        {
            _context = context;
        }

        public async Task<bool> AddNews(NewsSectionNews news)
        {
            _context.NewsSectionNews.Add(news);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteLatestNewsById(Guid id)
        {
            var lNews = await _context.NewsSectionNews.FindAsync(id);
            if (lNews != null)
            {
                _context.NewsSectionNews.Remove(lNews);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public NewsSection GetBannerAndInnerSectionTitle()
        {
            NewsSection newsSection = _context.NewsSections.FirstOrDefault();  
            return newsSection;
        }

        public async Task<NewsSectionNews> GetLatestNewsById(Guid id)
        {
            return await _context.NewsSectionNews.FirstOrDefaultAsync(b => b.Id == id);
        }

        public List<NewsSectionNews> GetNews()
        {
            List<NewsSectionNews> newsList = _context.NewsSectionNews.ToList() ?? new List<NewsSectionNews>();

            return newsList;
        }

        public async Task<bool> UpdateBannerImagePath(NewsSection news)
        {
            var count = _context.NewsSections.Count();
            if (count > 0)
            {
                var newsToUpdate = _context.NewsSections?.First();

                newsToUpdate.BannerImagePath = news.BannerImagePath;

                _context.Entry(newsToUpdate).Property(i => i.BannerImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.NewsSections?.Add(news);  
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateInnerSection(NewsSection news)
        {
            var count = _context.NewsSections.Count();
            if (count > 0)
            {
                var newsToUpdate = _context.NewsSections?.First();

                newsToUpdate.InnerSectionTitle = news.InnerSectionTitle;



                _context.Entry(newsToUpdate).Property(i => i.InnerSectionTitle).IsModified = true;


                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.NewsSections?.Add(news);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateLatestNews(NewsSectionNews uplatestNews)
        {
            _context.NewsSectionNews.Update(uplatestNews);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
