using AlmuzainiCMS.BLL.BLL;
using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models;
using Microsoft.AspNetCore.Mvc;
using AlmuzainiCMS.Models.RequestDto;
using AutoMapper;

namespace AlmuzainiCMS.Controllers
{
    public class PromotionsController : Controller
    {
        private readonly IPromotionsManager _promotionsManager;
        private readonly ILogger<ServicesController> _logger;

        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public PromotionsController(ILogger<ServicesController> logger, IMapper mapper, IWebHostEnvironment webHostEnvironment, IPromotionsManager promotionsManager)
        {
            _promotionsManager = promotionsManager;
            _logger = logger;
            _mapper = mapper;
            _hostingEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            GetPromotionNews();
            GetPromotionsBannerAndInnerSectionTitle();
            return View();
        }

        private void GetPromotionsBannerAndInnerSectionTitle()
        {
            Promotion promotion =  _promotionsManager.GetBannerAndInnerSectionTitle();

            ViewBag.BannerImagePath = promotion?.BannerImagePath ?? "";
            ViewBag.InnerSectionTitle = promotion?.InnerSectionTitle ?? "";
        }

        private void GetPromotionNews()  
        {
            List<PromotionNews> promotionnews = _promotionsManager.GetPromotionNews();

            List<LatestNewsVM> latestNewsList = new List<LatestNewsVM>();

            foreach (PromotionNews newsItem in promotionnews)
            {
                

                TimeSpan timeDifference = (TimeSpan)(DateTime.Now - newsItem.CreatedAt);  

                int days = timeDifference.Days;
                int hours = timeDifference.Hours;
         
                int minutes = timeDifference.Minutes;
                int seconds = timeDifference.Seconds;

                string updatedAt = days > 1 ? days.ToString() + " days ago" : days == 1 ? " yesterday" : hours > 1 ? hours.ToString() + " hours ago" : hours == 1 ? hours.ToString() + " hour ago" : minutes > 1 ? minutes.ToString() + " minutes ago" : minutes == 1 ? minutes.ToString() + " minute ago" : seconds.ToString() + " seconds ago";



                LatestNewsVM promotionlatestNews = new LatestNewsVM
                {
                    Id = newsItem.Id,
                    Title = newsItem.Title,
                    Description = newsItem.Description,
                    ImagePath = newsItem.ImagePath,
                    //UpdatedAt = $"{days} days, {hours} hours, {minutes} minutes, {seconds} seconds ago"
                    UpdatedAt = updatedAt
                };

                latestNewsList.Add(promotionlatestNews);  

                
            }

            ViewBag.PromotionLatestNews = latestNewsList; // No files available
        }


        [HttpPost]
        public async Task<JsonResult> UploadPromotionNews(PromotionNewsRequestDTO model)   
        {


            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Promotion", "NewsImage");
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
            
            var imagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
            //PromotionNews promotionNews = new PromotionNews();
            //promotionNews.ImagePath = imagePath;
            //companyHistory.ExpertiseImagePath = filePathToSave;
            

            PromotionNews news = new PromotionNews
            {
                Title = model.Title ?? "",
                Description = model.Description ?? "",
                ImagePath = imagePath,
                CreatedAt = DateTime.Now

            };

            bool result = await _promotionsManager.AddPromotionNews(news);

            var response = new
            {
                Success = true,
                Message = "News uploaded successfully.",
                redirectUrl = Url.Action("Index", "Promotions")
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
        public async Task<JsonResult> UploadPromotionBanner(MultipleFileUploadVM model)  
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Promotion",  "Banner");
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
            Promotion promotion = new Promotion();
            promotion.BannerImagePath = bannerImagePath;
            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _promotionsManager.UpdateBannerImagePath(promotion);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Promotion Banner updated successfully.",
                    redirectUrl = Url.Action("Index", "Promotions")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Promotion Banner updated failed.",
                    redirectUrl = Url.Action("Index", "Promotions")
                };
                return Json(response);
            }
        }

        [HttpPost]

        public async Task<JsonResult> UpdatePromotionInnerSection(PromotionRequestDTO model)
        {
            var promotion = _mapper.Map<Promotion>(model);
            bool result = await _promotionsManager.UpdateInnerSection(promotion);

            var response = new
            {
                Success = true,
                Message = "Promotion Inner section updated successfully.",
                redirectUrl = Url.Action("Index", "Promotions")
            };


            return Json(response);
        }



    }
}
