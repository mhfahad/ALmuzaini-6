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
        private readonly IChairmanMessageManager _chairmanMessageManager;
        private readonly IMissionVisionValuesManager _missionVisionValuesManager; 


        public AboutController(ILogger<AboutController> logger, IMapper mapper, IWebHostEnvironment webHostEnvironment,
            ICompanyHistoryManager companyHistoryManager,IChairmanMessageManager chairmanMessageManager ,IMissionVisionValuesManager missionVisionValuesManager)
        {
            _logger = logger;
            _mapper = mapper;
            _hostingEnvironment = webHostEnvironment;
            _companyHistoryManager = companyHistoryManager;  
            _missionVisionValuesManager = missionVisionValuesManager;
            _chairmanMessageManager = chairmanMessageManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public  IActionResult CompanyHistory()
        {
           
            GetCompanyHistory();
            return View();

            //GetCompanyProfileBanner("uploads", "original", "CompanyHistory", "CompanyProfileBanner");
            //GetCompanyHistoryImage("uploads", "original", "CompanyHistory", "CompanyHistoryImage");
            //GetCompanyExpertiseImage("uploads", "original", "CompanyHistory", "ExpertiseImage");
            //GetCompanyWorkforceImage("uploads", "original", "CompanyHistory", "WorkforceImage");
            //GetCompanyTechnologyImage("uploads", "original", "CompanyHistory", "TechnologyImage");
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
            var companyProfileBannerImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
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
                    string fileExtension = ".webp";

                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    
                   
                    filePathToSave = Path.Combine(filePath, filePosition + fileExtension);
                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                            file.CopyTo(fileStream);
                    }
                var expertiseImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
                companyHistory.ExpertiseImagePath = expertiseImagePath;
            }

            
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
                string fileExtension = ".webp";

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }


                filePathToSave = Path.Combine(filePath, filePosition + fileExtension);
                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                var workforceImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
                companyHistory.WorkforceImagePath = workforceImagePath;
            }

            
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
                string fileExtension = ".webp";

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }


                filePathToSave = Path.Combine(filePath, filePosition + fileExtension);
                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                var technologyImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
                companyHistory.TechnologyImagePath = technologyImagePath;
            }

           
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
            var companyHistoryImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
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

       
        public async void GetCompanyHistory()
        {
            CompanyHistory companyHistory = new CompanyHistory(); 
            companyHistory = await _companyHistoryManager.GetCompanyHistorySection();

            ViewBag.FirstSection = companyHistory?.FirstSection ?? "";
            ViewBag.SecondSection = companyHistory?.SecondSection ?? "";
            ViewBag.ThirdSection = companyHistory?.ThirdSection ?? "";
            ViewBag.FourthSection = companyHistory?.FourthSection ?? "";
            ViewBag.ExpertiseText = companyHistory?.ExpertiseText ?? "";
            ViewBag.WorkforceText = companyHistory?.WorkforceText ?? "";
            ViewBag.TechnologyText = companyHistory?.TechnologyText ?? "";
            ViewBag.BrandImageFileNames = companyHistory?.CompanyProfileBannerImagePath ?? "";
            ViewBag.ExpertiseImageFile = companyHistory?.ExpertiseImagePath ?? "";
            ViewBag.WorkforceImageFile = companyHistory?.WorkforceImagePath ?? "";
            ViewBag.TechnologyImageFile = companyHistory?.TechnologyImagePath ?? "";
            ViewBag.CompanyHistoryFileNames  = companyHistory?.CompanyHistoryImagePath ?? "";

        }
        
        [HttpGet]
        public IActionResult ChairmansMessage()  
        {
            GetChairmansMessage();

            return View();
        }

        private async void GetChairmansMessage()
        {
            ChairmanMessage chairmanMessage = new ChairmanMessage();
            chairmanMessage = await _chairmanMessageManager.GetChairmanMessage();

            ViewBag.ChairmanMessageBannerImageFile = chairmanMessage?.ChairmanMessageBannerImagePath ?? "";
            ViewBag.ChairmanName = chairmanMessage?.ChairmanName ?? "";
            ViewBag.Designation = chairmanMessage?.Designation ?? "";
            ViewBag.ChairmanImagePath = chairmanMessage?.ChairmanImagePath ?? "";
            ViewBag.FirstSection = chairmanMessage?.FirstSection ?? "";
            ViewBag.SecondSection = chairmanMessage?.SecondSection ?? "";
            ViewBag.ThirdSection = chairmanMessage?.ThirdSection ?? "";
            ViewBag.FourthSection = chairmanMessage?.FourthSection ?? "";
            ViewBag.FifthSection = chairmanMessage?.FifthSection ?? "";
            ViewBag.SixthSection = chairmanMessage?.SixthSection ?? "";
            ViewBag.SeventhSection = chairmanMessage?.SeventhSection ?? "";    
        }

        [HttpPost]
        public async Task<JsonResult> UpdateChairmanMessageBanner(ChairmansMessageRequestDTO model)
        {
            var chairmanMessage = _mapper.Map<ChairmanMessage>(model);
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "ChairmanMessage", "ChairmanMessageBanner");
            string filePosition = "1";

            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);
            string filePathToSave = string.Empty;

            var file = model.ChairmanMessageBannerImageFile;

            if (file != null && file.Length > 0)
            {

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string fileExtension = ".webp";

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }


                filePathToSave = Path.Combine(filePath, filePosition + fileExtension);
                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                var chairmanMessageBannerImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
                chairmanMessage.ChairmanMessageBannerImagePath = chairmanMessageBannerImagePath;
            }


            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _chairmanMessageManager.UpdateChairmanMessageBanner(chairmanMessage);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Chairman Message Banner updated successfully.",
                    redirectUrl = Url.Action("ChairmansMessage", "About")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Chairman Message Banner updated failed.",
                    redirectUrl = Url.Action("ChairmansMessage", "About")
                };
                return Json(response);
            }

        }



        [HttpPost]
        public async Task<JsonResult> UpdateChairmanInfo(ChairmansMessageRequestDTO model)
        {
            var chairmanMessage  = _mapper.Map<ChairmanMessage>(model);

            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "ChairmansMessage", "ChairmanImage");
            string filePosition = "1";

            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);
            string filePathToSave = string.Empty;

            var file = model.ChairmanImageFile;

            if (file != null && file.Length > 0)
            {

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                //string fileExtension = Path.GetExtension(file.FileName);
                string fileExtension = ".webp";

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }


                filePathToSave = Path.Combine(filePath, filePosition + fileExtension);
                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                var chairmanImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
                chairmanMessage.ChairmanImagePath = chairmanImagePath;
            }

           
            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _chairmanMessageManager.UpdateChairmanInfo(chairmanMessage);

            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Chairman info updated successfully.",
                    redirectUrl = Url.Action("ChairmansMessage", "About")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Chairman info updated failed.",
                    redirectUrl = Url.Action("ChairmansMessage", "About")
                };
                return Json(response);
            }


        }


        [HttpPost]
        public async Task<JsonResult> UpdateChairmanMessage(ChairmansMessageRequestDTO model)
        {
            var chairmanMessage = _mapper.Map<ChairmanMessage>(model);
            bool result = await _chairmanMessageManager.UpdateChairmanMessage(chairmanMessage);

            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Chairman Message updated successfully.",
                    redirectUrl = Url.Action("ChairmansMessage", "About")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Chairman Message updated failed.",
                    redirectUrl = Url.Action("ChairmansMessage", "About")
                };
                return Json(response);
            }
        }

        [HttpGet]
        public IActionResult MissionVisionValues()
        {
            GetMissionVisionValues();
            return View();
        }

        private async void GetMissionVisionValues()
        {
            MissionVisionValues missionVisionValues = new MissionVisionValues();

            //bool valueExists = await _missionVisionValuesManager.MissionVisionValuesExists();
            //if (valueExists)
            //{
               
            //}

            missionVisionValues = await _missionVisionValuesManager.GetMissionVisionValues();
            ViewBag.MissionVisionValuesBannerImageFileName = missionVisionValues?.MissionVisionBannerImagePath ?? "";
            ViewBag.VisionText = missionVisionValues?.VisionText;
            ViewBag.VisionImagePath = missionVisionValues?.VisionImagePath;
            ViewBag.MissionText = missionVisionValues?.MissionText;
            ViewBag.MissionImagePath = missionVisionValues?.MissionImagePath;
            ViewBag.ValuesImagePath = missionVisionValues?.ValuesImagePath;
            ViewBag.ValuesText = missionVisionValues?.ValuesText;
        
        
        
        
        
        
        
        
        }

        [HttpPost]
        public async Task<JsonResult> UpdateMissionBanner(MissionVisionValuesRequestDTO model)
        {
            var missionVisionValues = _mapper.Map<MissionVisionValues>(model);
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "MissionVisionValues", "MissionVisionValuesBanner");
            string filePosition = "1";

            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);
            string filePathToSave = string.Empty;

            var file = model.MissionVisionBannerImageFile;

            if (file != null && file.Length > 0)
            {

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string fileExtension = ".webp";

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }


                filePathToSave = Path.Combine(filePath, filePosition + fileExtension);
                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                var missionVisionBannerImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
                missionVisionValues.MissionVisionBannerImagePath = missionVisionBannerImagePath;
            }


            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _missionVisionValuesManager.UpdateMissionVisionValuesBanner(missionVisionValues);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Mission Vision Values Banner updated successfully.",
                    redirectUrl = Url.Action("MissionVisionValues", "About")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Mission Vision Values Banner updated failed.",
                    redirectUrl = Url.Action("MissionVisionValues", "About")
                };
                return Json(response);
            }

        }


        [HttpPost]
        public async Task<JsonResult> UpdateVision(MissionVisionValuesRequestDTO model)
        {
            var missionVisionValues = _mapper.Map<MissionVisionValues>(model);

            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "MissionVisionValues", "OurVision");
            string filePosition = "1";

            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);
            string filePathToSave = string.Empty;

            var file = model.VisionImageFile;

            if (file != null && file.Length > 0)
            {

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string fileExtension = ".webp";

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }


                filePathToSave = Path.Combine(filePath, filePosition + fileExtension);
                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                var visionImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
                missionVisionValues.VisionImagePath = visionImagePath;
            }


            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _missionVisionValuesManager.UpdateVision(missionVisionValues);

            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Our Vision updated successfully.",
                    redirectUrl = Url.Action("MissionVisionValues", "About")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Our Vision updated failed.",
                    redirectUrl = Url.Action("MissionVisionValues", "About")
                };
                return Json(response);
            }


        }


        [HttpPost]
        public async Task<JsonResult> UpdateMission(MissionVisionValuesRequestDTO model)   
        {
            var missionVisionValues = _mapper.Map<MissionVisionValues>(model);

            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "MissionVisionValues", "OurMission");
            string filePosition = "1";

            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);
            string filePathToSave = string.Empty;

            var file = model.MissionImageFile;

            if (file != null && file.Length > 0)
            {

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string fileExtension = ".webp";

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }


                filePathToSave = Path.Combine(filePath, filePosition + fileExtension);
                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                var missionImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
                missionVisionValues.MissionImagePath = missionImagePath;
            }


            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _missionVisionValuesManager.UpdateMission(missionVisionValues);

            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Our Mission updated successfully.",
                    redirectUrl = Url.Action("MissionVisionValues", "About")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Our Mission updated failed.",
                    redirectUrl = Url.Action("MissionVisionValues", "About")
                };
                return Json(response);
            }


        }

        [HttpPost]
        public async Task<JsonResult> UpdateValues(MissionVisionValuesRequestDTO model)
        {
            var missionVisionValues = _mapper.Map<MissionVisionValues>(model);

            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "MissionVisionValues", "OurValues");
            string filePosition = "1";

            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);
            string filePathToSave = string.Empty;

            var file = model.ValuesImageFile;

            if (file != null && file.Length > 0)
            {

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string fileExtension = ".webp";

                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }


                filePathToSave = Path.Combine(filePath, filePosition + fileExtension);
                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
                var valuesImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
                missionVisionValues.ValuesImagePath = valuesImagePath;
            }


            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _missionVisionValuesManager.UpdateValues(missionVisionValues);

            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Our Values updated successfully.",
                    redirectUrl = Url.Action("MissionVisionValues", "About")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Our Values updated failed.",
                    redirectUrl = Url.Action("MissionVisionValues", "About")
                };
                return Json(response);
            }


        }

        //public void GetCompanyProfileBanner(string folderName, string subfolder, string typefolder, string filetypefolder)
        //{
        //    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
        //    string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder, filetypefolder);
        //    // Replace with the actual folder path

        //    if (Directory.Exists(folderPath))
        //    {
        //        string[] fileNames = Directory.GetFiles(folderPath)
        //            .Select(Path.GetFileName)
        //            .ToArray();

        //        ViewBag.BrandImageFileNames = fileNames;
        //    }
        //    else
        //    {
        //        ViewBag.BrandImageFileNames = new string[0]; // No files available
        //    }

        //}

        //public void GetCompanyExpertiseImage(string folderName, string subfolder, string typefolder, string filetypefolder)
        //{
        //    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
        //    string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder, filetypefolder);
        //    // Replace with the actual folder path

        //    if (Directory.Exists(folderPath))
        //    {
        //        string? fileNames = Directory.GetFiles(folderPath)
        //            .Select(Path.GetFileName)
        //            .First();

        //        ViewBag.ExpertiseImageFile = fileNames;
        //    }
        //    else
        //    {
        //        ViewBag.ExpertiseImageFile = new string[0]; // No files available
        //    }

        //}

        //public void GetCompanyWorkforceImage(string folderName, string subfolder, string typefolder, string filetypefolder)
        //{
        //    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
        //    string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder, filetypefolder);
        //    // Replace with the actual folder path

        //    if (Directory.Exists(folderPath))
        //    {
        //        string? fileNames = Directory.GetFiles(folderPath)
        //            .Select(Path.GetFileName)
        //            .First();

        //        ViewBag.WorkforceImageFile = fileNames;
        //    }
        //    else
        //    {
        //        ViewBag.WorkforceImageFile = new string[0]; // No files available
        //    }

        //}

        ////
        //public void GetCompanyTechnologyImage(string folderName, string subfolder, string typefolder, string filetypefolder)
        //{
        //    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
        //    string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder, filetypefolder);
        //    // Replace with the actual folder path

        //    if (Directory.Exists(folderPath))
        //    {
        //        string? fileNames = Directory.GetFiles(folderPath)
        //            .Select(Path.GetFileName)
        //            .First();

        //        ViewBag.TechnologyImageFile = fileNames;
        //    }
        //    else
        //    {
        //        ViewBag.TechnologyImageFile = new string[0]; // No files available
        //    }

        //}
        //public void GetCompanyHistoryImage(string folderName, string subfolder, string typefolder, string filetypefolder)
        //{
        //    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
        //    string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder, filetypefolder);
        //    // Replace with the actual folder path

        //    if (Directory.Exists(folderPath))
        //    {
        //        string[] fileNames = Directory.GetFiles(folderPath)
        //            .Select(Path.GetFileName)
        //            .ToArray();

        //        ViewBag.CompanyHistoryFileNames = fileNames;
        //    }
        //    else
        //    {
        //        ViewBag.CompanyHistoryFileNames = new string[0]; // No files available
        //    }

        //}



    }
}
