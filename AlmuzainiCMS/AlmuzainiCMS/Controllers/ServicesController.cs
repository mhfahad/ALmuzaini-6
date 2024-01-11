using AlmuzainiCMS.BLL.BLL;
using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models;
using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models.RequestDto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace AlmuzainiCMS.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ILogger<ServicesController> _logger;

        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IForeignCurrencyManager _foreignCurrencyManager;
        private readonly IRemittancesManager _remittancesManager;
        private readonly IValueAddedBenifitsManager _valueAddedBenifitsManager;
        private readonly IApplicationPageManager _applicationPageManager;
        public ServicesController(ILogger<ServicesController> logger, IMapper mapper, IWebHostEnvironment webHostEnvironment,
            IForeignCurrencyManager foreignCurrencyManager, IRemittancesManager remittancesManager, IValueAddedBenifitsManager valueAddedBenifitsManager,
            IApplicationPageManager applicationPageManager)
        {
            _logger = logger;
            _mapper = mapper;
            _hostingEnvironment = webHostEnvironment;
            _foreignCurrencyManager = foreignCurrencyManager;
            _remittancesManager = remittancesManager;
            _valueAddedBenifitsManager = valueAddedBenifitsManager;
            _applicationPageManager = applicationPageManager;
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
            //GetRequiredDocuments();
            return View();
        }


        [HttpGet]
        public IActionResult Remittances()
        {
            GetRemittances();
            return View();

        }
        private async void GetRemittances()   
        {
            Remittences remittances  = new Remittences();
            remittances = await _remittancesManager.GetRemittances();
            GetRemittancesSlider("uploads", "original", "Services/Remittances/Slider");   

            ViewBag.BannerImagePath = remittances?.BannerImagePath ?? "";
            ViewBag.InnerSectionTitle = remittances?.InnerSectionTitle ?? "";
            ViewBag.InnerSectionDescription = remittances?.InnerSectionDescription ?? "";
            ViewBag.FirstSectionLeftTitle = remittances?.FirstSectionLeftTitle?? "";
            ViewBag.FirstSectionLeftText = remittances?.FirstSectionLeftText?? "";
            ViewBag.FirstSectionLeftImagePath = remittances?.FirstSectionLeftImagePath?? "";
            ViewBag.FirstSectionRightTitle = remittances?.FirstSectionRightTitle?? "";
            ViewBag.FirstSectionRightText = remittances?.FirstSectionRightText?? "";
            ViewBag.FirstSectionRightImagePath = remittances?.FirstSectionRightImagePath?? "";
            ViewBag.SecondSectionTitle = remittances?.SecondSectionTitle ?? "";
            ViewBag.SecondSectionText = remittances?.SecondSectionText ?? "";
            ViewBag.SecondSectionImagePath = remittances?.SecondSectionImagePath ?? "";
            ViewBag.ThirdSectionTitle = remittances?.ThirdSectionTitle ?? "";
            ViewBag.ThirdSectionText = remittances?.ThirdSectionText ?? "";
            ViewBag.ThirdSectionImagePath = remittances?.ThirdSectionImagePath ?? "";
            ViewBag.FourthSectionLeftTitle = remittances?.FourthSectionLeftTitle ?? "";
            ViewBag.FourthSectionLeftText = remittances?.FourthSectionLeftText ?? "";
            ViewBag.FourthSectionRightTitle = remittances?.FourthSectionRightTitle ?? "";
            ViewBag.FourthSectionRightText = remittances?.FourthSectionRightText ?? "";
            ViewBag.VideoTwoLink = remittances?.VideoTwoLink?? "";
            ViewBag.VideoOneLink = remittances?.VideoOneLink?? "";
            ViewBag.VideoTwoText = remittances?.VideoTwoText?? "";
            ViewBag.VideoOneText = remittances?.VideoOneText?? "";
            ViewBag.VideoOneThumbnailImagePath = remittances?.VideoOneThumbnailImagePath ?? "";
            ViewBag.VideoTwoThumbnailImagePath = remittances?.VideoTwoThumbnailImagePath ?? "";


            ViewBag.RemitNowText = remittances?.RemitNowText?? "";
            ViewBag.RemitNowImageOneText = remittances?.RemitNowImageOneText ?? "";
            ViewBag.RemitNowImageTwoText = remittances?.RemitNowImageTwoText ?? "";  
            ViewBag.RemitNowImageOne = remittances?.RemitNowImageOne?? "";
            ViewBag.RemitNowImageTwo = remittances?.RemitNowImageTwo?? "";
            //ViewBag.RemittancesSliderFileNames = "a";
            //ViewBag.SliderOneImagePath = remittances?.SliderOneImagePath?? "";
            //ViewBag.SliderTwoImagePath = remittances?.SliderTwoImagePath?? "";
            //ViewBag.SliderThreeImagePath = remittances?.SliderThreeImagePath?? "";
            //ViewBag.SliderFourImagePath = remittances?.SliderFourImagePath?? "";



            //ViewBag.ContactsText = corporate?.ContactsText ?? "";
            //ViewBag.RequiredDocuments = requiredDocuments;


        }

        [HttpGet]
        public IActionResult ValueAddedBenifits()
        {
            GetValueAddedBenifits();
            return View();
        }

        private async void GetValueAddedBenifits()
        {
            ValueAddedBenifits valueAddedBenifits = new ValueAddedBenifits();
            valueAddedBenifits = await _valueAddedBenifitsManager.GetValueAddedBenifits();
            GetValueAddedBenifitsSlider("uploads", "original", "Services/ValueAddedBenifits/Slider");   

            ViewBag.BannerImagePath = valueAddedBenifits?.BannerImagePath ?? "";
            ViewBag.InnerSectionTitle = valueAddedBenifits?.InnerSectionTitle ?? "";
            ViewBag.InnerSectionDescription = valueAddedBenifits?.InnerSectionDescription ?? "";
            ViewBag.LeftSectionFirstTitle = valueAddedBenifits?.LeftSectionFirstTitle ?? "";
            ViewBag.LeftSectionFirstText =  valueAddedBenifits?.LeftSectionFirstText ?? "";
            ViewBag.LeftSectionFirstImagePath = valueAddedBenifits?.LeftSectionFirstImagePath ?? "";
            ViewBag.LeftSectionSecondImagePath = valueAddedBenifits?.LeftSectionSecondImagePath ?? "";
            ViewBag.LeftSectionSecondTitle = valueAddedBenifits?.LeftSectionSecondTitle ?? "";

            ViewBag.LeftSectionSecondText = valueAddedBenifits?.LeftSectionSecondText ?? "";
            ViewBag.LeftSectionThirdImagePath = valueAddedBenifits?.LeftSectionThirdImagePath ?? "";
            ViewBag.LeftSectionThirdText = valueAddedBenifits?.LeftSectionThirdText ?? "";
            ViewBag.LeftSectionThirdTitle = valueAddedBenifits?.LeftSectionThirdTitle ?? "";
            ViewBag.RightSectionFirstTitle = valueAddedBenifits?.RightSectionFirstTitle ?? "";
            ViewBag.RightSectionSecondTitle = valueAddedBenifits?.RightSectionSecondTitle ?? "";
            ViewBag.RightSectionThirdTitle = valueAddedBenifits?.RightSectionThirdTitle ?? "";
            ViewBag.RightSectionFourthTitle = valueAddedBenifits?.RightSectionFourthTitle ?? "";

            ViewBag.RightSectionFirstText = valueAddedBenifits?.RightSectionFirstText ?? "";
            ViewBag.RightSectionFirstImagePath = valueAddedBenifits?.RightSectionFirstImagePath?? "";
            ViewBag.RightSectionSecondText = valueAddedBenifits?.RightSectionSecondText ?? "";
            ViewBag.RightSectionSecondImagePath = valueAddedBenifits?.RightSectionSecondImagePath ?? "";
            ViewBag.RightSectionThirdText = valueAddedBenifits?.RightSectionThirdText ?? "";
            ViewBag.RightSectionThirdImagePath = valueAddedBenifits?.RightSectionThirdImagePath ?? "";
            ViewBag.RightSectionFourthText = valueAddedBenifits?.RightSectionFourthText ?? "";
            ViewBag.RightSectionFourthImagePath = valueAddedBenifits?.RightSectionFourthImagePath ?? "";  
        }

        private void GetValueAddedBenifitsSlider(string v1, string v2, string v3)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, v1);
            string folderPath = Path.Combine(uploadsFolder, v2, v3); 
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToArray();

                ViewBag.ValueAddedBenifitsSliderFileNames = fileNames;
            }
            else
            {
                ViewBag.ValueAddedBenifitsSliderFileNames = new string[0]; // No files available  
            }
        }

        private void GetRemittancesSlider(string folderName, string subfolder, string typefolder)   
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder);
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToArray();

                ViewBag.RemittancesSliderFileNames = fileNames;
            }
            else
            {
                ViewBag.RemittancesSliderFileNames = new string[0]; // No files available
            }
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

        public async Task<JsonResult> UploadRemittancesBanner(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "Remittances", "Banner");
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
            Remittences remittances = new Remittences();
            remittances.BannerImagePath = bannerImagePath;
            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _remittancesManager.UpdateBannerImagePath(remittances);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Remittances Banner updated successfully.",
                    redirectUrl = Url.Action("Remittances", "Services")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Remittances Banner updated failed.",
                    redirectUrl = Url.Action("Remittances", "Services")
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

            var file = model.BranchImageFile;

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

                        if (totalfilesOriginal.ToString() == "0")
                        {
                            corporate.SliderOneImagePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "1")
                        {
                            corporate.SliderTwoImagePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "2")
                        {
                            corporate.SliderThreeImagePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "3")
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
        public async Task<JsonResult> UploadRemittancesSlider(MultipleFileUploadVM model)  
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            //Services/ForeignCurrency/Slider
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "Remittances", "Slider");
           
            string filePosition = model.position;

            //DeleteAllFilesOfFolder(filePath, filePosition);
            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);
           

            Remittences remittances = new Remittences();

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
                            remittances.SliderOneImagePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "2")
                        {
                            remittances.SliderTwoImagePath = ImagePath;

                        }

                        if (totalfilesOriginal.ToString() == "3")
                        {
                            remittances.SliderThreeImagePath = ImagePath;

                        }

                        if (totalfilesOriginal.ToString() == "4")
                        {
                            remittances.SliderFourImagePath = ImagePath;

                        }



                    }
                    else
                    {
                        totalfilesOriginal = Directory.GetFiles(filePath).Count();
                        filePathToSave = Path.Combine(filePath, (totalfilesOriginal + 1).ToString() + fileExtension);
                        var ImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                        if ((totalfilesOriginal + 1).ToString() == "1")
                        {
                            remittances.SliderOneImagePath = ImagePath;
                        }

                        if ((totalfilesOriginal + 1).ToString() == "2")
                        {
                            remittances.SliderTwoImagePath = ImagePath;
                        }

                        if ((totalfilesOriginal + 1).ToString() == "3")
                        {
                            remittances.SliderThreeImagePath = ImagePath;
                        }

                        if ((totalfilesOriginal + 1).ToString() == "4")
                        {
                            remittances.SliderFourImagePath = ImagePath;
                        }


                    }
                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }


                }
            }

            bool result = await _remittancesManager.UpdateSliderImageFile(remittances);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Slider Image updated successfully.",
                    redirectUrl = Url.Action("Remittances", "Services")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Slider Image updated failed.",
                    redirectUrl = Url.Action("Remittances", "Services")
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


        [HttpPost]
        public async Task<JsonResult> UpdateInnerSection(RemittancesRequestDTO model)  
        {
            var remittances = _mapper.Map<Remittences>(model);
            bool result = await _remittancesManager.UpdateInnerSection(remittances);   

            var response = new
            {
                Success = true,
                Message = "Remittances section updated successfully.",
                redirectUrl = Url.Action("Remittances", "Services")
            };


            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateFirstSectionLeft(RemittancesRequestDTO model)  
        {
            try
            {
                var remittancesmodel = _mapper.Map<Remittences>(model);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
                string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "Remittances", "FirstSectionLeft");
                //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");



                //DeleteAllFilesOfFolder(filePath, filePosition);


                string filePathToSave = string.Empty;

                if (model?.FirstSectionLeftImageFile != null && model?.FirstSectionLeftImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "1");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.FirstSectionLeftImageFile.FileName;
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
                        model?.FirstSectionLeftImageFile.CopyTo(fileStream);
                    }

                    var firstSectionLeftImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    remittancesmodel.FirstSectionLeftImagePath = firstSectionLeftImagePath;

                }



                bool result = await _remittancesManager.UpdateFirstSectionLeft(remittancesmodel);

                if(result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "First section left updated successfully.",
                        redirectUrl = Url.Action("Remittances", "Services")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "First section left updated failed.",
                        redirectUrl = Url.Action("Remittances", "Services")
                    };
                    return Json(response);
                }
                
                
            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = true,
                    Message = "First section left updated failed.",
                    redirectUrl = Url.Action("Remittances", "Services")
                };
                return Json(response);
            }
            

            //return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateFirstSectionRight(RemittancesRequestDTO model)
        {
            try
            {
                var remittancesmodel = _mapper.Map<Remittences>(model);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
                string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "Remittances", "FirstSectionRight");  
                //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");



                //DeleteAllFilesOfFolder(filePath, filePosition);


                string filePathToSave = string.Empty;

                if (model?.FirstSectionRightImageFile != null && model?.FirstSectionRightImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "1");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.FirstSectionRightImageFile.FileName;
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
                        model?.FirstSectionRightImageFile.CopyTo(fileStream);
                    }

                    var firstSectionRightImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
                    //Remittences remittances = new Remittences();
                    remittancesmodel.FirstSectionRightImagePath = firstSectionRightImagePath;   
                }

                


                bool result = await _remittancesManager.UpdateFirstSectionRight(remittancesmodel);

                if (result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "First section Right updated successfully.",
                        redirectUrl = Url.Action("Remittances", "Services")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "First section Right updated failed.",
                        redirectUrl = Url.Action("Remittances", "Services")
                    };
                    return Json(response);
                }


            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = true,
                    Message = "First section Right updated failed.",
                    redirectUrl = Url.Action("Remittances", "Services")
                };
                return Json(response);
            }


            //return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateSecondSection(RemittancesRequestDTO model)
        {
            try
            {
                var remittancesmodel = _mapper.Map<Remittences>(model);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
                string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "Remittances", "SecondSection");
                //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");



                //DeleteAllFilesOfFolder(filePath, filePosition);


                string filePathToSave = string.Empty;

                if (model?.SecondSectionImageFile != null && model?.SecondSectionImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "1");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.SecondSectionImageFile.FileName;
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
                        model?.SecondSectionImageFile.CopyTo(fileStream);
                    }

                    var secondSectionImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
                   
                    remittancesmodel.SecondSectionImagePath = secondSectionImagePath;
                }




                bool result = await _remittancesManager.UpdateSecondSection(remittancesmodel);

                if (result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Second section updated successfully.",
                        redirectUrl = Url.Action("Remittances", "Services")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Second section updated failed.",
                        redirectUrl = Url.Action("Remittances", "Services")
                    };
                    return Json(response);
                }


            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = true,
                    Message = "Second section updated failed.",
                    redirectUrl = Url.Action("Remittances", "Services")
                };
                return Json(response);
            }


            //return Json(response);
        }


        [HttpPost]
        public async Task<JsonResult> UpdateThirdSection(RemittancesRequestDTO model)
        {
            try
            {
                var remittancesmodel = _mapper.Map<Remittences>(model);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
                string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "Remittances", "ThirdSection");
                //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");



                //DeleteAllFilesOfFolder(filePath, filePosition);


                string filePathToSave = string.Empty;

                if (model?.ThirdSectionImageFile != null && model?.ThirdSectionImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "1");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.ThirdSectionImageFile.FileName;
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
                        model?.ThirdSectionImageFile.CopyTo(fileStream);
                    }

                    var thirdSectionImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    remittancesmodel.ThirdSectionImagePath = thirdSectionImagePath;
                }




                bool result = await _remittancesManager.UpdateThirdSection(remittancesmodel);

                if (result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Third section updated successfully.",
                        redirectUrl = Url.Action("Remittances", "Services")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Third section updated failed.",
                        redirectUrl = Url.Action("Remittances", "Services")
                    };
                    return Json(response);
                }


            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = true,
                    Message = "First section Right updated failed.",
                    redirectUrl = Url.Action("Remittances", "Services")
                };
                return Json(response);
            }


            //return Json(response);
        }


        [HttpPost]
        public async Task<JsonResult> UpdateFourthSection(RemittancesRequestDTO model)
        {
            try
            {
                var remittancesmodel = _mapper.Map<Remittences>(model);

                bool result = await _remittancesManager.UpdateFourthSection(remittancesmodel);

                if (result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Fourth section updated successfully.",
                        redirectUrl = Url.Action("Remittances", "Services")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Fourth section updated failed.",
                        redirectUrl = Url.Action("Remittances", "Services")
                    };
                    return Json(response);
                }


            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = true,
                    Message = "Fourth section Right updated failed.",
                    redirectUrl = Url.Action("Remittances", "Services")
                };
                return Json(response);
            }


            //return Json(response);
        }


        [HttpPost]
        public async Task<JsonResult> UpdateRemitNow(RemittancesRequestDTO model)  
        {
            try
            {
                var remittancesmodel = _mapper.Map<Remittences>(model);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
                string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "Remittances", "RemitNow");
                //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");



                //DeleteAllFilesOfFolder(filePath, filePosition);


                string filePathToSave = string.Empty;

                if (model?.RemitNowImageOneFile != null && model?.RemitNowImageOneFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "1");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.RemitNowImageOneFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".webp";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, (1).ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.RemitNowImageOneFile.CopyTo(fileStream);
                    }

                    var remitNowImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    remittancesmodel.RemitNowImageOne = remitNowImagePath;
                }

                if (model?.RemitNowImageTwoFile != null && model?.RemitNowImageTwoFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "2");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.RemitNowImageTwoFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".webp";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, (2).ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.RemitNowImageTwoFile.CopyTo(fileStream);
                    }

                    var remitNowImageTwoPath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    remittancesmodel.RemitNowImageTwo = remitNowImageTwoPath;
                }




                bool result = await _remittancesManager.UpdateRemitNow(remittancesmodel);

                if (result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Remit Now updated successfully.",
                        redirectUrl = Url.Action("Remittances", "Services")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Remit Now updated failed.",
                        redirectUrl = Url.Action("Remittances", "Services")
                    };
                    return Json(response);
                }


            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = true,
                    Message = "Remit Now updated failed.",
                    redirectUrl = Url.Action("Remittances", "Services")
                };
                return Json(response);
            }


            //return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateVideoLink(RemittancesRequestDTO model)
        {
            var remittances = _mapper.Map<Remittences>(model);

            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "Remittances", "VideosThumbnail");
            

            string filePathToSave = string.Empty;

            if (model?.VideoOneThumbnailImageFile != null && model?.VideoOneThumbnailImageFile.Length > 0)
            {
                DeleteAllFilesOfFolderWithPosition(filePath, "1");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.VideoOneThumbnailImageFile.FileName;
                //string fileExtension = Path.GetExtension(file.FileName);
                string fileExtension = ".webp";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                int totalfilesOriginal;

                totalfilesOriginal = Directory.GetFiles(filePath).Count();
                filePathToSave = Path.Combine(filePath, (1).ToString() + fileExtension);

                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    model?.VideoOneThumbnailImageFile.CopyTo(fileStream);
                }

                var videoOneThumbnailImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                remittances.VideoOneThumbnailImagePath = videoOneThumbnailImagePath;
            }

            if (model?.VideoTwoThumbnailImageFile != null && model?.VideoTwoThumbnailImageFile.Length > 0)
            {
                DeleteAllFilesOfFolderWithPosition(filePath, "2");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.VideoTwoThumbnailImageFile.FileName;
                //string fileExtension = Path.GetExtension(file.FileName);
                string fileExtension = ".webp";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                int totalfilesOriginal;

                totalfilesOriginal = Directory.GetFiles(filePath).Count();
                filePathToSave = Path.Combine(filePath, (2).ToString() + fileExtension);

                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    model?.VideoTwoThumbnailImageFile.CopyTo(fileStream);
                }

                var videoTwoThumbnailImageFilePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                remittances.VideoOneThumbnailImagePath = videoTwoThumbnailImageFilePath;
            }





            bool result = await _remittancesManager.UpdateVideoLink(remittances);

            var response = new
            {
                Success = true,
                Message = "Video Link updated successfully.",
                redirectUrl = Url.Action("Remittances", "Services")
            };


            return Json(response);
        }


        public async Task<JsonResult> UploadApplicationBanner(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "ApplicationPage", "Banner");
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
            ApplicationPage applicationPage = new ApplicationPage();
            applicationPage.BannerImagePath = bannerImagePath;
            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _applicationPageManager.UpdateBannerImagePath(applicationPage);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Application Banner updated successfully.",
                    redirectUrl = Url.Action("Applications", "Services")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Application Banner updated failed.",
                    redirectUrl = Url.Action("Applications", "Services")
                };
                return Json(response);
            }
        }

        public async Task<JsonResult> UploadValueAddedBenifitsBanner(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "ValueAddedBenifits", "Banner");
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
            ValueAddedBenifits valueAddedBenifits = new ValueAddedBenifits();
            valueAddedBenifits.BannerImagePath = bannerImagePath;
            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _valueAddedBenifitsManager.UpdateBannerImagePath(valueAddedBenifits);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Value Added Benifits Banner updated successfully.",
                    redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Value Added Benifits Banner updated failed.",
                    redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                };
                return Json(response);
            }
        }


        [HttpPost]
        
        public async Task<JsonResult> UpdateApplicationInnerSection(ApplicationPageRequestDTO model)
        {
            var applicationPage = _mapper.Map<ApplicationPage>(model);
            bool result = await _applicationPageManager.UpdateInnerSection(applicationPage);

            var response = new
            {
                Success = true,
                Message = "Application Inner section updated successfully.",
                redirectUrl = Url.Action("Applications", "Services")
            };


            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateValueAddedBenifitsInnerSection(ValueAddedBinifitsRequestDTO model)   
        {
            var valueAddedBenifits = _mapper.Map<ValueAddedBenifits>(model);
            bool result = await _valueAddedBenifitsManager.UpdateInnerSection(valueAddedBenifits);

            var response = new
            {
                Success = true,
                Message = "Value Added Benifits Inner section updated successfully.",
                redirectUrl = Url.Action("ValueAddedBenifits", "Services")
            };


            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateValueAddedBenifitsLeftSectionFirst(ValueAddedBinifitsRequestDTO model)  
        {
            try
            {
                var valueAddedBenifits = _mapper.Map<ValueAddedBenifits>(model);  

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
                string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "ValueAddedBenifits", "FirstSectionLeft");
                //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");



                //DeleteAllFilesOfFolder(filePath, filePosition);


                string filePathToSave = string.Empty;

                if (model?.LeftSectionFirstImageFile != null && model?.LeftSectionFirstImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "1");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.LeftSectionFirstImageFile.FileName;
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
                        model?.LeftSectionFirstImageFile.CopyTo(fileStream);
                    }

                    var firstSectionLeftImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    valueAddedBenifits.LeftSectionFirstImagePath = firstSectionLeftImagePath;

                }



                bool result = await _valueAddedBenifitsManager.UpdateLeftSectionFirst(valueAddedBenifits);

                if (result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "First section left updated successfully.",
                        redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "First section left updated failed.",
                        redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                    };
                    return Json(response);
                }


            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = true,
                    Message = "First section left updated failed.",
                    redirectUrl = Url.Action("Remittances", "Services")
                };
                return Json(response);
            }


            //return Json(response);
        }


        [HttpPost]
        public async Task<JsonResult> UpdateValueAddedBenifitsLeftSectionSecond(ValueAddedBinifitsRequestDTO model)  
        {
            try
            {
                var valueAddedBenifits = _mapper.Map<ValueAddedBenifits>(model);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
                string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "ValueAddedBenifits", "SecondSectionLeft");
                //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");



                //DeleteAllFilesOfFolder(filePath, filePosition);


                string filePathToSave = string.Empty;

                if (model?.LeftSectionSecondImageFile != null && model?.LeftSectionSecondImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "1");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.LeftSectionSecondImageFile.FileName;
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
                        model?.LeftSectionSecondImageFile.CopyTo(fileStream);
                    }

                    var secondSectionLeftImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    valueAddedBenifits.LeftSectionSecondImagePath = secondSectionLeftImagePath;

                }



                bool result = await _valueAddedBenifitsManager.UpdateLeftSectionSecond(valueAddedBenifits);

                if (result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Second section left updated successfully.",
                        redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Second section left updated failed.",
                        redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                    };
                    return Json(response);
                }


            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = true,
                    Message = "First section left updated failed.",
                    redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                };
                return Json(response);
            }


            //return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateValueAddedBenifitsLeftSectionThird(ValueAddedBinifitsRequestDTO model)  
        {
            try
            {
                var valueAddedBenifits = _mapper.Map<ValueAddedBenifits>(model);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
                string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "ValueAddedBenifits", "ThirdSectionLeft");
                //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");



                //DeleteAllFilesOfFolder(filePath, filePosition);


                string filePathToSave = string.Empty;

                if (model?.LeftSectionThirdImageFile != null && model?.LeftSectionThirdImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "1");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.LeftSectionThirdImageFile.FileName;
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
                        model?.LeftSectionThirdImageFile.CopyTo(fileStream);
                    }

                    var thirdSectionLeftImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    valueAddedBenifits.LeftSectionThirdImagePath = thirdSectionLeftImagePath;

                }



                bool result = await _valueAddedBenifitsManager.UpdateLeftSectionThird(valueAddedBenifits);

                if (result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Third section left updated successfully.",
                        redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Third section left updated failed.",
                        redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                    };
                    return Json(response);
                }


            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = true,
                    Message = "Third section left updated failed.",
                    redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                };
                return Json(response);
            }


            //return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateValueAddedBenifitsRightSectionFirst(ValueAddedBinifitsRequestDTO model)
        {
            try
            {
                var valueAddedBenifits = _mapper.Map<ValueAddedBenifits>(model);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
                string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "ValueAddedBenifits", "FirstSectionRight");
                //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");



                //DeleteAllFilesOfFolder(filePath, filePosition);


                string filePathToSave = string.Empty;

                if (model?.RightSectionFirstImageFile != null && model?.RightSectionFirstImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "1");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.RightSectionFirstImageFile.FileName;
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
                        model?.RightSectionFirstImageFile.CopyTo(fileStream);
                    }

                    var firstSectionRightImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    valueAddedBenifits.RightSectionFirstImagePath = firstSectionRightImagePath;

                }



                bool result = await _valueAddedBenifitsManager.UpdateRightSectionFirst(valueAddedBenifits);

                if (result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "First section right updated successfully.",
                        redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "First section right updated failed.",
                        redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                    };
                    return Json(response);
                }


            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = true,
                    Message = "First section right updated failed.",
                    redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                };
                return Json(response);
            }


            //return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateValueAddedBenifitsRightSectionSecond(ValueAddedBinifitsRequestDTO model)
        {
            try
            {
                var valueAddedBenifits = _mapper.Map<ValueAddedBenifits>(model);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
                string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "ValueAddedBenifits", "SecondSectionRight");
                //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");



                //DeleteAllFilesOfFolder(filePath, filePosition);


                string filePathToSave = string.Empty;

                if (model?.RightSectionSecondImageFile != null && model?.RightSectionSecondImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "1");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.RightSectionSecondImageFile.FileName;
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
                        model?.RightSectionSecondImageFile.CopyTo(fileStream);
                    }

                    var secondSectionRightImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    valueAddedBenifits.RightSectionSecondImagePath = secondSectionRightImagePath;

                }



                bool result = await _valueAddedBenifitsManager.UpdateRightSectionSecond(valueAddedBenifits);

                if (result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Second section right updated successfully.",
                        redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Second section right updated failed.",
                        redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                    };
                    return Json(response);
                }


            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = true,
                    Message = "Second section right updated failed.",
                    redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                };
                return Json(response);
            }


            //return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateValueAddedBenifitsRightSectionThird(ValueAddedBinifitsRequestDTO model)
        {
            try
            {
                var valueAddedBenifits = _mapper.Map<ValueAddedBenifits>(model);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
                string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "ValueAddedBenifits", "ThirdSectionRight");
                //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");



                //DeleteAllFilesOfFolder(filePath, filePosition);


                string filePathToSave = string.Empty;

                if (model?.RightSectionThirdImageFile != null && model?.RightSectionThirdImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "1");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.RightSectionThirdImageFile.FileName;
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
                        model?.RightSectionThirdImageFile.CopyTo(fileStream);
                    }

                    var thirdSectionRightImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    valueAddedBenifits.RightSectionThirdImagePath = thirdSectionRightImagePath;

                }



                bool result = await _valueAddedBenifitsManager.UpdateRightSectionThird(valueAddedBenifits);

                if (result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Third section right updated successfully.",
                        redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Third section right updated failed.",  
                        redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                    };
                    return Json(response);
                }


            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = true,
                    Message = "Third section right updated failed.",  
                    redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                };
                return Json(response);
            }


            //return Json(response);
        }
        [HttpPost]
        public async Task<JsonResult> UpdateValueAddedBenifitsRightSectionFourth(ValueAddedBinifitsRequestDTO model)
        {
            try
            {
                var valueAddedBenifits = _mapper.Map<ValueAddedBenifits>(model);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
                string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "ValueAddedBenifits", "FourthSectionRight");
                //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");



                //DeleteAllFilesOfFolder(filePath, filePosition);


                string filePathToSave = string.Empty;

                if (model?.RightSectionFourthImageFile != null && model?.RightSectionFourthImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "1");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.RightSectionFourthImageFile.FileName;
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
                        model?.RightSectionFourthImageFile.CopyTo(fileStream);
                    }

                    var fourthSectionRightImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    valueAddedBenifits.RightSectionFourthImagePath = fourthSectionRightImagePath;

                }



                bool result = await _valueAddedBenifitsManager.UpdateRightSectionFourth(valueAddedBenifits);

                if (result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Fourth section right updated successfully.",
                        redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Fourth section right updated failed.",
                        redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                    };
                    return Json(response);
                }


            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = true,
                    Message = "Fourth section right updated failed.",
                    redirectUrl = Url.Action("ValueAddedBenifits", "Services")
                };
                return Json(response);
            }


            //return Json(response);
        }

        [HttpGet]
        public IActionResult Applications()
        {
            GetApplicationPage();
            return View();
        }

        public async void GetApplicationPage()
        {
            ApplicationPage applicationPage = new ApplicationPage();
            applicationPage = await _applicationPageManager.GetApplicationPage();
            GetApplicationPageSlider("uploads", "original", "Services/ApplicationPage/Slider");
            GetApplicationPageIcons("uploads", "original", "Services/ApplicationPage/ApplicationIcon");
            ICollection<UserGuide> userGuides = await GetApplicationPAgeUserGuide();   

           
            ViewBag.BannerImagePath = applicationPage?.BannerImagePath ?? "";
            ViewBag.InnerSectionTitle = applicationPage?.InnerSectionTitle ?? "";
            ViewBag.ABoutBoxDescription = applicationPage?.ABoutBoxDescription ?? "";
            ViewBag.ApplePlayStoreIconImagePath = applicationPage?.ApplePlayStoreIconImagePath ?? "";
            ViewBag.GooglePlayStoreIconImagePath = applicationPage?.GooglePlayStoreIconImagePath ?? "";
            ViewBag.AppGalleryIconImagePath = applicationPage?.AppGalleryIconImagePath ?? "";
            ViewBag.UserGuideTitle = applicationPage?.UserGuideTitle ?? "";
            ViewBag.ApplicationIconOneTitle = applicationPage?.ApplicationIconOneTitle ?? "";

            ViewBag.ApplicationIconOneImagePath = applicationPage?.ApplicationIconOneImagePath ?? "";
            ViewBag.ApplicationIconTwoTitle = applicationPage?.ApplicationIconTwoTitle ?? "";
            ViewBag.ApplicationIconTwoImagePath = applicationPage?.ApplicationIconTwoImagePath ?? "";
            ViewBag.ApplicationIconThreeTitle = applicationPage?.ApplicationIconThreeTitle ?? "";
            ViewBag.ApplicationIconThreeImagePath = applicationPage?.ApplicationIconThreeImagePath ?? "";
            ViewBag.ApplicationIconFourTitle = applicationPage?.ApplicationIconFourTitle ?? "";
            ViewBag.ApplicationIconFourImagePath = applicationPage?.ApplicationIconFourImagePath ?? "";
            ViewBag.ApplicationIconFiveTitle = applicationPage?.ApplicationIconFiveTitle ?? "";
            ViewBag.ApplicationIconFiveImagePath = applicationPage?.ApplicationIconFiveImagePath ?? "";
            ViewBag.AppFeaturesSectionOneTitle = applicationPage?.AppFeaturesSectionOneTitle?? "";
            ViewBag.AppFeaturesSectionOneDescriptionSectionOne = applicationPage?.AppFeaturesSectionOneDescriptionSectionOne ?? "";
            ViewBag.AppFeaturesSectionOneDescriptionSectionTwo = applicationPage?.AppFeaturesSectionOneDescriptionSectionTwo ?? "";
            ViewBag.AppFeaturesSectionOneImagePath = applicationPage?.AppFeaturesSectionOneImagePath ?? "";
            ViewBag.AppFeaturesSectionTwoTitle = applicationPage?.AppFeaturesSectionTwoTitle ?? "";
            ViewBag.AppFeaturesSectionTwoDescriptionSectionOne = applicationPage?.AppFeaturesSectionTwoDescriptionSectionOne ?? "";
            ViewBag.AppFeaturesSectionTwoDescriptionSectionTwo = applicationPage?.AppFeaturesSectionTwoDescriptionSectionTwo ?? "";
            ViewBag.AppFeaturesSectionTwoImagePath = applicationPage?.AppFeaturesSectionTwoImagePath ?? "";
            ViewBag.AppFeaturesSectionThreeTitle = applicationPage?.AppFeaturesSectionThreeTitle ?? "";
            ViewBag.AppFeaturesSectionThreeDescriptionSectionOne = applicationPage?.AppFeaturesSectionThreeDescriptionSectionOne ?? "";
            ViewBag.AppFeaturesSectionThreeDescriptionSectionTwo = applicationPage?.AppFeaturesSectionThreeDescriptionSectionTwo ?? "";
            ViewBag.AppFeaturesSectionThreeImagePath = applicationPage?.AppFeaturesSectionThreeImagePath ?? "";
            ViewBag.AppFeaturesSectionFourthTitle = applicationPage?.AppFeaturesSectionFourthTitle ?? "";
            ViewBag.AppFeaturesSectionFourthDescriptionSectionOne = applicationPage?.AppFeaturesSectionFourthDescriptionSectionOne ?? "";
            ViewBag.AppFeaturesSectionFourthDescriptionSectionTwo = applicationPage?.AppFeaturesSectionFourthDescriptionSectionTwo ?? "";
            ViewBag.AppFeaturesSectionFourthImagePath = applicationPage?.AppFeaturesSectionFourthImagePath ?? "";

            ViewBag.AppTutorialsSectionTitle = applicationPage?.AppTutorialsSectionTitle ?? "";
            ViewBag.VideoOneTitle = applicationPage?.VideoOneTitle ?? "";
            ViewBag.VideoOneLink = applicationPage?.VideoOneLink ?? "";
            ViewBag.VideoOneThumbnailImagePath = applicationPage?.VideoOneThumbnailImagePath ?? "";
            ViewBag.VideoTwoTitle = applicationPage?.VideoTwoTitle ?? "";
            ViewBag.VideoTwoLink = applicationPage?.VideoTwoLink ?? "";
            ViewBag.VideoTwoThumbnailImagePath = applicationPage?.VideoTwoThumbnailImagePath ?? "";
            ViewBag.VideoThreeTitle = applicationPage?.VideoThreeTitle ?? "";
            ViewBag.VideoThreeLink = applicationPage?.VideoThreeLink ?? "";
            ViewBag.VideoThreeThumbnailImagePath = applicationPage?.VideoThreeThumbnailImagePath ?? "";
            ViewBag.VideoFourTitle = applicationPage?.VideoFourTitle ?? "";
            ViewBag.VideoFourLink = applicationPage?.VideoFourLink ?? "";
            ViewBag.VideoFourThumbnailImagePath = applicationPage?.VideoFourThumbnailImagePath ?? "";
            ViewBag.VideoFiveTitle = applicationPage?.VideoFiveTitle ?? "";
            ViewBag.VideoFiveLink = applicationPage?.VideoFiveLink ?? "";
            ViewBag.VideoFiveThumbnailImagePath = applicationPage?.VideoFiveThumbnailImagePath ?? "";

            ViewBag.UserGuides = userGuides;

        }

        private void GetApplicationPageIcons(string v1, string v2, string v3)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, v1);
            string folderPath = Path.Combine(uploadsFolder, v2, v3);
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToArray();

                ViewBag.ApplicationPageIconFileNames = fileNames;
            }
            else
            {
                ViewBag.ApplicationPageIconFileNames = new string[0]; // No files available
            }
        }

        private async Task<ICollection<UserGuide>> GetApplicationPAgeUserGuide()
        {
            ICollection<UserGuide> userGuides = new List<UserGuide>();

            userGuides = await _applicationPageManager.GetUserGuides();
            return await Task.FromResult(userGuides);
        }

        private void GetApplicationPageSlider(string v1, string v2, string v3)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, v1);
            string folderPath = Path.Combine(uploadsFolder, v2, v3);
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToArray();

                ViewBag.ApplicationPageSliderFileNames = fileNames;
            }
            else
            {
                ViewBag.ApplicationPageSliderFileNames = new string[0]; // No files available
            }
        }
        [HttpPost]
        public async Task<JsonResult> UpdateAboutBoxDescriptionSection(ApplicationPageRequestDTO model)
        {
            try
            {
                var applicationPage = _mapper.Map<ApplicationPage>(model);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
                string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "ApplicationPage", "AboutBox");
                //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");



                //DeleteAllFilesOfFolder(filePath, filePosition);


                string filePathToSave = string.Empty;

                if (model?.ApplePlayStoreIconImageFile != null && model?.ApplePlayStoreIconImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "1");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.ApplePlayStoreIconImageFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".svg";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    //int totalfilesOriginal;

                    //totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, ("1").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.ApplePlayStoreIconImageFile.CopyTo(fileStream);
                    }

                    var appleplayImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    applicationPage.ApplePlayStoreIconImagePath = appleplayImagePath;   

                }

                if (model?.GooglePlayStoreImageFile != null && model?.GooglePlayStoreImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "2");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.GooglePlayStoreImageFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".svg";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    
                    filePathToSave = Path.Combine(filePath, ("2").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.GooglePlayStoreImageFile.CopyTo(fileStream);   
                    }

                    var googlelayImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    applicationPage.GooglePlayStoreIconImagePath = googlelayImagePath;

                }
                if (model?.AppGalleryImageFile != null && model?.AppGalleryImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "3");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.AppGalleryImageFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".svg";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    filePathToSave = Path.Combine(filePath, ("3").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.AppGalleryImageFile.CopyTo(fileStream);
                    }

                    var appGalleryImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    applicationPage.AppGalleryIconImagePath = appGalleryImagePath;

                }


                bool result = await _applicationPageManager.UpdateAboutBoxDescriptionSection(applicationPage);

                if (result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "About Box Description Section updated successfully.",
                        redirectUrl = Url.Action("Applications", "Services")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "About Box Description Section updated failed.",
                        redirectUrl = Url.Action("Applications", "Services")
                    };
                    return Json(response);
                }


            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = true,
                    Message = "About Box Description Section updated failed.",
                    redirectUrl = Url.Action("Applications", "Services")
                };
                return Json(response);
            }


            //return Json(response);
        }



        [HttpPost]
        public async Task<JsonResult> AddUserGuides(string newValue)  
        {
            ApplicationPage applicationPage = await GetApplications();   
            UserGuide userGuide;
            bool result = false;
            if (applicationPage != null)
            {
                if (!string.IsNullOrWhiteSpace(newValue))
                {
                    userGuide = new UserGuide
                    {
                        Id = Guid.NewGuid(),
                        UserGuideText = newValue,
                        ApplicationPageId = applicationPage.Id,
                        Application = applicationPage
                    };
                    //missionVisionValues.ValuesItems.Add(valuesItem);

                    result = await _applicationPageManager.UpdateUserGuides(userGuide);

                }



            }


            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "User Guides updated successfully.",
                    redirectUrl = Url.Action("Applications", "Services")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "User Guides updated failed.",
                    redirectUrl = Url.Action("Applications", "Services")  
                };
                return Json(response);
            }


        }

        [HttpDelete]
        public async Task<JsonResult> DeleteUserGuides(string itemSerialNo)  
        {
            UserGuide userGuide = await GetUserGuidesBySerialNo(itemSerialNo);

            bool result = false;
            if (!string.IsNullOrEmpty(userGuide.UserGuideText))
            {
                result = await _applicationPageManager.DeleteUserGuides(userGuide);

            }


            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "User Guides deleted successfully.",
                    redirectUrl = Url.Action("Applications", "Services")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "User Guides delete failed.",  
                    redirectUrl = Url.Action("Applications", "Services")
                };
                return Json(response);
            }
        }

        private async Task<UserGuide> GetUserGuidesBySerialNo(string itemSerialNo)  
        {
            UserGuide userGuide = new UserGuide();
            int serial = Convert.ToInt32(itemSerialNo);
            userGuide = await _applicationPageManager.GetUserGuidesBySerialNo(serial);
            return await Task.FromResult(userGuide);
        }


        private async Task<ApplicationPage> GetApplications()
        {
            ApplicationPage applicationPage = new ApplicationPage();
            applicationPage = await _applicationPageManager.GetApplicationPage();
            return await Task.FromResult(applicationPage);
        }


        [HttpPost]
        public async Task<JsonResult> UploadApplicationPageSliderButton(MultipleFileUploadVM model)  
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            //Services/ForeignCurrency/Slider
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "ApplicationPage", "Slider");
           
            string filePosition = model.position;
            //DeleteAllFilesOfFolder(filePath, filePosition);
            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);


            ApplicationPage applicationPage = new ApplicationPage();

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
                            applicationPage.SliderOneImagePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "2")
                        {
                            applicationPage.SliderTwoImagePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "3")
                        {
                            applicationPage.SliderThreeImagePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "4")
                        {
                            applicationPage.SliderFourImagePath = ImagePath;
                        }



                    }
                    else
                    {
                        

                        totalfilesOriginal = Directory.GetFiles(filePath).Count();
                        filePathToSave = Path.Combine(filePath, (totalfilesOriginal + 1).ToString() + fileExtension);
                        var ImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                        if ((totalfilesOriginal + 1).ToString() == "1")
                        {
                            applicationPage.SliderOneImagePath = ImagePath;
                        }

                        if ((totalfilesOriginal + 1).ToString() == "2")
                        {
                            applicationPage.SliderOneImagePath = ImagePath;
                        }

                        if ((totalfilesOriginal + 1).ToString() == "3")
                        {
                            applicationPage.SliderOneImagePath = ImagePath;
                        }

                        if ((totalfilesOriginal + 1).ToString() == "4")
                        {
                            applicationPage.SliderFourImagePath = ImagePath;
                        }


                    }
                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }


                }
            }

            bool result = await _applicationPageManager.UpdateApplicationSlider(applicationPage);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Slider Image updated successfully.",
                    redirectUrl = Url.Action("Applications", "Services")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Slider Image updated failed.",
                    redirectUrl = Url.Action("Applications", "Services")
                };
                return Json(response);
            }



        }



        [HttpPost]
        public async Task<JsonResult> UploadApplicationPageIconButton(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            //Services/ForeignCurrency/Slider
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "ApplicationPage", "ApplicationIcon");

            string filePosition = model.position;
            //DeleteAllFilesOfFolder(filePath, filePosition);
            DeleteAllFilesOfFolderWithPosition(filePath, filePosition);


            ApplicationPage applicationPage = new ApplicationPage();

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
                            applicationPage.ApplicationIconOneImagePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "2")
                        {
                            applicationPage.ApplicationIconTwoImagePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "3")
                        {
                            applicationPage.ApplicationIconThreeImagePath = ImagePath;
                        }

                        if (totalfilesOriginal.ToString() == "4")
                        {
                            applicationPage.ApplicationIconFourImagePath = ImagePath;
                        }
                        if (totalfilesOriginal.ToString() == "5")
                        {
                            applicationPage.ApplicationIconFiveImagePath = ImagePath;
                        }
                        if (totalfilesOriginal.ToString() == "6")
                        {
                            applicationPage.ApplicationIconSixImagePath = ImagePath;
                        }

                    }
                    else
                    {


                        totalfilesOriginal = Directory.GetFiles(filePath).Count();
                        filePathToSave = Path.Combine(filePath, (totalfilesOriginal + 1).ToString() + fileExtension);
                        var ImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                        if ((totalfilesOriginal + 1).ToString() == "1")
                        {
                            applicationPage.ApplicationIconOneImagePath = ImagePath;
                        }

                        if ((totalfilesOriginal + 1).ToString() == "2")
                        {
                            applicationPage.ApplicationIconTwoImagePath = ImagePath;
                        }

                        if ((totalfilesOriginal + 1).ToString() == "3")
                        {
                            applicationPage.ApplicationIconThreeImagePath = ImagePath;
                        }

                        if ((totalfilesOriginal + 1).ToString() == "4")
                        {
                            applicationPage.ApplicationIconFourImagePath = ImagePath;
                        }
                        if ((totalfilesOriginal + 1).ToString() == "5")
                        {
                            applicationPage.ApplicationIconFiveImagePath = ImagePath;
                        }
                        if ((totalfilesOriginal + 1).ToString() == "6")
                        {
                            applicationPage.ApplicationIconSixImagePath = ImagePath;
                        }


                    }
                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }


                }
            }

            bool result = await _applicationPageManager.UpdateApplicationIcon(applicationPage);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Application Icon updated successfully.",
                    redirectUrl = Url.Action("Applications", "Services")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Application Icon updated failed.",
                    redirectUrl = Url.Action("Applications", "Services")
                };
                return Json(response);
            }



        }


        [HttpPost]
        public async Task<JsonResult> UpdateApplicationAppFeaturesSection(ApplicationPageRequestDTO model)  
        {
            try
            {
                var applicationPage = _mapper.Map<ApplicationPage>(model);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
                string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "ApplicationPage", "AppFeatures");
                //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");



                //DeleteAllFilesOfFolder(filePath, filePosition);


                string filePathToSave = string.Empty;

                if (model?.AppFeaturesSectionOneImageFile != null && model?.AppFeaturesSectionOneImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "1");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.AppFeaturesSectionOneImageFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".webp";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, ("1").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.AppFeaturesSectionOneImageFile.CopyTo(fileStream);
                    }

                    var appFeaturesSectionOneImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    applicationPage.AppFeaturesSectionOneImagePath = appFeaturesSectionOneImagePath;

                }

                if (model?.AppFeaturesSectionTwoImageFile != null && model?.AppFeaturesSectionTwoImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "2");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.AppFeaturesSectionTwoImageFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".webp";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    
                    filePathToSave = Path.Combine(filePath, ("2").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.AppFeaturesSectionTwoImageFile.CopyTo(fileStream);
                    }

                    var appFeaturesSectionTwoImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    applicationPage.AppFeaturesSectionTwoImagePath  = appFeaturesSectionTwoImagePath;

                }
                if (model?.AppFeaturesSectionThreeImageFile != null && model?.AppFeaturesSectionThreeImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "3");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.AppFeaturesSectionThreeImageFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".webp";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, ("3").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.AppFeaturesSectionThreeImageFile.CopyTo(fileStream);
                    }

                    var appFeaturesSectionThreeImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    applicationPage.AppFeaturesSectionThreeImagePath = appFeaturesSectionThreeImagePath;

                }
                if (model?.AppFeaturesSectionFourthImageFile != null && model?.AppFeaturesSectionFourthImageFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "4");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.AppFeaturesSectionFourthImageFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".webp";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, ("4").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.AppFeaturesSectionFourthImageFile.CopyTo(fileStream);
                    }

                    var appFeaturesSectionFourthImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    applicationPage.AppFeaturesSectionFourthImagePath = appFeaturesSectionFourthImagePath;

                }




                bool result = await _applicationPageManager.UpdateAppFeaturesSection(applicationPage);

                if (result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "App Features Section updated successfully.",
                        redirectUrl = Url.Action("Applications", "Services")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "App Features Section updated failed.",
                        redirectUrl = Url.Action("Applications", "Services")
                    };
                    return Json(response);
                }


            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = true,
                    Message = "First section left updated failed.",
                    redirectUrl = Url.Action("Remittances", "Services")
                };
                return Json(response);
            }


            //return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateApplicationPageVideoLink(ApplicationPageRequestDTO model)
        {
            var applicationPage = _mapper.Map<ApplicationPage>(model);

            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "ApplicationPage", "VideosThumbnail");


            string filePathToSave = string.Empty;

            if (model?.VideoOneThumbnailImageFile != null && model?.VideoOneThumbnailImageFile.Length > 0)
            {
                DeleteAllFilesOfFolderWithPosition(filePath, "1");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.VideoOneThumbnailImageFile.FileName;
                //string fileExtension = Path.GetExtension(file.FileName);
                string fileExtension = ".webp";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                int totalfilesOriginal;

                totalfilesOriginal = Directory.GetFiles(filePath).Count();
                filePathToSave = Path.Combine(filePath, (1).ToString() + fileExtension);

                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    model?.VideoOneThumbnailImageFile.CopyTo(fileStream);
                }

                var videoOneThumbnailImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                applicationPage.VideoOneThumbnailImagePath = videoOneThumbnailImagePath;
            }

            if (model?.VideoTwoThumbnailImageFile != null && model?.VideoTwoThumbnailImageFile.Length > 0)
            {
                DeleteAllFilesOfFolderWithPosition(filePath, "2");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.VideoTwoThumbnailImageFile.FileName;
                //string fileExtension = Path.GetExtension(file.FileName);
                string fileExtension = ".webp";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                int totalfilesOriginal;

                totalfilesOriginal = Directory.GetFiles(filePath).Count();
                filePathToSave = Path.Combine(filePath, (2).ToString() + fileExtension);

                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    model?.VideoTwoThumbnailImageFile.CopyTo(fileStream);
                }

                var videoTwoThumbnailImageFilePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                applicationPage.VideoOneThumbnailImagePath = videoTwoThumbnailImageFilePath;
            }


            if (model?.VideoThreeThumbnailImageFile != null && model?.VideoThreeThumbnailImageFile.Length > 0)
            {
                DeleteAllFilesOfFolderWithPosition(filePath, "3");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.VideoThreeThumbnailImageFile.FileName;
                //string fileExtension = Path.GetExtension(file.FileName);
                string fileExtension = ".webp";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                int totalfilesOriginal;

                totalfilesOriginal = Directory.GetFiles(filePath).Count();
                filePathToSave = Path.Combine(filePath, (3).ToString() + fileExtension);

                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    model?.VideoThreeThumbnailImageFile.CopyTo(fileStream);
                }

                var videoThreeThumbnailImageFilePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                applicationPage.VideoThreeThumbnailImagePath = videoThreeThumbnailImageFilePath;
            }
            if (model?.VideoFourThumbnailImageFile != null && model?.VideoFourThumbnailImageFile.Length > 0)
            {
                DeleteAllFilesOfFolderWithPosition(filePath, "4");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.VideoFourThumbnailImageFile.FileName;
                //string fileExtension = Path.GetExtension(file.FileName);
                string fileExtension = ".webp";
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                int totalfilesOriginal;

                totalfilesOriginal = Directory.GetFiles(filePath).Count();
                filePathToSave = Path.Combine(filePath, (4).ToString() + fileExtension);

                using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                {
                    model?.VideoFourThumbnailImageFile.CopyTo(fileStream);
                }

                var videoThreeThumbnailImageFilePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                applicationPage.VideoFourThumbnailImagePath = videoThreeThumbnailImageFilePath;
            }


            bool result = await _applicationPageManager.UpdateApplicationPageVideoLink(applicationPage);

            var response = new
            {
                Success = true,
                Message = "Video Link updated successfully.",
                redirectUrl = Url.Action("Applications", "Services")
            };


            return Json(response);
        }


    }
}
