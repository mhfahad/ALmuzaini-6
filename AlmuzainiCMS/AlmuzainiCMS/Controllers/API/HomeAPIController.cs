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
    }
}
