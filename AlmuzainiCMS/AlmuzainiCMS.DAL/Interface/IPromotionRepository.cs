
using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.Interface
{
    public interface IPromotionRepository
    {
        Task<bool> AddPromotionNews(PromotionNews news);
        Promotion GetBannerAndInnerSectionTitle();
        List<PromotionNews> GetPromotionNews();
        Task<bool> UpdateBannerImagePath(Promotion promotion);
        Task<bool> UpdateInnerSection(Promotion promotion);

        ////Latest Promotion

        Task<PromotionNews> GetLatestPromotionById(Guid id);
        Task<bool> DeleteLatestPromotionsById(Guid id);
        Task<bool> UpdateLatestPromotion(PromotionNews latestPromo);
    }
}
