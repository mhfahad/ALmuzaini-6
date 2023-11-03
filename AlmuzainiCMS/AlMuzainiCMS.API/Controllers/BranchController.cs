using AlmuzainiCMS.BLL.BLL;
using AlmuzainiCMS.BLL.Interface;
using AlMuzainiCMS.API.Models;
using AlmuzainiCMS.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AlMuzainiCMS.API.Controllers
{
    [Route("api/[controller]/[action]")]

    [ApiController]

    public class BranchController : ControllerBase
    {

        private readonly IBranchManager _branchManager;
        private readonly ILogger<ServicesController> _logger;


        private readonly IWebHostEnvironment _hostingEnvironment;

        public BranchController(ILogger<ServicesController> logger, IWebHostEnvironment webHostEnvironment, IBranchManager branchManager)
        {
            _branchManager = branchManager;
            _logger = logger;
            _hostingEnvironment = webHostEnvironment;
        }


        [HttpGet(Name = "Branches")]
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


        [HttpGet(Name = "BranchTopText")]
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

        [HttpGet(Name = "BranchDetail")]
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
