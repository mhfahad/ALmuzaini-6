﻿using AlmuzainiCMS.BLL.BLL;
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
    }
}
