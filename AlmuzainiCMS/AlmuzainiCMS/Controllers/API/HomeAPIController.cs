using AlmuzainiCMS.BLL.BLL;
using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace AlmuzainiCMS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeAPIController : ControllerBase
    {
        private readonly IHomeManager _homeManager;
        private readonly ILogger<ServicesController> _logger;
        private readonly ICurrencySyncManager _manager;


        private readonly IWebHostEnvironment _hostingEnvironment;

        public HomeAPIController(ILogger<ServicesController> logger, IWebHostEnvironment webHostEnvironment, IHomeManager homeManager)
        {
            _homeManager = homeManager;
            _logger = logger;
            _hostingEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]

        [HttpGet("HomeVUrls")]
        public async Task<APIServiceResponse> HomeVUrls()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                ICollection<HomeVUrl> homeVUrl = new List<HomeVUrl>();
                homeVUrl = _homeManager.GetHomeVUrl();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Video URL Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(homeVUrl).ToString();
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("MiddleSlider")]
        public async Task<APIServiceResponse> MiddleSlider()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                ICollection<HomeMidSlide> homeMidSlide = new List<HomeMidSlide>();
                homeMidSlide = _homeManager.GetHomeMidSlide();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Video URL Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(homeMidSlide).ToString();
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("CompanyDetails")]
        public async Task<APIServiceResponse> CompanyDetails()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                ICollection<HomeCompanyDetail> homeCompanyDetail = new List<HomeCompanyDetail>();
                homeCompanyDetail = _homeManager.GetHomeCompanyDetail();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Home Company Detail Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(homeCompanyDetail).ToString();
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpGet("RateCalculatorNote")]
        public async Task<APIServiceResponse> RateCalculatorNote()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                ICollection<RateCalculatorNote> rateCalculatorNote = new List<RateCalculatorNote>();
                rateCalculatorNote = _homeManager.GetRateCalculatorNote();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Notel Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(rateCalculatorNote).ToString();
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
