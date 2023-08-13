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
        private readonly INewsManager _newsManager;
       
        public HomeController(ILogger<HomeController> logger ,  IMapper mapper, IWebHostEnvironment webHostEnvironment, INewsManager newsManager)
        {
            _logger = logger;
            _mapper = mapper;
            _hostingEnvironment = webHostEnvironment;
            _newsManager = newsManager; 
             


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

            GetTopSlider("uploads", "original", "TopSlider");
            GetRateCalculator("uploads", "original", "RateCalculator"); //RateCalculator
            GetMiddleSlider("uploads", "original", "MiddleSlider"); //MiddleSlider
            GetRoundButtons("uploads", "original", "RoundButtons"); //RoundButtons
            GetLastSlider("uploads", "original", "LastSlider"); //LastSlider
            GetVideos("uploads", "original", "Videos"); //Videos
            GetLatestNews();

            return View();
        }
        [HttpPost]
        public IActionResult UploadTopSlider(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
            string filePath = Path.Combine(uploadsFolder, "original", "TopSlider");
            string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");

            DeleteAllFilesOfFolder(filePath);
            DeleteAllFilesOfFolder(thumbnailPath);

            foreach (var file in model.Files)
            {
                if (file != null && file.Length > 0)
                {
                   
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string fileExtension = Path.GetExtension(file.FileName);
                   
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;
                    if (model.position != "0")
                    {
                        totalfilesOriginal = Convert.ToInt32(model.position);


                    }
                    else
                    {
                        totalfilesOriginal = Directory.GetFiles(filePath).Count();

                    }

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
                Message = "File uploaded successfully.",
                redirectUrl = Url.Action("Home", "Home")
            };

           
            return Json(response);
        }

        [HttpPost]
        public IActionResult UploadRateCalculator(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
            string filePath = Path.Combine(uploadsFolder, "original", "RateCalculator");
            string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "RateCalculator");
            DeleteAllFilesOfFolder(filePath);
            DeleteAllFilesOfFolder(thumbnailPath);

            foreach (var file in model.Files)
            {
                if (file != null && file.Length > 0)
                {
                    
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string fileExtension = Path.GetExtension(file.FileName);
                    
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
                Message = "File uploaded successfully.",
                redirectUrl = Url.Action("Home", "Home")
            };

            
            return Json(response);

            //string redirectUrl = Url.Action("Home", "Home");

            // Return the URL in a JSON response
            //return Json(new { RedirectUrl = redirectUrl , responseMsg = response });
        }


        [HttpPost]
        public IActionResult UploadMiddleSlider(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
            string filePath = Path.Combine(uploadsFolder, "original", "MiddleSlider");
            string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "MiddleSlider");
            DeleteAllFilesOfFolder(filePath);
            DeleteAllFilesOfFolder(thumbnailPath);

            foreach (var file in model.Files)
            {
                if (file != null && file.Length > 0)
                {
                    
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string fileExtension = Path.GetExtension(file.FileName);
                   
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
                Message = "File uploaded successfully.",
                redirectUrl = Url.Action("Home", "Home")
            };

            return Json(response);
        }


        [HttpPost]
        public IActionResult UploadRoundButtons(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
            string filePath = Path.Combine(uploadsFolder, "original", "RoundButtons");
            string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "RoundButtons");
            DeleteAllFilesOfFolder(filePath);
            DeleteAllFilesOfFolder(thumbnailPath);

            foreach (var file in model.Files)
            {
                if (file != null && file.Length > 0)
                {
                   
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string fileExtension = Path.GetExtension(file.FileName);
                    
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
                Message = "File uploaded successfully.",
                redirectUrl = Url.Action("Home", "Home")
            };

            return Json(response);
        }

        [HttpPost]
        public IActionResult UploadLastSlider(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
            string filePath = Path.Combine(uploadsFolder, "original", "LastSlider");
            string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "LastSlider");
            DeleteAllFilesOfFolder(filePath);
            DeleteAllFilesOfFolder(thumbnailPath);

            foreach (var file in model.Files)
            {
                if (file != null && file.Length > 0)
                {
                    
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string fileExtension = Path.GetExtension(file.FileName);
                    
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
                Message = "File uploaded successfully.",
                redirectUrl = Url.Action("Home", "Home")
            };

            return Json(response);
        }



        [HttpPost]
        [DisableRequestSizeLimit,
        RequestFormLimits(MultipartBodyLengthLimit = int.MaxValue,
        ValueLengthLimit = int.MaxValue)]
        public IActionResult UploadVideo(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
            string filePath = Path.Combine(uploadsFolder, "original", "Videos");

            DeleteAllFilesOfFolder(filePath);

            foreach (var file in model.Files)
            {
                if (file != null && file.Length > 0)
                {
                    
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string fileExtension = Path.GetExtension(file.FileName);
                   
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

        [HttpPost]
        public  async Task<JsonResult> UploadNews( NewsVM model)
        {
            

            string filePath =  UploadFilesToFolder("Uploads", "original", "NewsImage", model.Image);

            News news = new News
            {
                Title = model.Title ?? "",
                Description = model.Description ?? "",
                ImagePath = filePath,
                CreatedAt = DateTime.Now

            };

            bool result = await  _newsManager.AddNews(news);

            var response = new
            {
                Success = true,
                Message = "News uploaded successfully.",
                redirectUrl = Url.Action("Home", "Home")
            };

            return Json(response);

            //return new JsonResult("News upload Failed ");
            //return Ok("Data processed successfully.");
        }

        private string UploadFilesToFolder(string folderName, string subFolderName, string typeFolderName, IFormFile file)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string filePath = Path.Combine(uploadsFolder, subFolderName, typeFolderName);
            string filePathToSave = string.Empty;
            if (file != null && file.Length > 0)
            {

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string fileExtension = Path.GetExtension(file.FileName);

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                int totalfilesOriginal = Directory.GetFiles(filePath).Count();
                filePathToSave = Path.Combine(filePath, (totalfilesOriginal + 1).ToString() + fileExtension);

                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

              
            }

            return filePathToSave;


            //var response = new
            //{
            //    Success = true,
            //    Message = "File uploaded successfully.",
            //    redirectUrl = Url.Action("Home", "Home")
            //};

            //return Json(response);
        }

        public void DeleteAllFilesOfFolder(string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    string[] files = Directory.GetFiles(folderPath);
                    foreach (string file in files)
                    {
                        System.IO.File.Delete(file);
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception("File Delete Failed");
            }

        }

        public void GetTopSlider(string folderName, string subfolder, string typefolder)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder);
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToArray();

                ViewBag.TopSliderFileNames = fileNames;
            }
            else
            {
                ViewBag.TopSliderFileNames = new string[0]; // No files available
            }

        }

        public void GetRateCalculator(string folderName, string subfolder, string typefolder)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder);
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToArray();

                ViewBag.RateCalculatorFileNames = fileNames;
            }
            else
            {
                ViewBag.RateCalculatorFileNames = new string[0]; // No files available
            }

        }

        public void GetMiddleSlider(string folderName, string subfolder, string typefolder)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder);
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToArray();

                ViewBag.MiddleSliderFileNames = fileNames;
            }
            else
            {
                ViewBag.MiddleSliderFileNames = new string[0]; // No files available
            }

        }

        
        public void GetRoundButtons(string folderName, string subfolder, string typefolder)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder);
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToArray();

                ViewBag.RoundButtonsFileNames = fileNames;
            }
            else
            {
                ViewBag.RoundButtonsFileNames = new string[0]; // No files available
            }

        }
        public void GetLastSlider(string folderName, string subfolder, string typefolder)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder);
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToArray();

                ViewBag.LastSliderFileNames = fileNames;
            }
            else
            {
                ViewBag.LastSliderFileNames = new string[0]; // No files available
            }

        }
        public void GetVideos(string folderName, string subfolder, string typefolder)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder);
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToArray();

                ViewBag.FileNames = fileNames;
            }
            else
            {
                ViewBag.FileNames = new string[0]; // No files available
            }

        }


        public void GetLatestNews()
        {
            List<News> news = _newsManager.GetAllNews();

            List<LatestNewsVM> latestNewsList = new List<LatestNewsVM>();

            foreach (News newsItem in news)
            {
                //DateTime startDateTime = new DateTime(2023, 8, 1, 10, 0, 0);
                //DateTime endDateTime = new DateTime(2023, 8, 13, 15, 30, 0);

                //TimeSpan timeDifference2 = endDateTime - startDateTime;

                TimeSpan timeDifference = DateTime.Now - newsItem.CreatedAt;

                int days = timeDifference.Days;
                int hours = timeDifference.Hours;
                int minutes = timeDifference.Minutes + (days > 0 ? days * 24*60 : 0) + (hours > 0 ? hours * 60 : 0);
                int seconds = timeDifference.Seconds;
                int i = 1;

                LatestNewsVM latestNews = new LatestNewsVM
                {
                    Id = newsItem.Id,
                    Title = newsItem.Title,
                    Description = newsItem.Description,
                    ImagePath = Path.GetFileName( newsItem.ImagePath ),
                    //UpdatedAt = $"{days} days, {hours} hours, {minutes} minutes, {seconds} seconds ago"
                    UpdatedAt = $"{minutes} minutes ago"
                };

                latestNewsList.Add(latestNews);

                //newsItem.CreatedAt = newsItem.CreatedAt 
            }

            ViewBag.LatestNews = latestNewsList; // No files available
            
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}