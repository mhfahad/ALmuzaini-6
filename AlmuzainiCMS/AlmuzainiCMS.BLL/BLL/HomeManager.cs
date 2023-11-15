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
    public class HomeManager : IHomeManager
    {
        private readonly IHomeRepository _repository;
        public HomeManager(IHomeRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddHomeCompanyDetail(HomeCompanyDetail compDetail)
        {
            try
            {
                bool result = await _repository.AddHomeCompanyDetail(compDetail);

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {

                return await Task.FromResult(false);

            }
        }

        public async Task<bool> AddHomeMidSlide(HomeMidSlide midSlide)
        {
            try
            {
                bool result = await _repository.AddHomeMidSlide(midSlide);

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {

                return await Task.FromResult(false);

            }
        }

        public async Task<bool> AddHomeVUrlText(HomeVUrl topText)
        {
            try
            {
                bool result = await _repository.AddHomeVUrlText(topText);

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {

                return await Task.FromResult(false);

            }
        }

        public async Task<bool> DeleteHomeMidSlideById(Guid id)
        {
            try
            {
                bool result = await _repository.DeleteHomeMidSlideById(id);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteVideoById(Guid id)
        {
            try
            {
                bool result = await _repository.DeleteVideoById(id);
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<HomeCompanyDetail> GetHomeCompanyDetail()
        {
            List<HomeCompanyDetail> companyDetail = new List<HomeCompanyDetail>();

            companyDetail = _repository.GetHomeCompanyDetail();
            return companyDetail;
        }

        public List<HomeMidSlide> GetHomeMidSlide()
        {
            List<HomeMidSlide> midSlide = new List<HomeMidSlide>();

            midSlide = _repository.GetHomeMidSlide();
            return midSlide;
        }

        public async Task<HomeMidSlide> GetHomeMidSlideById(Guid id)
        {
            return await _repository.GetHomeMidSlideById(id);
        }

        public List<HomeVUrl> GetHomeVUrl()
        {
            List<HomeVUrl> homeVUrl = new List<HomeVUrl>();

            homeVUrl = _repository.GetHomeVUrl();
            return homeVUrl;
        }

        public async Task<HomeVUrl> GetVideoById(Guid id)
        {
            return await _repository.GetVideoById(id);
        }
    }
}
