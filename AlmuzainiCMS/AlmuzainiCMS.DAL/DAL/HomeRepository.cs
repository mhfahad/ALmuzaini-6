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
    public class HomeRepository : IHomeRepository
    {
        private readonly ProjectDbContext _context;
        public HomeRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddHomeVUrlText(HomeVUrl topText)
        {
            _context.HomeVUrls.Add(topText);
            return await _context.SaveChangesAsync() > 0;
        }

        public List<HomeVUrl> GetHomeVUrl()
        {
            List<HomeVUrl> topTextList = _context.HomeVUrls.ToList() ?? new List<HomeVUrl>();

            return topTextList;
        }
    }
}
