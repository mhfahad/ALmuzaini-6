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
    public class NewsRepository : INewsRepository
    {
        private readonly ProjectDbContext _context;

        public NewsRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNews(News model)
        {
            _context.News.Add(model);
            return await _context.SaveChangesAsync() > 0;   
            
        }

        public  List<News> GetAllNews()
        {
            List<News> newsList  =  _context.News.ToList() ?? Enumerable.Empty<News>().ToList();

            return newsList;

        }
    }
}
