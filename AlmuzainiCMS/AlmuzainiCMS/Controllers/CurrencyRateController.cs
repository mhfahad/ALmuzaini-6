using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models.RequestDto;
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
            ICollection<GetTTRateResult> data = await _manager.GetAllCurrencyAsync();
            if (data is not null)
                return Ok(data);
            return NotFound();
        }

        [AllowAnonymous]
        [HttpGet("LatestRequestId")]
        public async Task<IActionResult> GetRequestId()
        {
            var data = await _manager.GetLatestCurrencyRequestId();
            if (data > 0)
                return Ok(data);
            return NotFound();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddUpdateRequestId([FromBody] CurrencyRequestCreateDto model)
        {
            var result = await _manager.AddRequestIdAsync(model);
            if(result) return Ok(result);
            return BadRequest();
        }

    }
}
