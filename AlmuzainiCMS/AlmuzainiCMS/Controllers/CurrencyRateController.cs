﻿using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AlmuzainiCMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyRateController : ControllerBase
    {
        private readonly ICurrencySyncManager _manager;
        public CurrencyRateController(ICurrencySyncManager manager)
        {
            _manager = manager;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetCurrencyListAsync()
        {
            ICollection<CurrencyRate> data = await _manager.GetAllCurrencyAsync();
            if(data is not null) 
                return Ok(data);
            return NotFound();
        }
    }
}