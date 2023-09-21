using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models.LoginVM;
using AlmuzainiCMS.Models.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AlmuzainiCMS.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserCreateManager manager;
        private readonly IMapper _mapper;
        public LoginController(IUserCreateManager Manager, IMapper mapper, IWebHostEnvironment hostEnvironment)
        {
            manager = Manager;
            _mapper = mapper;
            //webHostEnvironment = hostEnvironment;
        }
        // GET: LoginController
        public ActionResult Index()
        {
            HttpContext.Session.Remove("_userName");
            HttpContext.Session.Remove("_userPass");
            return View();
        }
        [HttpPost]
        public ActionResult Index(UsersInfoVM user)
        {
            //var entity = _mapper.Map<UsersInfo>(user);
            //var rData = manager.GetUsersList(entity);
            //if (rData == null)
            //{
            //    return Redirect("/Login/index");
            //}
            HttpContext.Session.SetString("_userName", user.userName);
            HttpContext.Session.SetString("_userPass", user.userPass);
            return Redirect("/Home/index");
        }
    }
}
