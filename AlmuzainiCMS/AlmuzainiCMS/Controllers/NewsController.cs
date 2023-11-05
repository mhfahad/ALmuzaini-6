using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models.RequestDto;
using AlmuzainiCMS.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlmuzainiCMS.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsPageManager  _newsManager;
        private readonly ILogger<ServicesController> _logger;

        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public NewsController(ILogger<ServicesController> logger, IMapper mapper, IWebHostEnvironment webHostEnvironment, INewsPageManager newsManager)
        {
            _newsManager = newsManager;    
            _logger = logger;
            _mapper = mapper;
            _hostingEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            GetNews();
            GetNewsBannerAndInnerSectionTitle();
            return View();
        }

        private void GetNewsBannerAndInnerSectionTitle()
        {
            NewsSection news = _newsManager.GetBannerAndInnerSectionTitle();

            ViewBag.BannerImagePath = news?.BannerImagePath ?? "";
            ViewBag.InnerSectionTitle = news?.InnerSectionTitle ?? "";
        }

        private void GetNews()
        {
            List<NewsSectionNews> news = _newsManager.GetNews();

            List<LatestNewsVM> latestNewsNewsList = new List<LatestNewsVM>();

            foreach (NewsSectionNews newsItem in news)
            {


                TimeSpan timeDifference = (TimeSpan)(DateTime.Now - newsItem.CreatedAt);

                int days = timeDifference.Days;
                int hours = timeDifference.Hours;

                int minutes = timeDifference.Minutes;
                int seconds = timeDifference.Seconds;

                string updatedAt = days > 1 ? days.ToString() + " days ago" : days == 1 ? " yesterday" : hours > 1 ? hours.ToString() + " hours ago" : hours == 1 ? hours.ToString() + " hour ago" : minutes > 1 ? minutes.ToString() + " minutes ago" : minutes == 1 ? minutes.ToString() + " minute ago" : seconds.ToString() + " seconds ago";



                LatestNewsVM latestNewsItem = new LatestNewsVM
                {
                    Id = newsItem.Id,
                    Title = newsItem.Title,
                    Description = newsItem.Description,
                    ImagePath = newsItem.ImagePath,
                    //UpdatedAt = $"{days} days, {hours} hours, {minutes} minutes, {seconds} seconds ago"
                    UpdatedAt = updatedAt
                };

                latestNewsNewsList.Add(latestNewsItem);


            }

            ViewBag.NewsLatestNews = latestNewsNewsList; // No files available
        }


        [HttpPost]
        public async Task<JsonResult> UploadNews(NewsSectionNewsRequestDTO model)  
        {


            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "News", "NewsImage");
            //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");




            string filePathToSave = string.Empty;

            if (model?.ImageFile != null && model?.ImageFile.Length > 0)
            {

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.ImageFile.FileName;
                //string fileExtension = Path.GetExtension(file.FileName);
                string fileExtension = ".webp";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                int totalfilesOriginal;

                totalfilesOriginal = Directory.GetFiles(filePath).Count();
                filePathToSave = Path.Combine(filePath, (totalfilesOriginal + 1).ToString() + fileExtension);

                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    model?.ImageFile.CopyTo(fileStream);
                }


            }

            var imagePath =  filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
            //NewsSectionNews news = new NewsSectionNews();
            //news.ImagePath = imagePath;
            //companyHistory.ExpertiseImagePath = filePathToSave;


            NewsSectionNews news = new NewsSectionNews
            {
                Title = model.Title ?? "",
                Description = model.Description ?? "",
                ImagePath = imagePath,
                CreatedAt = DateTime.Now

            };

            bool result = await _newsManager.AddNews(news);

            var response = new
            {
                Success = true,
                Message = "News uploaded successfully.",
                redirectUrl = Url.Action("Index", "News")
            };

            return Json(response);

        }

        public void DeleteAllFilesOfFolderWithPosition(string folderPath, string position)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    if (position == "0")
                    {
                        string[] files = Directory.GetFiles(folderPath);
                        foreach (string file in files)
                        {
                            System.IO.File.Delete(file);
                        }
                    }
                    else
                    {
                        string[] files = Directory.GetFiles(folderPath).Where(filePath => Path.GetFileNameWithoutExtension(filePath).Equals(position, StringComparison.OrdinalIgnoreCase)).ToArray();
                        foreach (string file in files)
                        {
                            System.IO.File.Delete(file);
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception("File Delete Failed");
            }

        }
        public async Task<JsonResult> UploadNewsBanner(MultipleFileUploadVM model)  
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "News", "Banner");
            //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");

            string filePosition = model.position;

            //DeleteAllFilesOfFolder(filePath, filePosition);
            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);

            string filePathToSave = string.Empty;
            foreach (var file in model.Files)
            {
                if (file != null && file.Length > 0)
                {

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".webp";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    if (model.position != "0")
                    {
                        totalfilesOriginal = Convert.ToInt32(model.position);
                        filePathToSave = Path.Combine(filePath, (totalfilesOriginal).ToString() + fileExtension);

                    }
                    else
                    {
                        totalfilesOriginal = Directory.GetFiles(filePath).Count();
                        filePathToSave = Path.Combine(filePath, (totalfilesOriginal + 1).ToString() + fileExtension);

                    }
                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }


                }
            }
            var bannerImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
            NewsSection news = new NewsSection();
            news.BannerImagePath = bannerImagePath;
            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _newsManager.UpdateBannerImagePath(news);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "News Banner updated successfully.",
                    redirectUrl = Url.Action("Index", "News")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "News Banner updated failed.",
                    redirectUrl = Url.Action("Index", "News")
                };
                return Json(response);
            }
        }

        [HttpPost]

        public async Task<JsonResult> UpdateInnerSection(NewsSectionRequestDTO model)
        {
            var news = _mapper.Map<NewsSection>(model);
            bool result = await _newsManager.UpdateInnerSection(news);

            var response = new
            {
                Success = true,
                Message = "News Inner section updated successfully.",
                redirectUrl = Url.Action("Index", "News")
            };


            return Json(response);
        }



    }
}
