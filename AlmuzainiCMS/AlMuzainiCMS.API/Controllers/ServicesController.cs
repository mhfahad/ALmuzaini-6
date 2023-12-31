﻿using AlmuzainiCMS.BLL.BLL;
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
    public class ServicesController : ControllerBase
    {
        private readonly ILogger<ServicesController> _logger;

       
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IForeignCurrencyManager _foreignCurrencyManager;
        private readonly IRemittancesManager _remittancesManager;
        private readonly IValueAddedBenifitsManager _valueAddedBenifitsManager;
        private readonly IApplicationPageManager _applicationPageManager;
        public ServicesController(ILogger<ServicesController> logger,  IWebHostEnvironment webHostEnvironment,
            IForeignCurrencyManager foreignCurrencyManager, IRemittancesManager remittancesManager, IValueAddedBenifitsManager valueAddedBenifitsManager,
            IApplicationPageManager applicationPageManager)
        {
            _logger = logger;
            
            _hostingEnvironment = webHostEnvironment;
            _foreignCurrencyManager = foreignCurrencyManager;
            _remittancesManager = remittancesManager;
            _valueAddedBenifitsManager = valueAddedBenifitsManager;
            _applicationPageManager = applicationPageManager;
        }

        [HttpGet(Name = "ForeignCurrency")]
        public async Task<APIServiceResponse> ForeignCurrency()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                ForeignCurrency foreignCurrency = new ForeignCurrency();
                foreignCurrency = await _foreignCurrencyManager.GetForeignCurrency();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Foreign Currency Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(foreignCurrency).ToString();   
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpGet(Name = "Corporate")]
        public async Task<APIServiceResponse> Corporate()   
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                Corporate corporate = new Corporate();
                corporate = await _foreignCurrencyManager.GetCorporate();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Corporate Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(corporate).ToString();
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpGet(Name = "Remittences")]
        public async Task<APIServiceResponse> Remittences()  
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                Remittences remitences = new Remittences();
                remitences = await _remittancesManager.GetRemittances();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Remittences Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(remitences).ToString();
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpGet(Name = "ValueAddedBenifits")]
        public async Task<APIServiceResponse> ValueAddedBenifits()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                ValueAddedBenifits vab = new ValueAddedBenifits();
                vab = await _valueAddedBenifitsManager.GetValueAddedBenifits();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Value Added Benifits Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(vab).ToString();   
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet(Name = "ApplicationPage")]
        public async Task<APIServiceResponse> ApplicationPage()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                ApplicationPage ap = new ApplicationPage();
                ap = await _applicationPageManager.GetApplicationPage();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Application Page Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(ap).ToString();  
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
