using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models;
using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models.RequestDto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlmuzainiCMS.Controllers
{
    public class AboutController : Controller
    {
        private readonly ILogger<AboutController> _logger;

        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ICompanyHistoryManager _companyHistoryManager; 

        public AboutController(ILogger<AboutController> logger, IMapper mapper, IWebHostEnvironment webHostEnvironment, ICompanyHistoryManager companyHistoryManager)
        {
            _logger = logger;
            _mapper = mapper;
            _hostingEnvironment = webHostEnvironment;
            _companyHistoryManager = companyHistoryManager;  
        }

        public IActionResult Index()
        {
            return View();
        }

        public  IActionResult CompanyHistory()
        {
            GetCompanyProfileBanner("uploads", "original", "CompanyHistory", "CompanyProfileBanner");
            GetCompanyHistoryImage("uploads", "original", "CompanyHistory", "CompanyHistoryImage");
            GetCompanyHistorySection();
            return View();
        }

        [HttpPost]
        public IActionResult UploadCompanyHistoryCompanyProfile(MultipleFileUploadVM model)  
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
            string filePath = Path.Combine(uploadsFolder, "original", "CompanyHistory", "CompanyProfileBanner");
            //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");

            string filePosition = model.position;

            //DeleteAllFilesOfFolder(filePath, filePosition);
            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);
            

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
                    string filePathToSave = string.Empty;
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
            var response = new
            {
                Success = true,
                Message = "File uploaded successfully.",
                redirectUrl = Url.Action("CompanyHistory", "About")
            };


            return Json(response);
        }

        [HttpPost]
        public IActionResult UploadCompanyHistoryImage(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Uploads");
            string filePath = Path.Combine(uploadsFolder, "original", "CompanyHistory", "CompanyHistoryImage");
            //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");

            string filePosition = model.position;

            //DeleteAllFilesOfFolder(filePath, filePosition);
            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);


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
                    string filePathToSave = string.Empty;
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
            var response = new
            {
                Success = true,
                Message = "File uploaded successfully.",
                redirectUrl = Url.Action("CompanyHistory", "About")
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

        public void GetCompanyProfileBanner(string folderName, string subfolder, string typefolder , string filetypefolder)  
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder, filetypefolder);
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToArray();

                ViewBag.BrandImageFileNames = fileNames;
            }
            else
            {
                ViewBag.BrandImageFileNames = new string[0]; // No files available
            }

        }

        public void GetCompanyHistoryImage(string folderName, string subfolder, string typefolder, string filetypefolder)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder, filetypefolder);
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToArray();

                ViewBag.CompanyHistoryFileNames = fileNames;
            }
            else
            {
                ViewBag.CompanyHistoryFileNames = new string[0]; // No files available
            }

        }

        [HttpPost]
        public async Task<JsonResult> UpdateCompanyHistorySection(CompanyHistoryRequestDTO model)   
        {
            var companyHistory = _mapper.Map<CompanyHistory>(model);
            var result = await _companyHistoryManager.UpdateCompanyHistorySection(companyHistory);  
          
            var response = new
            {
                Success = true,
                Message = "Company History section updated successfully.",
                redirectUrl = Url.Action("CompanyHistory", "About")
            };


            return Json(response);
        }

        public async void GetCompanyHistorySection()
        {
            CompanyHistory companyHistory = await _companyHistoryManager.GetCompanyHistorySection();

            ViewBag.FirstSection = companyHistory.FirstSection ?? "";
            ViewBag.SecondSection = companyHistory.SecondSection ?? "";
            ViewBag.ThirdSection = companyHistory.ThirdSection ?? "";
            ViewBag.FourthSection = companyHistory.FourthSection ?? "";



        }


    }
}
