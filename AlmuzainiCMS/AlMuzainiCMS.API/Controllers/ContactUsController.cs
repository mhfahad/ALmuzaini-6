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
    public class ContactUsController : ControllerBase
    {
        private readonly ILogger<ServicesController> _logger;

        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IContactUsManager _contactUsManager;

        public ContactUsController(ILogger<ServicesController> logger,  IWebHostEnvironment hostingEnvironment, IContactUsManager contactUsManager)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _contactUsManager = contactUsManager;
        }


        [HttpGet(Name = "ContactUs")]
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
