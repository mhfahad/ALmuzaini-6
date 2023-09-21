using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.Interface
{
    public interface INewsPageManager
    {
        Task<bool> AddNews(NewsSectionNews news);
        NewsSection GetBannerAndInnerSectionTitle();
        List<NewsSectionNews> GetNews();
        Task<bool> UpdateBannerImagePath(NewsSection news);
        Task<bool> UpdateInnerSection(NewsSection news);
    }
}
