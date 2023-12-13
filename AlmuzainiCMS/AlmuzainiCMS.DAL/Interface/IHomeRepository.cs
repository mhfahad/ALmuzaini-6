using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.Interface
{
    public interface IHomeRepository
    {
        Task<bool> AddHomeVUrlText(HomeVUrl topText);
        List<HomeVUrl> GetHomeVUrl();

        Task<HomeVUrl> GetVideoById(Guid id);
        Task<bool> DeleteVideoById(Guid id);

        ////// Middle Slider

        Task<bool> AddHomeMidSlide(HomeMidSlide midSlide);
        List<HomeMidSlide> GetHomeMidSlide();
        Task<HomeMidSlide> GetHomeMidSlideById(Guid id);
        Task<bool> DeleteHomeMidSlideById(Guid id);
        Task<bool> UpdateHomeMidSlide(HomeMidSlide upMidSlide);

        //// Home Company Details

        Task<bool> AddHomeCompanyDetail(HomeCompanyDetail compDetail);
        List<HomeCompanyDetail> GetHomeCompanyDetail();

        //// Home Rate Calculator Note

        Task<bool> AddRateCalculatorNote(RateCalculatorNote note);
        List<RateCalculatorNote> GetRateCalculatorNote();
    }
}
