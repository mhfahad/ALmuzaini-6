using AlmuzainiCMS.BLL.BLL;
using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models;
using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models.RequestDto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AlmuzainiCMS.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ILogger<ServicesController> _logger;

        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IForeignCurrencyManager _foreignCurrencyManager;

        public ServicesController(ILogger<ServicesController> logger, IMapper mapper, IWebHostEnvironment webHostEnvironment,
            IForeignCurrencyManager foreignCurrencyManager)   
        {
            _logger = logger;
            _mapper = mapper;
            _hostingEnvironment = webHostEnvironment;
            _foreignCurrencyManager = foreignCurrencyManager;  
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ForeignCurrency() 
        {

            GetForeignCurrency();
            GetSlider("uploads", "original", "Services/ForeignCurrency/Slider");
              
            return View();

            
        }
        [HttpGet]
        public IActionResult Corporate()
        {
            GetCorporateSection();
            GetCorporateSlider("uploads", "original", "Services/Corporate/Slider");
            GetRequiredDocuments();
            return View();
        }

        private async void GetCorporateSection()
        {
            Corporate corporate = new Corporate();
            corporate = await _foreignCurrencyManager.GetCorporate();
            ICollection<RequiredDocument> requiredDocuments = await GetRequiredDocuments();
            ViewBag.BannerImagePath = corporate?.BannerImagePath ?? "";
            ViewBag.InnerSectionTitle = corporate?.InnerSectionTitle?? "";
            ViewBag.InnerSectionDescription = corporate?.InnerSectionDescription?? "";
            ViewBag.CorporateClientsText = corporate?.CorporateClientsText?? "";
            ViewBag.ContactsText = corporate?.ContactsText?? "";
            ViewBag.RequiredDocuments = requiredDocuments ;
           

        }

        private async Task<ICollection<RequiredDocument>> GetRequiredDocuments()
        {
            ICollection<RequiredDocument> requiredDocuments = new List<RequiredDocument>();

            requiredDocuments = await _foreignCurrencyManager.GetRequiredDocuments();
            return await Task.FromResult(requiredDocuments);
        }

        private async void GetForeignCurrency()
        {
            ForeignCurrency foreignCurrency = new ForeignCurrency();
            foreignCurrency = await _foreignCurrencyManager.GetForeignCurrency();

            ViewBag.CurrencyBannerPath = foreignCurrency?.CashCurrencyBannerImagePath ?? "";
            ViewBag.InnerSectionPageHeader = foreignCurrency?.InnerSectionPageHeader ?? "";
            ViewBag.InnerSectionPageDescription = foreignCurrency?.InnerSectionPageDescription ?? "";
            ViewBag.FCDeliveryText = foreignCurrency?.FCDeliveryText ?? "";
            ViewBag.FCExchangeTextFirstSection = foreignCurrency?.FCExchangeTextFirstSection ?? "";
            ViewBag.FCExchangeTextSecondSection = foreignCurrency?.FCExchangeTextSecondSection ?? "";


            ViewBag.FCExchangeTextThirdSection = foreignCurrency?.FCExchangeTextThirdSection ?? "";
            ViewBag.BuySellCurrencyText = foreignCurrency?.BuySellCurrencyText ?? "";
            ViewBag.BuySellCurrencyLinkOneText = foreignCurrency?.BuySellCurrencyLinkOneText ?? "";
            ViewBag.BuySellCurrencyLinkOne = foreignCurrency?.BuySellCurrencyLinkOne ?? "";
            ViewBag.BuySellCurrencyLinkTwoText = foreignCurrency?.BuySellCurrencyLinkTwoText ?? "";
            ViewBag.BuySellCurrencyORText = foreignCurrency?.BuySellCurrencyORText ?? "";
            ViewBag.ORDescriptionText = foreignCurrency?.ORDescriptionText ?? "";



            ViewBag.FCDeliveryImagePath = foreignCurrency?.FCDeliveryImagePath ?? "";  
            ViewBag.QRCodeImagePath = foreignCurrency?.QRCodeImagePath ?? "";
            ViewBag.BranchImagePath = foreignCurrency?.BranchImagePath ?? "";
            ViewBag.CurrencyBannerPath = foreignCurrency?.CashCurrencyBannerImagePath ?? "";
            ViewBag.CurrencyBannerPath = foreignCurrency?.CashCurrencyBannerImagePath ?? "";

            //ViewBag.SecondSection = companyHistory?.SecondSection ?? "";
        }

        public void GetSlider(string folderName, string subfolder, string typefolder)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder);
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToArray();

                ViewBag.SliderFileNames = fileNames;
            }
            else
            {
                ViewBag.SliderFileNames = new string[0]; // No files available
            }

        }
        public void GetCorporateSlider(string folderName, string subfolder, string typefolder)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder);
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToArray();

                ViewBag.CorporateSliderFileNames = fileNames;
            }
            else
            {
                ViewBag.CorporateSliderFileNames = new string[0]; // No files available
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
        public async Task<JsonResult> UploadCCurrencyBanner(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "CashCurrencyBanner");
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
            var currencyBannerImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");  
            ForeignCurrency foreignCurrency = new ForeignCurrency();
            foreignCurrency.CashCurrencyBannerImagePath = currencyBannerImagePath;
            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _foreignCurrencyManager.UpdateCurrencyBannerImagePath(foreignCurrency);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Currency Banner updated successfully.",
                    redirectUrl = Url.Action("ForeignCurrency", "Services")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Currency Banner updated failed.",
                    redirectUrl = Url.Action("ForeignCurrency", "Services")
                };
                return Json(response);
            }
        }

        [HttpPost]
        public async Task<JsonResult> UpdateForeignCurrencySection(ForeignCurrencyRequestDTO model)
        {
            var foreignCurrency = _mapper.Map<ForeignCurrency>(model);
            var result = await _foreignCurrencyManager.UpdateForeignCurrencySection(foreignCurrency);

            var response = new
            {
                Success = true,
                Message = "Foreign Currrency section updated successfully.",
                redirectUrl = Url.Action("ForeignCurrency", "Services")
            };


            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateCorporateSection(CorporateRequestDTO model)
        {
            var corporate = _mapper.Map<Corporate>(model);
            var result = await _foreignCurrencyManager.UpdateCorporateSection(corporate);

            var response = new
            {
                Success = true,
                Message = "Corporate section updated successfully.",
                redirectUrl = Url.Action("Corporate", "Services")
            };


            return Json(response);
        }



        [HttpPost]
        public async Task<JsonResult> UpdateForeignCurrencyDeliveryBanner(ForeignCurrencyRequestDTO model)
        {
            var foreignCurrency = _mapper.Map<ForeignCurrency>(model);
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "ForeignCurrency", "ForeignCurremcyDeliveryBanner");
            string filePosition = "1";

            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);
            string filePathToSave = string.Empty;

            var file = model.FCDeliveryImageFile;

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
                var fcDeliveryImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
                foreignCurrency.FCDeliveryImagePath = fcDeliveryImagePath;
            }


            
            bool result = await _foreignCurrencyManager.UpdateFCDeliveryImageFile(foreignCurrency);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Foreign Currency Delivery Banner updated successfully.",
                    redirectUrl = Url.Action("ForeignCurrency", "Services")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Foreign Currency Delivery Banner updated failed.",
                    redirectUrl = Url.Action("ForeignCurrency", "Services")
                };
                return Json(response);
            }

        }


        [HttpPost]
        public async Task<JsonResult> UpdateQRCodeImageFile(ForeignCurrencyRequestDTO model)   
        {
            var foreignCurrency = _mapper.Map<ForeignCurrency>(model);
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "ForeignCurrency", "QRCodeImage");
            string filePosition = "1";

            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);
            string filePathToSave = string.Empty;

            var file = model.QRCodeImageFile;

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
                var QRCodeImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
                foreignCurrency.QRCodeImagePath = QRCodeImagePath;  
            }



            bool result = await _foreignCurrencyManager.UpdateQRCodeImageFile(foreignCurrency);   



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "QR Code Image updated successfully.",
                    redirectUrl = Url.Action("ForeignCurrency", "Services")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "QR Code Image updated failed.",
                    redirectUrl = Url.Action("ForeignCurrency", "Services")
                };
                return Json(response);
            }

        }

        //UpdateBranchImageFile
        [HttpPost]
        public async Task<JsonResult> UpdateBranchImageFile(ForeignCurrencyRequestDTO model)
        {
            var foreignCurrency = _mapper.Map<ForeignCurrency>(model);
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "ForeignCurrency", "BranchImage");
            string filePosition = "1";

            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);
            string filePathToSave = string.Empty;

            var file = model.QRCodeImageFile;

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
                var branchImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
                foreignCurrency.BranchImagePath = branchImagePath;  
            }



            bool result = await _foreignCurrencyManager.UpdateBranchImageFile(foreignCurrency);    



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Branch Image updated successfully.",
                    redirectUrl = Url.Action("ForeignCurrency", "Services")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Branch Image updated failed.",
                    redirectUrl = Url.Action("ForeignCurrency", "Services")
                };
                return Json(response);
            }

        }

        [HttpPost]
        public async Task<JsonResult>  UploadSlider(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            //Services/ForeignCurrency/Slider
            string filePath = Path.Combine(uploadsFolder, "Uploads",  "original", "Services","ForeignCurrency","Slider");
            string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "Services", "ForeignCurrency", "Slider");

            string filePosition = model.position;

            //DeleteAllFilesOfFolder(filePath, filePosition);
            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);
            DeleteAllFilesOfFolderWithPosition(thumbnailPath, filePosition);

            ForeignCurrency foreignCurrency = new ForeignCurrency();    

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
                    string filePathToSave = string.Empty;
                    if (model.position != "0")
                    {
                        totalfilesOriginal = Convert.ToInt32(model.position);
                        filePathToSave = Path.Combine(filePath, (totalfilesOriginal).ToString() + fileExtension);

                        var ImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");   

                        if (totalfilesOriginal.ToString() == "1")
                        {
                            foreignCurrency.SlideImageFileOnePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "2")
                        {
                            foreignCurrency.SlideImageFileTwoPath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "3")
                        {
                            foreignCurrency.SlideImageFileThreePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "4")
                        {
                            foreignCurrency.SlideImageFileFourPath = ImagePath;
                        }



                    }
                    else
                    {
                        totalfilesOriginal = Directory.GetFiles(filePath).Count();
                        filePathToSave = Path.Combine(filePath, (totalfilesOriginal + 1).ToString() + fileExtension);
                        var ImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                        if ((totalfilesOriginal+1).ToString() == "1")
                        {
                            foreignCurrency.SlideImageFileOnePath = ImagePath;
                        }

                        if ((totalfilesOriginal + 1).ToString() == "2")
                        {
                            foreignCurrency.SlideImageFileTwoPath = ImagePath;
                        }

                        if ((totalfilesOriginal + 1).ToString() == "3")
                        {
                            foreignCurrency.SlideImageFileThreePath = ImagePath;
                        }

                        if ((totalfilesOriginal + 1).ToString() == "4")
                        {
                            foreignCurrency.SlideImageFileFourPath = ImagePath;
                        }


                    }
                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    
                }
            }
             
            bool result = await _foreignCurrencyManager.UpdateSliderImageFile(foreignCurrency);  



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Slider Image updated successfully.",
                    redirectUrl = Url.Action("ForeignCurrency", "Services")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Slider Image updated failed.",
                    redirectUrl = Url.Action("ForeignCurrency", "Services")
                };
                return Json(response);
            }


           
        }

        [HttpPost]
        public async Task<JsonResult> UploadCorporateSlider(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            //Services/ForeignCurrency/Slider
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "Corporate", "Slider");
            //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "Services", "Corporate", "Slider");

            string filePosition = model.position;

            //DeleteAllFilesOfFolder(filePath, filePosition);
            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);
            

            Corporate corporate = new Corporate();

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
                    string filePathToSave = string.Empty;
                    if (model.position != "0")
                    {
                        totalfilesOriginal = Convert.ToInt32(model.position);
                        filePathToSave = Path.Combine(filePath, (totalfilesOriginal).ToString() + fileExtension);

                        var ImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                        if (totalfilesOriginal.ToString() == "1")
                        {
                            corporate.SliderOneImagePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "2")
                        {
                            corporate.SliderTwoImagePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "3")
                        {
                            corporate.SliderThreeImagePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "4")
                        {
                            corporate.SliderFourImagePath = ImagePath;
                        }



                    }
                    else
                    {
                        totalfilesOriginal = Directory.GetFiles(filePath).Count();
                        filePathToSave = Path.Combine(filePath, (totalfilesOriginal + 1).ToString() + fileExtension);
                        var ImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                        if (totalfilesOriginal.ToString() == "1")
                        {
                            corporate.SliderOneImagePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "2")
                        {
                            corporate.SliderTwoImagePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "3")
                        {
                            corporate.SliderThreeImagePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "4")
                        {
                            corporate.SliderFourImagePath = ImagePath;
                        }



                    }
                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }


                }
            }

            bool result = await _foreignCurrencyManager.UpdateCorporateSliderImageFile(corporate);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Slider Image updated successfully.",
                    redirectUrl = Url.Action("Corporate", "Services")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Slider Image updated failed.",
                    redirectUrl = Url.Action("Corporate", "Services")
                };
                return Json(response);
            }



        }

        [HttpPost]
        public async Task<JsonResult> UploadCorporateBanner(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "CorporateBanner");
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
            var bannerImagePath  = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
            Corporate corporate = new Corporate();
            corporate.BannerImagePath = bannerImagePath;
            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _foreignCurrencyManager.UpdateCorporateBanner(corporate); 



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Corporate Banner updated successfully.",
                    redirectUrl = Url.Action("Corporate", "Services")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Corporate Banner updated failed.",
                    redirectUrl = Url.Action("Corporate", "Services")
                };
                return Json(response);
            }
        }

       

        [HttpPost]
        public async Task<JsonResult> AddRequiredDocuments(string newValue)
        {
            Corporate corporate = await GetCorporate();
            RequiredDocument requiredDocument; 
            bool result = false;
            if (corporate != null)
            {
                if (!string.IsNullOrWhiteSpace(newValue))
                {
                    requiredDocument = new RequiredDocument
                    {
                        Id = Guid.NewGuid(),
                        RequiredDocumentText = newValue,
                        CorporateId = corporate.Id,
                        Corporate = corporate                    };
                    //missionVisionValues.ValuesItems.Add(valuesItem);

                    result = await _foreignCurrencyManager.UpdateRequiredDociuments(requiredDocument);

                }



            }


            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Required Documents updated successfully.",
                    redirectUrl = Url.Action("Corporate", "Services")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {  
                    Success = true,
                    Message = "Required Documents updated failed.",
                    redirectUrl = Url.Action("Corporate", "Services")
                };
                return Json(response);
            }


        }

        private async Task<Corporate> GetCorporate()
        {
            Corporate corporate = new Corporate();
            corporate = await _foreignCurrencyManager.GetCorporate();
            return await Task.FromResult(corporate);
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteRequiredDocuments(string itemSerialNo)   
        {
            RequiredDocument requiredDocument  = await GetRequiredDocumentsBySerialNo(itemSerialNo);

            bool result = false;
            if (!string.IsNullOrEmpty(requiredDocument.RequiredDocumentText))
            {
                result = await _foreignCurrencyManager.DeleteRequiredDocuments(requiredDocument);

            }


            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Required Documents deleted successfully.",
                    redirectUrl = Url.Action("Corporate", "Services")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Required Documents delete failed.",
                    redirectUrl = Url.Action("Corporate", "Services")  
                };
                return Json(response);
            }
        }

        private async Task<RequiredDocument> GetRequiredDocumentsBySerialNo(string itemSerialNo)
        {
            RequiredDocument requiredDocument = new RequiredDocument();
            int serial = Convert.ToInt32(itemSerialNo);
            requiredDocument = await _foreignCurrencyManager.GetRequiredDocumentsBySerialNo(serial);  
            return await Task.FromResult(requiredDocument);
        }
    }
}
