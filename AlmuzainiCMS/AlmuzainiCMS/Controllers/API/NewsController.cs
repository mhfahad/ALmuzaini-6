using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AlmuzainiCMS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsPageManager _newsManager;
        private readonly ILogger<ServicesController> _logger;


        private readonly IWebHostEnvironment _hostingEnvironment;
        public NewsController(ILogger<ServicesController> logger, IWebHostEnvironment webHostEnvironment, INewsPageManager newsManager)
        {
            _newsManager = newsManager;
            _logger = logger;

            _hostingEnvironment = webHostEnvironment;
        }

        [HttpGet("News")]
        public async Task<APIServiceResponse> News()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                NewsSection news = new NewsSection();
                news = _newsManager.GetBannerAndInnerSectionTitle();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched News Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(news).ToString();
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpGet("NewsSectionNews")]
        public async Task<APIServiceResponse> NewsSectionNews()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                ICollection<NewsSectionNews> news = new List<NewsSectionNews>();
                news = _newsManager.GetNews();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched News Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(news).ToString();
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
