using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlmuzainiCMS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionAPIController : ControllerBase
    {
        private readonly IPromotionsManager _promotionsManager;
        private readonly ILogger<ServicesController> _logger;


        private readonly IWebHostEnvironment _hostingEnvironment;

        public PromotionAPIController(ILogger<ServicesController> logger, IWebHostEnvironment webHostEnvironment, IPromotionsManager promotionsManager)
        {
            _promotionsManager = promotionsManager;
            _logger = logger;
            _hostingEnvironment = webHostEnvironment;
        }


        [HttpGet("Promotions")]
        public async Task<APIServiceResponse> Promotions()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                Promotion promotions = new Promotion();
                promotions = _promotionsManager.GetBannerAndInnerSectionTitle();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Promotions Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(promotions).ToString();
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpGet("PromotionsNews")]
        public async Task<APIServiceResponse> PromotionsNews()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                ICollection<PromotionNews> promotionNews = new List<PromotionNews>();
                promotionNews = _promotionsManager.GetPromotionNews();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Promotions Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(promotionNews).ToString();
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
