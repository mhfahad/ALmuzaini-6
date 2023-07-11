using AlmuzainiCMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing.Internal;
using System.Diagnostics;
using System.Security.Policy;


namespace AlmuzainiCMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string ? SessionName = HttpContext.Session.GetString("_userName");
            string ? SessionAge =  HttpContext.Session.GetString("_userPass");
            if (SessionAge==null || SessionName == null)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
                return;
            }
        }
        public IActionResult Index()
        
        {
            ViewBag.userName = HttpContext.Session.GetString("_userName");
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Home()
        {

            return View();
        }
        public async Task<JsonResult> UploadTopSlider(List<IFormFile> ImgFile)
        {
         

            try
            {
                foreach (var formFile in ImgFile)
                {
                    if (formFile.Length > 0)
                    {
                        var fileName = formFile.FileName.Split('\\').LastOrDefault().Split('/').LastOrDefault();
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "~/Uploads/Home/", fileName);

                        using (var stream = System.IO.File.Create(filePath))
                        {
                            await formFile.CopyToAsync(stream);
                        }

                        return Json(true);
                    }
                }
            }
            catch (Exception exception)
            {
                return Json(false);
            }
            return Json(false);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}