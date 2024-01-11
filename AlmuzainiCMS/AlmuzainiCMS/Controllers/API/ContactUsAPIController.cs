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
    public class ContactUsAPIController : ControllerBase
    {
        private readonly ILogger<ServicesController> _logger;

        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IContactUsManager _contactUsManager;

        public ContactUsAPIController(ILogger<ServicesController> logger, IWebHostEnvironment hostingEnvironment, IContactUsManager contactUsManager)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _contactUsManager = contactUsManager;
        }


        [HttpGet("ContactUs")]
        public async Task<APIServiceResponse> ContactUs()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                ContactUs contactUs = new ContactUs();
                contactUs = await _contactUsManager.GetContactUs();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Contact Us Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(contactUs).ToString();
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
