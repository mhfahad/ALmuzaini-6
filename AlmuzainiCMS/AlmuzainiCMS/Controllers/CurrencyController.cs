using AlmuzainiCMS.BLL.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlmuzainiCMS.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ICurrencySyncManager _manager;
        public CurrencyController(ICurrencySyncManager manager)
        {
            _manager = manager;
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
        public ActionResult Index()
        {
            return View();
        }

        public async Task CurrencySync()
        {
            await _manager.GetCurrencySync();
            RedirectToAction("Index");
        }
    }
}
