using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models.Models;
using AlMuzainiCMS.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AlMuzainiCMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly ILogger<AboutController> _logger;

        
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ICompanyHistoryManager _companyHistoryManager;
        private readonly IChairmanMessageManager _chairmanMessageManager;
        private readonly IMissionVisionValuesManager _missionVisionValuesManager;
        private readonly ICorporateSocialResponsibilityManager _corporateSocialResponsibilityManager;


        public AboutController(ILogger<AboutController> logger,  IWebHostEnvironment webHostEnvironment,
            ICompanyHistoryManager companyHistoryManager, IChairmanMessageManager chairmanMessageManager,
            IMissionVisionValuesManager missionVisionValuesManager, ICorporateSocialResponsibilityManager corporateSocialResponsibilityManager)
        {
            _logger = logger;
          
            _hostingEnvironment = webHostEnvironment;
            _companyHistoryManager = companyHistoryManager;
            _missionVisionValuesManager = missionVisionValuesManager;
            _chairmanMessageManager = chairmanMessageManager;
            _corporateSocialResponsibilityManager = corporateSocialResponsibilityManager;
        }

        [HttpGet(Name = "CompanyHistory")]
        public async Task< APIServiceResponse > GetCompanyHistory() 
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                CompanyHistory companyHistory = new CompanyHistory();
                companyHistory = await _companyHistoryManager.GetCompanyHistorySection();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Company History Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(companyHistory).ToString();  
                objResponse.ResponseCode = 200;

                return objResponse;
                
            }catch(Exception ex)
            {
                throw;
            }
        }

        [HttpGet(Name = "ChairmansMessage")]
        public async Task<APIServiceResponse> ChairmansMessage() 
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                ChairmanMessage chairmanMessage = new ChairmanMessage();
                chairmanMessage = await _chairmanMessageManager.GetChairmanMessage();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Chairman Message Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(chairmanMessage).ToString();   
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet(Name = "MissionVisionValues")]   
        public async Task<APIServiceResponse> MissionVisionValues()     
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                MissionVisionValues visionMissionValues = new MissionVisionValues();
                visionMissionValues = await _missionVisionValuesManager.GetMissionVisionValues();   
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Mission Vision Values Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(visionMissionValues,Formatting.Indented).ToString();   
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
    
        }

        [HttpGet(Name = "ValuesItem")]
        public async Task<APIServiceResponse> ValuesItem()   
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                ICollection<ValuesItem> valuesItem = new List<ValuesItem>();
                valuesItem = await _missionVisionValuesManager.GetMissionVisionValuesItems();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();  
                objResponse.SuccessMsg = "Fetched Values Items Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(valuesItem).ToString();
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpGet(Name = "CorporateSocialResponsibility")]
        public async Task<APIServiceResponse> CorporateSocialResponsibility()   
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                CorporateSocialResponsibility csr = new CorporateSocialResponsibility();
                csr = await _corporateSocialResponsibilityManager.GetCorporateSocialResponsibility();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Corporate Social Responsibility Items Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(csr).ToString();
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
