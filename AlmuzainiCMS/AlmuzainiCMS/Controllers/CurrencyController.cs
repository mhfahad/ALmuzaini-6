using AlmuzainiCMS.BLL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AlmuzainiCMS.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ICurrencySyncManager _manager;
        public CurrencyController(ICurrencySyncManager manager)
        {
            _manager = manager;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(string currency = "bdt")
        {
            var data = await _manager.GetCurrencySync();
            return View(data);
        }
    }
}
