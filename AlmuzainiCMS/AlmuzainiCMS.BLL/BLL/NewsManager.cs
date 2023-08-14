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
    public class NewsManager : INewsManager
    {
        private readonly INewsRepository _newsRepository;

        public NewsManager(INewsRepository newsRepository)
        {
            this._newsRepository = newsRepository;
        }

        public async  Task<bool> AddNews(News news)
        {
            try
            {
                bool result = await _newsRepository.AddNews(news);

                return await Task.FromResult(result); 
            }
            catch (Exception ex)
            {
                //throw new Exception("Add News Failed");
                return await Task.FromResult(false); 

            }

            
        }

        public  List<News> GetAllNews()
        {
            List<News> news = new List<News>();
            try { 
            
                  news =  _newsRepository.GetAllNews();

                  return  news;
            }
            catch (Exception ex)
            {
                //throw new Exception("Add News Failed");
                return  news;

            }
        }
    }
}
