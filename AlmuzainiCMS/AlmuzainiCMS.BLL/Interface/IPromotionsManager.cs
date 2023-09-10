using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.Interface
{
    public interface IPromotionsManager
    {
        Task<bool> AddPromotionNews(PromotionNews news);
        Promotion GetBannerAndInnerSectionTitle();
        List<PromotionNews> GetPromotionNews();
        Task<bool> UpdateBannerImagePath(Promotion promotion);
        Task<bool> UpdateInnerSection(Promotion promotion);
    }
}
