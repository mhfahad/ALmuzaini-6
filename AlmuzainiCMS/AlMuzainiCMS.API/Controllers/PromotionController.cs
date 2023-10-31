
using AlmuzainiCMS.BLL.BLL;
using AlmuzainiCMS.BLL.Interface;
using AlMuzainiCMS.API.Models;
using AlmuzainiCMS.Models.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AlMuzainiCMS.API.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IPromotionsManager _promotionsManager;
        private readonly ILogger<ServicesController> _logger;

        
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PromotionController(ILogger<ServicesController> logger,  IWebHostEnvironment webHostEnvironment, IPromotionsManager promotionsManager)
        {
            _promotionsManager = promotionsManager;
            _logger = logger;
            _hostingEnvironment = webHostEnvironment;
        }


        [HttpGet(Name = "Promotions")]
        public async Task<APIServiceResponse> Promotions()   
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                Promotion promotions = new Promotion();
                promotions =  _promotionsManager.GetBannerAndInnerSectionTitle();
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


        [HttpGet(Name = "PromotionsNews")]  
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
