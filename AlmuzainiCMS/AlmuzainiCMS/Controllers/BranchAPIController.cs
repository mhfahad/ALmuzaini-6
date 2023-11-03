using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models;
using AlmuzainiCMS.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AlmuzainiCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchAPIController : ControllerBase
    {
        private readonly IBranchManager _branchManager;
        private readonly ILogger<ServicesController> _logger;
        private readonly ICurrencySyncManager _manager;


        private readonly IWebHostEnvironment _hostingEnvironment;

        public BranchAPIController(ILogger<ServicesController> logger, IWebHostEnvironment webHostEnvironment, IBranchManager branchManager)
        {
            _branchManager = branchManager;
            _logger = logger;
            _hostingEnvironment = webHostEnvironment;
        }

        [AllowAnonymous]

        [HttpGet("Branches")]
        public async Task<APIServiceResponse> Branches()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                Branch branch = new Branch();
                branch = _branchManager.GetBranchTopBanner();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Promotions Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(branch).ToString();
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("BranchTopText")]
        public async Task<APIServiceResponse> BranchTopText()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                ICollection<BranchTopText> branchTopText = new List<BranchTopText>();
                branchTopText = _branchManager.GetBranchTopText();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Branch Top Text Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(branchTopText).ToString();
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet("BranchDetail")]
        public async Task<APIServiceResponse> BranchDetail()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                ICollection<BranchDetail> branchDetail = new List<BranchDetail>();
                branchDetail = _branchManager.GetBranchDetails();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Branch Details Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(branchDetail).ToString();
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
