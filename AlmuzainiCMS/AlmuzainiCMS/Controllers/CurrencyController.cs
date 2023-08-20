using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models.RequestDto;
using AlmuzainiCMS.Models.Utility;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace AlmuzainiCMS.Controllers
{
    public class CurrencyController : Controller
    {
        string flagDirectory = "Flag";
        private readonly ICurrencySyncManager _manager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;
        public CurrencyController(ICurrencySyncManager manager, IWebHostEnvironment hostingEnvironment, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _manager = manager;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string? SessionName = HttpContext.Session.GetString("_userName");
            string? SessionAge = HttpContext.Session.GetString("_userPass");
            if (SessionAge == null || SessionName == null)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
                return;
            }
        }
        public async Task<ActionResult> Index()
        {
            var data = await _manager.GetAllCurrencyAsync();
            return View(data);
        }
        
        public async Task CurrencySync()
        {
            await _manager.GetCurrencySync();
            Response.Redirect("/Currency/Index/1");
        }

        public async Task<IActionResult> GetAllCurrency()
        {
            var data = await _manager.GetAllCurrencyAsync();
            return View(data);
        }


        public IActionResult RequestIdPostAPI()
        {
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> AddCurrencyCode()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddCurrencyCode(CurrencyCodeRequestDto model)
        {
            if (model.FlagFile != null)
            {
                model.flagPath = FileManagement.UploadImageFile(model.FlagFile, flagDirectory, _httpContextAccessor);
            }
            var currencyCode = _mapper.Map<CurrencyCode>(model);
            var result = await _manager.AddCurrencycodeAsync(currencyCode);
            if (result)
            {
                return View();
            }
            return View("not null");
        }
    }
}
