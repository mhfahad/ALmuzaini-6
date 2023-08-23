﻿using AlmuzainiCMS.BLL.Interface;
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
            GetCompanyExpertiseImage("uploads", "original", "CompanyHistory", "ExpertiseImage");
            GetCompanyWorkforceImage("uploads", "original", "CompanyHistory", "WorkforceImage");
            GetCompanyTechnologyImage("uploads", "original", "CompanyHistory", "TechnologyImage");
            GetCompanyHistory();
            return View();
        }

        

        [HttpPost]
        public async Task<JsonResult> UploadCompanyHistoryCompanyProfile(MultipleFileUploadVM model)  
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "CompanyHistory", "CompanyProfileBanner");
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
                    string fileExtension = Path.GetExtension(file.FileName);

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
            var companyProfileBannerImagePath = filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
            CompanyHistory companyHistory = new CompanyHistory();
            companyHistory.CompanyProfileBannerImagePath = companyProfileBannerImagePath;
            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _companyHistoryManager.UpdateCompanyProfileBannerImagePath(companyHistory);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Company Profile image updated successfully.",
                    redirectUrl = Url.Action("CompanyHistory", "About")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Company Profile image updated failed.",
                    redirectUrl = Url.Action("CompanyHistory", "About")
                };
                return Json(response);
            }

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

        [HttpPost]
        public async Task<JsonResult> UpdateExpertise(CompanyHistoryRequestDTO model)
        {
            var companyHistory  = _mapper.Map<CompanyHistory>(model);
           
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads",  "original", "CompanyHistory", "ExpertiseImage");
            string filePosition = "1";

            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);
            string filePathToSave = string.Empty;

            var file = model.ExpertiseImageFile;

            if (file != null && file.Length > 0)
            {

                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string fileExtension = Path.GetExtension(file.FileName);

                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    
                   
                    filePathToSave = Path.Combine(filePath, filePosition + fileExtension);
                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                            file.CopyTo(fileStream);
                    }

            }

            var expertiseImagePath =  filePathToSave.Substring(uploadsFolder.Length).Replace("\\","/");
            companyHistory.ExpertiseImagePath = expertiseImagePath;
            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _companyHistoryManager.UpdateExpertise(companyHistory);

            if(result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Expertise updated successfully.",
                    redirectUrl = Url.Action("CompanyHistory", "About")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Expertise updated failed.",
                    redirectUrl = Url.Action("CompanyHistory", "About")
                };
                return Json(response);
            }
           
           
        }

        [HttpPost]
        public async Task<JsonResult> UpdateWorkforce(CompanyHistoryRequestDTO model)   
        {
            var companyHistory = _mapper.Map<CompanyHistory>(model);

            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "CompanyHistory", "WorkforceImage");
            string filePosition = "1";

            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);
            string filePathToSave = string.Empty;

            var file = model.WorkforceImageFile;

            if (file != null && file.Length > 0)
            {

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string fileExtension = Path.GetExtension(file.FileName);

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }


                filePathToSave = Path.Combine(filePath, filePosition + fileExtension);
                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

            }

            var workforceImagePath = filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
            companyHistory.WorkforceImagePath = workforceImagePath;
            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _companyHistoryManager.UpdateWorkforce(companyHistory);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Workforce updated successfully.",
                    redirectUrl = Url.Action("CompanyHistory", "About")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Workforce updated failed.",
                    redirectUrl = Url.Action("CompanyHistory", "About")
                };
                return Json(response);
            }


        }

        [HttpPost]
        public async Task<JsonResult> UpdateTechnology(CompanyHistoryRequestDTO model)
        {
            var companyHistory = _mapper.Map<CompanyHistory>(model);

            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "CompanyHistory", "TechnologyImage");
            string filePosition = "1";

            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);
            string filePathToSave = string.Empty;

            var file = model.TechnologyImageFile;

            if (file != null && file.Length > 0)
            {

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string fileExtension = Path.GetExtension(file.FileName);

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }


                filePathToSave = Path.Combine(filePath, filePosition + fileExtension);
                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

            }

            var technologyImagePath = filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
            companyHistory.TechnologyImagePath = technologyImagePath;
            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _companyHistoryManager.UpdateTechnology(companyHistory);    



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Technology updated successfully.",
                    redirectUrl = Url.Action("CompanyHistory", "About")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Technology updated failed.",
                    redirectUrl = Url.Action("CompanyHistory", "About")
                };
                return Json(response);
            }


        }

        [HttpPost]
        public async Task<JsonResult>  UploadCompanyHistoryImage(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "CompanyHistory", "CompanyHistoryImage");
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
                    string fileExtension = Path.GetExtension(file.FileName);

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
            var companyHistoryImagePath = filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
            CompanyHistory companyHistory = new CompanyHistory();
            companyHistory.CompanyHistoryImagePath = companyHistoryImagePath;
            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _companyHistoryManager.UpdateCompanyHistoryImagePath(companyHistory);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Company History image updated successfully.",
                    redirectUrl = Url.Action("CompanyHistory", "About")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Company History image updated failed.",
                    redirectUrl = Url.Action("CompanyHistory", "About")
                };
                return Json(response);
            }


           
        }

        public void GetCompanyProfileBanner(string folderName, string subfolder, string typefolder, string filetypefolder)
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

        public void GetCompanyExpertiseImage(string folderName, string subfolder, string typefolder, string filetypefolder)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder, filetypefolder);
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string? fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .First();

                ViewBag.ExpertiseImageFile = fileNames;
            }
            else
            {
                ViewBag.ExpertiseImageFile = new string[0]; // No files available
            }

        }

        public void GetCompanyWorkforceImage(string folderName, string subfolder, string typefolder, string filetypefolder)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder, filetypefolder);
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string? fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .First();

                ViewBag.WorkforceImageFile = fileNames;
            }
            else
            {
                ViewBag.WorkforceImageFile = new string[0]; // No files available
            }

        }

        //
        public void GetCompanyTechnologyImage(string folderName, string subfolder, string typefolder, string filetypefolder)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder, filetypefolder);
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string? fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .First();

                ViewBag.TechnologyImageFile = fileNames;
            }
            else
            {
                ViewBag.TechnologyImageFile = new string[0]; // No files available
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
        public async void GetCompanyHistory()
        {
            CompanyHistory companyHistory = await _companyHistoryManager.GetCompanyHistorySection();

            ViewBag.FirstSection = companyHistory.FirstSection ?? "";
            ViewBag.SecondSection = companyHistory.SecondSection ?? "";
            ViewBag.ThirdSection = companyHistory.ThirdSection ?? "";
            ViewBag.FourthSection = companyHistory.FourthSection ?? "";
            ViewBag.ExpertiseText = companyHistory.ExpertiseText ?? "";
            ViewBag.WorkforceText = companyHistory.WorkforceText ?? "";
            ViewBag.TechnologyText = companyHistory.TechnologyText ?? "";

        }


    }
}