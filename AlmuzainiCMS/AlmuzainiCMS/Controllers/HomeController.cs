using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models;
using AlmuzainiCMS.Models.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
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
       
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;
       
        public HomeController(ILogger<HomeController> logger ,  IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _mapper = mapper;
            _hostingEnvironment = webHostEnvironment;
           
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
        [HttpPost]
        public IActionResult UploadTopSlider(MultipleFileUploadVM model)
        {
            foreach (var file in model.Files)
            {
                if (file != null && file.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string fileExtension = Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(uploadsFolder, "original", "TopSlider");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    string filePathToSave = Path.Combine(filePath, (totalfilesOriginal + 1).ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    //Generate a thumbnail and save it
                    using (var imageStream = file.OpenReadStream())
                    using (var image = Image.Load(imageStream))
                    {
                        var thumbnail = image.Clone(x => x.Resize(new ResizeOptions
                        {
                            Size = new Size(300, 300),
                            Mode = ResizeMode.Max
                        }));

                        string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");
                        if (!Directory.Exists(thumbnailPath))
                        {
                            Directory.CreateDirectory(thumbnailPath);
                        }
                        int totalfiles = Directory.GetFiles(thumbnailPath).Count();

                        string thumbnailPathWithCount = Path.Combine(thumbnailPath, (totalfiles + 1).ToString() + fileExtension);
                        thumbnail.Save(thumbnailPathWithCount);
                    }
                }
            }
            var response = new
            {
                Success = true,
                Message = "File uploaded successfully."
            };

            return Json(response);
        }

        [HttpPost]
        public IActionResult UploadRateCalculator(MultipleFileUploadVM model)
        {
            foreach (var file in model.Files)
            {
                if (file != null && file.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string fileExtension = Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(uploadsFolder, "original", "RateCalculator");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    string filePathToSave = Path.Combine(filePath, (totalfilesOriginal + 1).ToString() + fileExtension);
                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    //Generate a thumbnail and save it
                    using (var imageStream = file.OpenReadStream())
                    using (var image = Image.Load(imageStream))
                    {
                        var thumbnail = image.Clone(x => x.Resize(new ResizeOptions
                        {
                            Size = new Size(300, 300),
                            Mode = ResizeMode.Max
                        }));

                        string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "RateCalculator");
                        if (!Directory.Exists(thumbnailPath))
                        {
                            Directory.CreateDirectory(thumbnailPath);
                        }
                        int totalfiles = Directory.GetFiles(thumbnailPath).Count();

                        string thumbnailPathWithCount = Path.Combine(thumbnailPath, (totalfiles + 1).ToString() + fileExtension);
                        thumbnail.Save(thumbnailPathWithCount);
                    }
                }
            }

            var response = new
            {
                Success = true,
                Message = "File uploaded successfully."
            };

            return Json(response);
        }


        [HttpPost]
        public IActionResult UploadMiddleSlider(MultipleFileUploadVM model)
        {
            foreach (var file in model.Files)
            {
                if (file != null && file.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string fileExtension = Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(uploadsFolder, "original", "MiddleSlider");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    string filePathToSave = Path.Combine(filePath, (totalfilesOriginal + 1).ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    //Generate a thumbnail and save it
                    using (var imageStream = file.OpenReadStream())
                    using (var image = Image.Load(imageStream))
                    {
                        var thumbnail = image.Clone(x => x.Resize(new ResizeOptions
                        {
                            Size = new Size(300, 300),
                            Mode = ResizeMode.Max
                        }));

                        string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "MiddleSlider");
                        if (!Directory.Exists(thumbnailPath))
                        {
                            Directory.CreateDirectory(thumbnailPath);
                        }
                        int totalfiles = Directory.GetFiles(thumbnailPath).Count();

                        string thumbnailPathWithCount = Path.Combine(thumbnailPath, (totalfiles + 1).ToString() + fileExtension);
                        thumbnail.Save(thumbnailPathWithCount);
                    }
                }
            }

            var response = new
            {
                Success = true,
                Message = "File uploaded successfully."
            };

            return Json(response);
        }


        [HttpPost]
        public IActionResult UploadRoundButtons(MultipleFileUploadVM model)
        {
            foreach (var file in model.Files)
            {
                if (file != null && file.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string fileExtension = Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(uploadsFolder, "original", "RoundButtons");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    string filePathToSave = Path.Combine(filePath, (totalfilesOriginal + 1).ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    //Generate a thumbnail and save it
                    using (var imageStream = file.OpenReadStream())
                    using (var image = Image.Load(imageStream))
                    {
                        var thumbnail = image.Clone(x => x.Resize(new ResizeOptions
                        {
                            Size = new Size(300, 300),
                            Mode = ResizeMode.Max
                        }));

                        string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "RoundButtons");
                        if (!Directory.Exists(thumbnailPath))
                        {
                            Directory.CreateDirectory(thumbnailPath);
                        }
                        int totalfiles = Directory.GetFiles(thumbnailPath).Count();

                        string thumbnailPathWithCount = Path.Combine(thumbnailPath, (totalfiles + 1).ToString() + fileExtension);
                        thumbnail.Save(thumbnailPathWithCount);
                    }
                }
            }

            var response = new
            {
                Success = true,
                Message = "File uploaded successfully."
            };

            return Json(response);
        }

        [HttpPost]
        public IActionResult UploadLastSlider(MultipleFileUploadVM model)
        {
            foreach (var file in model.Files)
            {
                if (file != null && file.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string fileExtension = Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(uploadsFolder, "original", "LastSlider");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    string filePathToSave = Path.Combine(filePath, (totalfilesOriginal + 1).ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    //Generate a thumbnail and save it
                    using (var imageStream = file.OpenReadStream())
                    using (var image = Image.Load(imageStream))
                    {
                        var thumbnail = image.Clone(x => x.Resize(new ResizeOptions
                        {
                            Size = new Size(300, 300),
                            Mode = ResizeMode.Max
                        }));

                        string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "LastSlider");
                        if (!Directory.Exists(thumbnailPath))
                        {
                            Directory.CreateDirectory(thumbnailPath);
                        }
                        int totalfiles = Directory.GetFiles(thumbnailPath).Count();

                        string thumbnailPathWithCount = Path.Combine(thumbnailPath, (totalfiles + 1).ToString() + fileExtension);
                        thumbnail.Save(thumbnailPathWithCount);
                    }
                }
            }

            var response = new
            {
                Success = true,
                Message = "File uploaded successfully."
            };

            return Json(response);
        }



        [HttpPost]
        public IActionResult UploadVideo(MultipleFileUploadVM model)
        {
            foreach (var file in model.Files)
            {
                if (file != null && file.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string fileExtension = Path.GetExtension(file.FileName);
                    string filePath = Path.Combine(uploadsFolder, "original", "Videos");
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    string filePathToSave = Path.Combine(filePath, (totalfilesOriginal + 1).ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                }
            }

            var response = new
            {
                Success = true,
                Message = "File uploaded successfully."
            };

            return Json(response);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}