using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.BLL
{
    public class NewsPageManager : INewsPageManager
    {
        private readonly INewsPageRepository _repository;
        public NewsPageManager(INewsPageRepository repository)  
        {
            _repository = repository;
        }
        public async Task<bool> AddNews(NewsSectionNews news)
        {
            try
            {
                bool result = await _repository.AddNews(news);

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {

                return await Task.FromResult(false);

            }
        }

        public async Task<bool> DeleteLatestNewsById(Guid id)
        {
            try
            {
                bool result = await _repository.DeleteLatestNewsById(id);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public NewsSection GetBannerAndInnerSectionTitle()
        {
            NewsSection news = new NewsSection();

            news = _repository.GetBannerAndInnerSectionTitle();
            return news;
        }

        public async Task<NewsSectionNews> GetLatestNewsById(Guid id)
        {
            return await _repository.GetLatestNewsById(id);
        }

        public List<NewsSectionNews> GetNews()
        {
            List<NewsSectionNews> news = new List<NewsSectionNews>();

            news = _repository.GetNews();
            return news;
        }

        public async Task<bool> UpdateBannerImagePath(NewsSection news)
        {
            try
            {
                bool result = await _repository.UpdateBannerImagePath(news);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateInnerSection(NewsSection news)
        {
            try
            {
                bool result = await _repository.UpdateInnerSection(news);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateLatestNews(NewsSectionNews uplatestNews)
        {
            try
            {
                bool result = await _repository.UpdateLatestNews(uplatestNews);

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {

                return await Task.FromResult(false);

            }
        }
    }
}
