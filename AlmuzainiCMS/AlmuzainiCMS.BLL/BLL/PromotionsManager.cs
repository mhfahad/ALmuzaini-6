
using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.DAL.DAL;
using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.BLL
{
    public class PromotionsManager : IPromotionsManager
    {
        private readonly IPromotionRepository _repository;
        public PromotionsManager(IPromotionRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> AddPromotionNews(PromotionNews news)
        {
            try
            {
                bool result = await _repository.AddPromotionNews(news);

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                
                return await Task.FromResult(false);

            }
        }

        public async Task<bool> DeleteLatestPromotionsById(Guid id)
        {
            try
            {
                bool result = await _repository.DeleteLatestPromotionsById(id);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Promotion GetBannerAndInnerSectionTitle()
        {
            Promotion promotion = new Promotion();

            promotion =  _repository.GetBannerAndInnerSectionTitle();
            return promotion;
        }

        public async Task<PromotionNews> GetLatestPromotionById(Guid id)
        {
            return await _repository.GetLatestPromotionById(id);
        }

        public List<PromotionNews> GetPromotionNews()
        {
            List<PromotionNews> promotionNews = new List<PromotionNews>();

            promotionNews =  _repository.GetPromotionNews();
            return promotionNews;
        }

        public async Task<bool> UpdateBannerImagePath(Promotion promotion)
        {
            try
            {
                bool result = await _repository.UpdateBannerImagePath(promotion);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateInnerSection(Promotion promotion)
        {
            try
            {
                bool result = await _repository.UpdateInnerSection(promotion); 
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateLatestPromotion(PromotionNews latestPromo)
        {
            try
            {
                bool result = await _repository.UpdateLatestPromotion(latestPromo);

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {

                return await Task.FromResult(false);

            }
        }
    }
}
