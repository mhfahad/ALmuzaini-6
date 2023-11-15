using AlmuzainiCMS.BLL.BLL;
using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models.Models;
using AlMuzainiCMS.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection;

namespace AlMuzainiCMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        //private readonly IMapper _mapper;
        private readonly IHomeManager _homeManager;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly INewsManager _newsManager;

        public HomeController(ILogger<HomeController> logger,IWebHostEnvironment webHostEnvironment, INewsManager newsManager, IHomeManager homeManager)  
        {
            _logger = logger;
            //_mapper = mapper;
            _hostingEnvironment = webHostEnvironment;
            _newsManager = newsManager;
            _homeManager = homeManager;



        }

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet(Name = "GetHomeWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet(Name = "HomeVUrls")]
        public async Task<APIServiceResponse> HomeVUrls()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                ICollection<HomeVUrl> homeVUrl = new List<HomeVUrl>();
                homeVUrl = _homeManager.GetHomeVUrl();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Video URL Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(homeVUrl).ToString();
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet(Name = "CompanyDetails")]
        public async Task<APIServiceResponse> CompanyDetails()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                ICollection<HomeCompanyDetail> homeCompanyDetail = new List<HomeCompanyDetail>();
                homeCompanyDetail = _homeManager.GetHomeCompanyDetail();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Home Company Detail Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(homeCompanyDetail).ToString();
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpGet(Name = "GetHomeContent")]
        public APIServiceResponse GetHomeContent()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {

                //string[] sliderFileNames = GetFilePaths("uploads", "original", "TopSlider");
                //string[] rateCalculatorFileNames = GetFilePaths("uploads", "original", "RateCalculator"); //RateCalculator
                //string[] middleSliderFileNames = GetFilePaths("uploads", "original", "MiddleSlider"); //MiddleSlider
                //string[] roundButtondFileNames = GetFilePaths("uploads", "original", "RoundButtons"); //RoundButtons
                //string[] lastSliderFileNames = GetFilePaths("uploads", "original", "LastSlider"); //LastSlider
                //string[] videosFileNames = GetFilePaths("uploads", "original", "VideoImageThumb"); //Videos
                //List<LatestNews> latestNews = GetLatestNews();

                string rootpath = _hostingEnvironment.ContentRootPath;
                var parentName = Directory.GetParent(rootpath).FullName;
                var grandParentName = Directory.GetParent(parentName).FullName;
                string folderName = "uploads";
                string subfolder = "original";
              
                string typetopsliderfolder = "TopSlider";
                string uploadsFolderPath = Path.Combine(grandParentName, "AlmuzainiCMS", "wwwroot", folderName);

                string folderPath = Path.Combine(uploadsFolderPath, subfolder, typetopsliderfolder);  
                // Replace with the actual folder path
                string[] sliderfileNames;
                if (Directory.Exists(folderPath))
                {
                    sliderfileNames = Directory.GetFiles(folderPath)
                       .Select(Path.GetFileName)
                       .ToArray();

                    // fileNames;
                }
                else
                {
                    sliderfileNames = new string[0]; // No files available
                }

                string ratefolder = "RateCalculator";
                string rateuploadsFolderPath = Path.Combine(grandParentName, "AlmuzainiCMS", "wwwroot", folderName);

                string ratefolderPath = Path.Combine(rateuploadsFolderPath, subfolder, ratefolder);
                // Replace with the actual folder path
                string[] ratefileNames;
                if (Directory.Exists(ratefolderPath))
                {
                    ratefileNames = Directory.GetFiles(ratefolderPath)
                       .Select(Path.GetFileName)
                       .ToArray();

                    // fileNames;
                }
                else
                {
                    ratefileNames = new string[0]; // No files available
                }


                string middleSlider = "MiddleSlider";
                string middleSlideruploadsFolderPath = Path.Combine(grandParentName, "AlmuzainiCMS", "wwwroot", folderName);

                string middleSliderfolderPath = Path.Combine(middleSlideruploadsFolderPath, subfolder, middleSlider);  
                
                string[] middleSliderfileNames;
                if (Directory.Exists(middleSliderfolderPath))
                {
                    middleSliderfileNames = Directory.GetFiles(middleSliderfolderPath)
                       .Select(Path.GetFileName)
                       .ToArray();

                    
                }
                else
                {
                    middleSliderfileNames = new string[0]; // No files available
                }

                string roundButtons = "RoundButtons";
                string roundButtonsuploadsFolderPath = Path.Combine(grandParentName, "AlmuzainiCMS", "wwwroot", folderName);

                string roundButtonsploadsPath = Path.Combine(roundButtonsuploadsFolderPath, subfolder, roundButtons);   

                string[] roundButtonsfileNames;
                if (Directory.Exists(roundButtonsploadsPath))
                {
                    roundButtonsfileNames = Directory.GetFiles(roundButtonsploadsPath)
                       .Select(Path.GetFileName)
                       .ToArray();


                }
                else
                {
                    roundButtonsfileNames = new string[0]; // No files available
                }


                string lastSlider = "LastSlider";
                string lastSliderFolderPath = Path.Combine(grandParentName, "AlmuzainiCMS", "wwwroot", folderName);

                string lastSliderUploadsPath = Path.Combine(lastSliderFolderPath, subfolder, lastSlider);

                string[] lastSliderfileNames;
                if (Directory.Exists(lastSliderUploadsPath))
                {
                    lastSliderfileNames = Directory.GetFiles(lastSliderUploadsPath)
                       .Select(Path.GetFileName)
                       .ToArray();


                }
                else
                {
                    lastSliderfileNames = new string[0]; // No files available
                }

                string videos = "VideoImageThumb";
                string videosFolderPath = Path.Combine(grandParentName, "AlmuzainiCMS", "wwwroot", folderName);

                string videosPath = Path.Combine(videosFolderPath, subfolder, videos);

                string[] videofileNames;
                if (Directory.Exists(videosPath))
                {
                    videofileNames = Directory.GetFiles(videosPath)
                       .Select(Path.GetFileName)
                       .ToArray();


                }
                else
                {
                    videofileNames = new string[0]; // No files available
                }

                List<News> news = _newsManager.GetAllNews();

                List<LatestNews> latestNewsList = new List<LatestNews>();

                foreach (News newsItem in news)
                {

                    TimeSpan timeDifference = DateTime.Now - newsItem.CreatedAt;

                    int days = timeDifference.Days;
                    int hours = timeDifference.Hours;

                    int minutes = timeDifference.Minutes;
                    int seconds = timeDifference.Seconds;

                    string updatedAt = days > 1 ? days.ToString() + " days ago" : days == 1 ? " yesterday" : hours > 1 ? hours.ToString() + " hours ago" : hours == 1 ? hours.ToString() + " hour ago" : minutes > 1 ? minutes.ToString() + " minutes ago" : minutes == 1 ? minutes.ToString() + " minute ago" : seconds.ToString() + " seconds ago";



                    LatestNews latestNews = new LatestNews
                    {
                        Id = newsItem.Id,
                        Title = newsItem.Title,
                        Description = newsItem.Description,
                        ImagePath = Path.GetFileName(newsItem.ImagePath),

                        UpdatedAt = updatedAt
                    };

                    latestNewsList.Add(latestNews);


                }

                HomeContentModel home = new HomeContentModel
                {
                    SliderFileNames = sliderfileNames,
                    RateCalculatorFileNames = ratefileNames,  
                    MiddleSliderFileNames = middleSliderfileNames,  
                    RoundButtonsFileNames = roundButtonsfileNames,
                    LastSliderFileNames = lastSliderfileNames,
                    VideosFileNames = videofileNames,
                    LatestNews = latestNewsList
                };




                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Home Content Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(home).ToString();
                objResponse.ResponseCode = 200;

                return objResponse;
            }
            catch (Exception ex)
            {
                objResponse.ResponseStatus = false;
                objResponse.ResponseCode = 500;
                objResponse.ErrMsg = (ex.InnerException != null) ? ex.GetBaseException().Message : ex.Message;
                return objResponse;
            }
        }

        //public string[] GetFilePaths(string folderName, string subfolder, string typefolder)
        //{
        //    string rootpath = _hostingEnvironment.ContentRootPath;

        //    var parentName = Directory.GetParent(rootpath).FullName;
        //    var grandParentName = Directory.GetParent(parentName).FullName;
        //    string uploadsFolderPath = Path.Combine(grandParentName, "AlmuzainiCMS", "wwwroot", folderName);

        //    string folderPath = Path.Combine(uploadsFolderPath, subfolder, typefolder);
        //    // Replace with the actual folder path

        //    string[] fileNames;
        //    if (Directory.Exists(folderPath))
        //    {
        //        fileNames = Directory.GetFiles(folderPath)
        //           .Select(Path.GetFileName)
        //           .ToArray();

        //        // fileNames;
        //    }
        //    else
        //    {
        //        fileNames = new string[0]; // No files available
        //    }

        //    return fileNames;

        //}



        [HttpGet(Name = "GetTopSlider")]
        public APIServiceResponse GetTopSlider()
        {
            //var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            // var assemblyPath = Assembly.GetExecutingAssembly().GetReferencedAssemblies()[0].CodeBase;
            //string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            //UriBuilder uri = new UriBuilder(codeBase);
            //var assemblyPath = Path.GetDirectoryName(Uri.UnescapeDataString(uri.Path));

            APIServiceResponse objResponse = new APIServiceResponse();
         
            string rootpath = _hostingEnvironment.ContentRootPath;
            string folderName = "uploads";
            string subfolder = "original";
            string typefolder = "TopSlider";

            var parentName = Directory.GetParent(rootpath).FullName;
            var grandParentName = Directory.GetParent(parentName).FullName;
            string uploadsFolderPath = Path.Combine(grandParentName, "AlmuzainiCMS", "wwwroot", folderName);

            string folderPath = Path.Combine(uploadsFolderPath, subfolder, typefolder);
            // Replace with the actual folder path
            string[] fileNames;
            if (Directory.Exists(folderPath))
            {
                fileNames = Directory.GetFiles(folderPath)
                   .Select(Path.GetFileName)
                   .ToArray();

                // fileNames;
            }
            else
            {
                fileNames = new string[0]; // No files available
            }

            objResponse.ResponseStatus = true;
            objResponse.ResponseDateTime = DateTime.Now.ToString();
            objResponse.SuccessMsg = "Top Slider fetched Successfully!";
            objResponse.ResponseBusinessData = JsonConvert.SerializeObject(fileNames).ToString();
            objResponse.ResponseCode = 200;

            return objResponse;




        }


      

        [HttpGet(Name = "GetRateCalculator")]
        public APIServiceResponse GetRateCalculator()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            string rootpath = _hostingEnvironment.ContentRootPath;
            string folderName = "uploads";
            string subfolder = "original";
            string typefolder = "RateCalculator";

            var parentName = Directory.GetParent(rootpath).FullName;
            var grandParentName = Directory.GetParent(parentName).FullName;
            string uploadsFolderPath = Path.Combine(grandParentName, "AlmuzainiCMS", "wwwroot", folderName);

            string folderPath = Path.Combine(uploadsFolderPath, subfolder, typefolder);        
            string[] fileNames;
            if (Directory.Exists(folderPath))
            {
                fileNames = Directory.GetFiles(folderPath)
                   .Select(Path.GetFileName)
                   .ToArray();

                // fileNames;
            }
            else
            {
                fileNames = new string[0]; // No files available
            }

            objResponse.ResponseStatus = true;
            objResponse.ResponseDateTime = DateTime.Now.ToString();
            objResponse.SuccessMsg = "Rate Calculator fetched Successfully!";
            objResponse.ResponseBusinessData = JsonConvert.SerializeObject(fileNames).ToString();
            objResponse.ResponseCode = 200;

            return objResponse;



        }

        [HttpGet(Name = "MiddleSlider")]

        public async Task<APIServiceResponse> MiddleSlider()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            try
            {
                ICollection<HomeMidSlide> homeMidSlide = new List<HomeMidSlide>();
                homeMidSlide = _homeManager.GetHomeMidSlide();
                objResponse.ResponseStatus = true;
                objResponse.ResponseDateTime = DateTime.Now.ToString();
                objResponse.SuccessMsg = "Fetched Branch Details Successfully!";
                objResponse.ResponseBusinessData = JsonConvert.SerializeObject(homeMidSlide).ToString();
                objResponse.ResponseCode = 200;

                return objResponse;

            }
            catch (Exception ex)
            {
                throw;
            }

        }




        [HttpGet(Name = "GetRoundButtons")]

        public APIServiceResponse GetRoundButtons()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            string rootpath = _hostingEnvironment.ContentRootPath;
            string folderName = "uploads";
            string subfolder = "original";
            string typefolder = "RoundButtons";

            var parentName = Directory.GetParent(rootpath).FullName;
            var grandParentName = Directory.GetParent(parentName).FullName;
            string uploadsFolderPath = Path.Combine(grandParentName, "AlmuzainiCMS", "wwwroot", folderName);

            string folderPath = Path.Combine(uploadsFolderPath, subfolder, typefolder);
            string[] fileNames;
            if (Directory.Exists(folderPath))
            {
                fileNames = Directory.GetFiles(folderPath)
                   .Select(Path.GetFileName)
                   .ToArray();

                // fileNames;
            }
            else
            {
                fileNames = new string[0]; // No files available
            }

            objResponse.ResponseStatus = true;
            objResponse.ResponseDateTime = DateTime.Now.ToString();
            objResponse.SuccessMsg = "Round Buttons fetched Successfully!";
            objResponse.ResponseBusinessData = JsonConvert.SerializeObject(fileNames).ToString();
            objResponse.ResponseCode = 200;

            return objResponse;


        }
        [HttpGet(Name = "GetLastSlider")]

        public APIServiceResponse GetLastSlider()
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            string rootpath = _hostingEnvironment.ContentRootPath;
            string folderName = "uploads";
            string subfolder = "original";
            string typefolder = "LastSlider";

            var parentName = Directory.GetParent(rootpath).FullName;
            var grandParentName = Directory.GetParent(parentName).FullName;
            string uploadsFolderPath = Path.Combine(grandParentName, "AlmuzainiCMS", "wwwroot", folderName);

            string folderPath = Path.Combine(uploadsFolderPath, subfolder, typefolder);
            string[] fileNames;
            if (Directory.Exists(folderPath))
            {
                fileNames = Directory.GetFiles(folderPath)
                   .Select(Path.GetFileName)
                   .ToArray();

                // fileNames;
            }
            else
            {
                fileNames = new string[0]; // No files available
            }

            objResponse.ResponseStatus = true;
            objResponse.ResponseDateTime = DateTime.Now.ToString();
            objResponse.SuccessMsg = "Last Slider fetched Successfully!";
            objResponse.ResponseBusinessData = JsonConvert.SerializeObject(fileNames).ToString();
            objResponse.ResponseCode = 200;

            return objResponse;

        }
        [HttpGet(Name = "GetVideos")]

        public APIServiceResponse GetVideos()  
        {
            APIServiceResponse objResponse = new APIServiceResponse();
            string rootpath = _hostingEnvironment.ContentRootPath;
            string folderName = "uploads";
            string subfolder = "original";
            string typefolder = "VideoImageThumb";

            var parentName = Directory.GetParent(rootpath).FullName;
            var grandParentName = Directory.GetParent(parentName).FullName;
            string uploadsFolderPath = Path.Combine(grandParentName, "AlmuzainiCMS", "wwwroot", folderName);

            string folderPath = Path.Combine(uploadsFolderPath, subfolder, typefolder);
            string[] fileNames;
            if (Directory.Exists(folderPath))
            {
                fileNames = Directory.GetFiles(folderPath)
                   .Select(Path.GetFileName)
                   .ToArray();

                // fileNames;
            }
            else
            {
                fileNames = new string[0]; // No files available
            }

            objResponse.ResponseStatus = true;
            objResponse.ResponseDateTime = DateTime.Now.ToString();
            objResponse.SuccessMsg = "Videos fetched Successfully!";
            objResponse.ResponseBusinessData = JsonConvert.SerializeObject(fileNames).ToString();
            objResponse.ResponseCode = 200;

            return objResponse;
        }

        [HttpGet(Name = "GetLatestNews")]

        public APIServiceResponse GetLatestNews()
        {
            APIServiceResponse objResponse = new APIServiceResponse();

            List<News> news = _newsManager.GetAllNews();

            List<LatestNews> latestNewsList = new List<LatestNews>();

            foreach (News newsItem in news)
            {

                TimeSpan timeDifference = DateTime.Now - newsItem.CreatedAt;

                int days = timeDifference.Days;
                int hours = timeDifference.Hours;

                int minutes = timeDifference.Minutes;
                int seconds = timeDifference.Seconds;

                string updatedAt = days > 1 ? days.ToString() + " days ago" : days == 1 ? " yesterday" : hours > 1 ? hours.ToString() + " hours ago" : hours == 1 ? hours.ToString() + " hour ago" : minutes > 1 ? minutes.ToString() + " minutes ago" : minutes == 1 ? minutes.ToString() + " minute ago" : seconds.ToString() + " seconds ago";



                LatestNews latestNews = new LatestNews
                {
                    Id = newsItem.Id,
                    Title = newsItem.Title,
                    Description = newsItem.Description,
                    ImagePath = Path.GetFileName(newsItem.ImagePath),

                    UpdatedAt = updatedAt
                };

                latestNewsList.Add(latestNews);


            }

            //return latestNewsList; // No files available

            objResponse.ResponseStatus = true;
            objResponse.ResponseDateTime = DateTime.Now.ToString();
            objResponse.SuccessMsg = "Latest News fetched Successfully!";
            objResponse.ResponseBusinessData = JsonConvert.SerializeObject(latestNewsList).ToString();
            objResponse.ResponseCode = 200;

            return objResponse;

        }




    }
}
