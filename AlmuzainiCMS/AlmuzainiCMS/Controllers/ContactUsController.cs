using AlmuzainiCMS.BLL.BLL;
using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models;
using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models.RequestDto;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AlmuzainiCMS.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly ILogger<ServicesController> _logger;

        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IContactUsManager _contactUsManager;

        public ContactUsController(ILogger<ServicesController> logger, IMapper mapper, IWebHostEnvironment hostingEnvironment, IContactUsManager contactUsManager)
        {
            _logger = logger;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
            _contactUsManager = contactUsManager;
        }
        public IActionResult Index()
        {
            GetContactUs();
            return View();
        }

        private async void GetContactUs()
        {
            ContactUs contactUs = new ContactUs();
            contactUs = await _contactUsManager.GetContactUs();

            ViewBag.BannerImagePath = contactUs?.BannerImagePath ?? "";
            ViewBag.InnerSectionTitle = contactUs?.InnerSectionTitle ?? "";
            ViewBag.LeftSectionTitle = contactUs?.LeftSectionTitle ?? "";
            ViewBag.LeftSubOneSectionTitle = contactUs?.LeftSubOneSectionTitle ?? "";
            ViewBag.LeftSubOneSectionText = contactUs?.LeftSubOneSectionText ?? "";
            ViewBag.LeftSubOneSectionIconPath = contactUs?.LeftSubOneSectionIconPath ?? "";
            ViewBag.LeftSubTwoSectionTitle = contactUs?.LeftSubTwoSectionTitle ?? "";
            ViewBag.LeftSubTwoSectionText = contactUs?.LeftSubTwoSectionText ?? "";
            ViewBag.LeftSubTwoSectionIconPath = contactUs?.LeftSubTwoSectionIconPath ?? ""; 
            ViewBag.LeftSubThreeSectionTitle = contactUs?.LeftSubThreeSectionTitle ?? "";
            ViewBag.LeftSubThreeSectionText = contactUs?.LeftSubThreeSectionText ?? "";
            ViewBag.LeftSubThreeSectionIconPath = contactUs?.LeftSubThreeSectionIconPath ?? ""; 
            ViewBag.LeftSubFourSectionTitle = contactUs?.LeftSubFourSectionTitle ?? "";
            ViewBag.LeftSubFourSectionText = contactUs?.LeftSubFourSectionText ?? "";
            ViewBag.LeftSubFourSectionIconPath = contactUs?.LeftSubFourSectionIconPath ?? "";
            ViewBag.LeftSubFiveSectionTitle = contactUs?.LeftSubFiveSectionTitle ?? "";
            ViewBag.LeftSubFiveSectionText = contactUs?.LeftSubFiveSectionText ?? "";
            ViewBag.LeftSubFiveSectionIconPath = contactUs?.LeftSubFiveSectionIconPath ?? "";

            ViewBag.RightSectionTitle = contactUs?.RightSectionTitle ?? "";
            ViewBag.RightSubOneSectionTitle = contactUs?.RightSubOneSectionTitle ?? "";
            ViewBag.RightSubOneSectionText = contactUs?.RightSubOneSectionText ?? "";
            ViewBag.RightSubOneSectionIconPath = contactUs?.RightSubOneSectionIconPath ?? "";
            ViewBag.RightSubTwoSectionTitle = contactUs?.RightSubTwoSectionTitle ?? "";
            ViewBag.RightSubTwoSectionText = contactUs?.RightSubTwoSectionText ?? "";
            ViewBag.RightSubTwoSectionIconPath = contactUs?.RightSubTwoSectionIconPath ?? "";
            ViewBag.RightSubThreeSectionTitle = contactUs?.RightSubThreeSectionTitle ?? "";
            ViewBag.RightSubThreeSectionText = contactUs?.RightSubThreeSectionText ?? "";
            ViewBag.RightSubThreeSectionIconPath = contactUs?.RightSubThreeSectionIconPath ?? "";
            ViewBag.RightSubFourSectionTitle = contactUs?.RightSubFourSectionTitle ?? "";
            ViewBag.RightSubFourSectionText = contactUs?.RightSubFourSectionText ?? "";
            ViewBag.RightSubFourSectionIconPath = contactUs?.RightSubFourSectionIconPath ?? "";


            ViewBag.NewsSectionOneTitle = contactUs?.NewsSectionOneTitle ?? "";
            ViewBag.NewsSectionOneText = contactUs?.NewsSectionOneText ?? "";
            ViewBag.NewsSectionOneImageath = contactUs?.NewsSectionOneImageath ?? "";
            ViewBag.NewsSectionTwoTitle = contactUs?.NewsSectionTwoTitle ?? "";
            ViewBag.NewsSectionTwoText = contactUs?.NewsSectionTwoText ?? "";
            ViewBag.NewsSectionTwoImageath = contactUs?.NewsSectionTwoImageath ?? "";
            ViewBag.NewsSectionThreeTitle = contactUs?.NewsSectionThreeTitle ?? "";
            ViewBag.NewsSectionThreeText = contactUs?.NewsSectionThreeText ?? "";
            ViewBag.NewsSectionThreeImageath = contactUs?.NewsSectionThreeImageath ?? "";
            ViewBag.NewsSectionFourTitle = contactUs?.NewsSectionFourTitle ?? "";
            ViewBag.NewsSectionFourText = contactUs?.NewsSectionFourText ?? "";
            ViewBag.NewsSectionFourImageath = contactUs?.NewsSectionFourImageath ?? "";
            ViewBag.NewsSectionFiveTitle = contactUs?.NewsSectionFiveTitle ?? "";
            ViewBag.NewsSectionFiveText = contactUs?.NewsSectionFiveText ?? "";
            ViewBag.NewsSectionFiveImageath = contactUs?.NewsSectionFiveImageath ?? "";



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
        public async Task<JsonResult> UploadBanner(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "ContactUs", "Banner");
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
            ContactUs contactUS = new ContactUs();
            contactUS.BannerImagePath = bannerImagePath;
            //companyHistory.ExpertiseImagePath = filePathToSave;
            bool result = await _contactUsManager.UpdateBannerImagePath(contactUS);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = " Banner updated successfully.",
                    redirectUrl = Url.Action("Index", "ContactUs")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = " Banner updated failed.",
                    redirectUrl = Url.Action("Index", "ContactUs")
                };
                return Json(response);
            }
        }


        [HttpPost]
        public async Task<JsonResult> UpdateInnerSection(COntactUsRequestDTO model)
        {
            var contactUs = _mapper.Map<ContactUs>(model);
            bool result = await _contactUsManager.UpdateInnerSection(contactUs);

            var response = new
            {
                Success = true,
                Message = "Contact Us Inner section updated successfully.",
                redirectUrl = Url.Action("Index", "ContactUs")
            };


            return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateContactUsLeftSection(COntactUsRequestDTO model)
        {
            try
            {
                var contactUS = _mapper.Map<ContactUs>(model);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
                string filePath = Path.Combine(uploadsFolder, "Uploads", "original",  "ContactUs", "LeftSections");
                //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");



                //DeleteAllFilesOfFolder(filePath, filePosition);


                string filePathToSave = string.Empty;

                if (model?.LeftSubOneSectionIconFile != null && model?.LeftSubOneSectionIconFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "1");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.LeftSubOneSectionIconFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".svg";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, ("1").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.LeftSubOneSectionIconFile.CopyTo(fileStream);
                    }

                    var leftSubOneSectionIconImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    contactUS.LeftSubOneSectionIconPath = leftSubOneSectionIconImagePath;

                }


                if (model?.LeftSubTwoSectionIconFile != null && model?.LeftSubTwoSectionIconFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "2");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.LeftSubTwoSectionIconFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".svg";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, ("2").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.LeftSubTwoSectionIconFile.CopyTo(fileStream);
                    }

                    var leftSubTwoSectionIconImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    contactUS.LeftSubTwoSectionIconPath = leftSubTwoSectionIconImagePath;

                }
                if (model?.LeftSubTwoSectionIconFile != null && model?.LeftSubTwoSectionIconFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "2");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.LeftSubTwoSectionIconFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".svg";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, ("2").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.LeftSubTwoSectionIconFile.CopyTo(fileStream);
                    }

                    var leftSubTwoSectionIconImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    contactUS.LeftSubTwoSectionIconPath = leftSubTwoSectionIconImagePath;

                }


                if (model?.LeftSubThreeSectionIconFile != null && model?.LeftSubThreeSectionIconFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "3");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.LeftSubThreeSectionIconFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".svg";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, ("3").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.LeftSubThreeSectionIconFile.CopyTo(fileStream);
                    }

                    var leftSubThreeSectionIconImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    contactUS.LeftSubThreeSectionIconPath = leftSubThreeSectionIconImagePath;

                }

                if (model?.LeftSubFourSectionIconFile != null && model?.LeftSubFourSectionIconFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "4");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.LeftSubFourSectionIconFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".svg";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, ("4").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.LeftSubFourSectionIconFile.CopyTo(fileStream);
                    }

                    var leftSubFourSectionIconImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    contactUS.LeftSubFourSectionIconPath = leftSubFourSectionIconImagePath;

                }

                if (model?.LeftSubFiveSectionIconFile != null && model?.LeftSubFiveSectionIconFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "5");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.LeftSubFiveSectionIconFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".svg";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, ("5").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.LeftSubFiveSectionIconFile.CopyTo(fileStream);
                    }

                    var leftSubFiveSectionIconImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    contactUS.LeftSubFiveSectionIconPath = leftSubFiveSectionIconImagePath;

                }



                bool result = await _contactUsManager.UpdateLeftSection(contactUS);

                if (result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Left Section updated successfully.",
                        redirectUrl = Url.Action("Index", "ContactUs")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "App Features Section updated failed.",
                        redirectUrl = Url.Action("Index", "ContactUs")
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
                    redirectUrl = Url.Action("Index", "ContactUs")
                };
                return Json(response);
            }


            //return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateContactUsRightSection(COntactUsRequestDTO model)
        {
            try
            {
                var contactUS = _mapper.Map<ContactUs>(model);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
                string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "ContactUs", "RightSections");
                //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");



                //DeleteAllFilesOfFolder(filePath, filePosition);


                string filePathToSave = string.Empty;

                if (model?.RightSubOneSectionIconFile != null && model?.RightSubOneSectionIconFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "1");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.RightSubOneSectionIconFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".svg";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, ("1").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.RightSubOneSectionIconFile.CopyTo(fileStream);
                    }

                    var RightSubOneSectionIconImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    contactUS.RightSubOneSectionIconPath = RightSubOneSectionIconImagePath;

                }


                if (model?.RightSubTwoSectionIconFile != null && model?.RightSubTwoSectionIconFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "2");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.RightSubTwoSectionIconFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".svg";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, ("2").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.RightSubTwoSectionIconFile.CopyTo(fileStream);
                    }

                    var RightSubTwoSectionIconImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    contactUS.RightSubTwoSectionIconPath = RightSubTwoSectionIconImagePath;

                }
              


                if (model?.RightSubThreeSectionIconFile != null && model?.RightSubThreeSectionIconFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "3");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.RightSubThreeSectionIconFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".svg";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, ("3").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.RightSubThreeSectionIconFile.CopyTo(fileStream);
                    }

                    var RightSubThreeSectionIconImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    contactUS.RightSubThreeSectionIconPath = RightSubThreeSectionIconImagePath;

                }

                if (model?.RightSubFourSectionIconFile != null && model?.RightSubFourSectionIconFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "4");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.RightSubFourSectionIconFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".svg";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, ("4").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.RightSubFourSectionIconFile.CopyTo(fileStream);
                    }

                    var RightSubFourSectionIconImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    contactUS.RightSubFourSectionIconPath = RightSubFourSectionIconImagePath;

                }

               



                bool result = await _contactUsManager.UpdateRightSection(contactUS);

                if (result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Right Section updated successfully.",
                        redirectUrl = Url.Action("Index", "ContactUs")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "Right Section updated failed.",
                        redirectUrl = Url.Action("Index", "ContactUs")
                    };
                    return Json(response);
                }


            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = true,
                    Message = "Right section updated failed.",
                    redirectUrl = Url.Action("Index", "ContactUs")
                };
                return Json(response);
            }


            //return Json(response);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateNewsSection(COntactUsRequestDTO model)    
        {
            try
            {
                var contactUS = _mapper.Map<ContactUs>(model);

                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
                string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Services", "ContactUs", "NewsSection");
                //string thumbnailPath = Path.Combine(uploadsFolder, "thumbnails", "TopSlider");



                //DeleteAllFilesOfFolder(filePath, filePosition);


                string filePathToSave = string.Empty;

                if (model?.NewsSectionOneImagFile != null && model?.NewsSectionOneImagFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "1");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.NewsSectionOneImagFile.FileName;
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
                        model?.NewsSectionOneImagFile.CopyTo(fileStream);
                    }

                    var NewsSectionOneImagFile = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    contactUS.NewsSectionOneImageath = NewsSectionOneImagFile;

                }


                if (model?.NewsSectionTwoImagFile != null && model?.NewsSectionTwoImagFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "2");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.NewsSectionTwoImagFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".webp";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, ("2").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.NewsSectionTwoImagFile.CopyTo(fileStream);
                    }

                    var NewsSectionTwoImagFile = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    contactUS.NewsSectionTwoImageath = NewsSectionTwoImagFile;

                }



                if (model?.NewsSectionThreeImagFile != null && model?.NewsSectionThreeImagFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "3");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.NewsSectionThreeImagFile.FileName;
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
                        model?.NewsSectionThreeImagFile.CopyTo(fileStream);
                    }

                    var NewsSectionThreeImagPath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    contactUS.NewsSectionThreeImageath = NewsSectionThreeImagPath;

                }

                if (model?.NewsSectionFourImagFile != null && model?.NewsSectionFourImagFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "4");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.NewsSectionFourImagFile.FileName;
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
                        model?.NewsSectionFourImagFile.CopyTo(fileStream);
                    }

                    var NewsSectionFourSectionIconImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    contactUS.NewsSectionFourImageath = NewsSectionFourSectionIconImagePath;

                }
                if (model?.NewsSectionFiveImagFile != null && model?.NewsSectionFiveImagFile.Length > 0)
                {
                    DeleteAllFilesOfFolderWithPosition(filePath, "5");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + model?.NewsSectionFiveImagFile.FileName;
                    //string fileExtension = Path.GetExtension(file.FileName);
                    string fileExtension = ".webp";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    int totalfilesOriginal;

                    totalfilesOriginal = Directory.GetFiles(filePath).Count();
                    filePathToSave = Path.Combine(filePath, ("5").ToString() + fileExtension);

                    using (var fileStream = new FileStream(filePathToSave, FileMode.Create))
                    {
                        model?.NewsSectionFiveImagFile.CopyTo(fileStream);
                    }

                    var NewsSectionFiveSectionIconImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

                    contactUS.NewsSectionFiveImageath = NewsSectionFiveSectionIconImagePath;

                }





                bool result = await _contactUsManager.UpdateNewsSection(contactUS);

                if (result == true)
                {
                    var response = new
                    {
                        Success = true,
                        Message = "News Section updated successfully.",
                        redirectUrl = Url.Action("Index", "ContactUs")
                    };
                    return Json(response);
                }
                else
                {
                    var response = new
                    {
                        Success = true,
                        Message = "News Section updated failed.",
                        redirectUrl = Url.Action("Index", "ContactUs")
                    };
                    return Json(response);
                }


            }
            catch (Exception ex)
            {
                var response = new
                {
                    Success = true,
                    Message = "News section updated failed.",
                    redirectUrl = Url.Action("Index", "ContactUs")
                };
                return Json(response);
            }


            //return Json(response);
        }

    }
}
