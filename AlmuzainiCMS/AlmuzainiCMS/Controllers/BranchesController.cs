﻿using AlmuzainiCMS.BLL.BLL;
using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AlmuzainiCMS.Models.RequestDto;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AlmuzainiCMS.Controllers
{
    public class BranchesController : Controller
    {
        private readonly ILogger<ServicesController> _logger;

        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;

        private readonly IBranchManager _branchManager;
        private readonly IKoiskManager _koiskManager;

        public BranchesController(ILogger<ServicesController> logger, IMapper mapper, IWebHostEnvironment webHostEnvironment, IBranchManager branchManager, IKoiskManager koiskManager)
        {
            _logger = logger;
            _mapper = mapper;
            _hostingEnvironment = webHostEnvironment;

            _branchManager = branchManager;
            _koiskManager = koiskManager;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

            string? SessionName = HttpContext.Session.GetString("_userName");
            string? SessionAge = HttpContext.Session.GetString("_userPass");
            if (SessionAge == null || SessionName == null)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
                return;
            }
        }

        public IActionResult Branches()
        {
            GetTopBranchSlider("uploads", "original", "Branch", "Banner");

            GetBranchToptitleandText();

            GetBranch();

            return View();
        }

        [HttpGet]
        public IActionResult Koisk()
        {
            GetTopKoiskSlider("uploads", "original", "Koisk", "Banner");
            GetKoiskDetails();

            return View();
        }


        private void GetBranchToptitleandText()
        {
            List<BranchTopText> branchTopTexts = _branchManager.GetBranchTopText();

            branchTopTexts = branchTopTexts.OrderByDescending(b => b.CreatedAt).ToList();

            BranchTopText latestTopText = branchTopTexts.FirstOrDefault();

            ViewBag.Title = latestTopText?.Title;
            ViewBag.Description = latestTopText?.Description;

        }


        public void GetTopBranchSlider(string folderName, string subfolder, string typefolder, string mainfolder)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder, mainfolder);
            // Replace with the actual folder path

            if (Directory.Exists(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToArray();

                ViewBag.BranchesTopBannerImageFileNames = fileNames;
            }
            else
            {
                ViewBag.BranchesTopBannerImageFileNames = new string[0]; // No files available
            }

        }

        [HttpPost]

        public async Task<JsonResult> UploadBanchesTopBanner(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Branch", "Banner");

            string filePosition = model.position;

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
            var branchBannerImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");

            Branch branch = new Branch();
            branch.BranchesTopBannerImagePath = branchBannerImagePath;
            bool result = await _branchManager.UpdateBranchBannerImagePath(branch);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Promotion Banner updated successfully.",
                    redirectUrl = Url.Action("Branches", "Branches")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Promotion Banner updated failed.",
                    redirectUrl = Url.Action("Branches", "Branches")
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

        public async Task<JsonResult> uploadTopText(BranchTopTextRequestDTO model)
        {
            BranchTopText topText = new BranchTopText
            {
                Title = model.Title ?? "",
                Description = model.Description ?? "",
                CreatedAt = DateTime.Now

            };

            bool result = await _branchManager.AddBranchTopText(topText);

            var response = new
            {
                Success = true,
                Message = "Top Text uploaded successfully.",
                redirectUrl = Url.Action("Branches", "Branches")
            };

            return Json(response);

        }


        [HttpPost]

        public async Task<JsonResult> uploadBranchInfo(BranchDetailRequestDTO model)
        {
            BranchDetail branchDetail = new BranchDetail
            {
                SelectedDropdownValue = model.SelectedDropdownValue,
                BusinessType = model.BusinessType,
                Area = model.Area ?? "",
                Adress = model.Adress ?? "",
                Time = model.Time ?? "",
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Map = model.Map ?? "",
                CreatedAt = DateTime.Now

            };

            bool result = await _branchManager.AddBranchdetails(branchDetail);


            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Branch details uploaded successfully.",
                    redirectUrl = Url.Action("Branches", "Branches")
                };

                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Branch details upload failed.",
                    redirectUrl = Url.Action("Branches", "Branches")
                };

                return Json(response);
            }

        }

        private void GetBranch()
        {
            List<BranchDetail> branch = _branchManager.GetBranchDetails();

            List<LatestBranchVM> latestBranchList = new List<LatestBranchVM>();

            foreach (BranchDetail branchItem in branch)
            {


                TimeSpan timeDifference = (TimeSpan)(DateTime.Now - branchItem.CreatedAt);

                int days = timeDifference.Days;
                int hours = timeDifference.Hours;

                int minutes = timeDifference.Minutes;
                int seconds = timeDifference.Seconds;

                string updatedAt = days > 1 ? days.ToString() + " days ago" : days == 1 ? " yesterday" : hours > 1 ? hours.ToString() + " hours ago" : hours == 1 ? hours.ToString() + " hour ago" : minutes > 1 ? minutes.ToString() + " minutes ago" : minutes == 1 ? minutes.ToString() + " minute ago" : seconds.ToString() + " seconds ago";



                LatestBranchVM latestBranchItem = new LatestBranchVM
                {
                    Id = branchItem.Id,
                    SelectedDropdownValue = branchItem.SelectedDropdownValue,
                    BusinessType = branchItem.BusinessType,
                    Area = branchItem.Area,
                    Adress = branchItem.Adress,
                    Time = branchItem.Time,
                    Latitude = (double)branchItem.Latitude,
                    Longitude = (double)branchItem.Longitude,
                    Map = branchItem.Map,

                    //UpdatedAt = $"{days} days, {hours} hours, {minutes} minutes, {seconds} seconds ago"
                    UpdatedAt = updatedAt
                };

                latestBranchList.Add(latestBranchItem);


            }

            ViewBag.LiveBranches = latestBranchList; // No files available
        }

        public async Task<JsonResult> GetBranchById(Guid id)
        {
            BranchDetail branch = await _branchManager.GetBranchById(id);

            if (branch != null)
            {
                return Json(new
                {
                    selectedDropdownValue = branch.SelectedDropdownValue,
                    businessType = branch.BusinessType,
                    area = branch.Area,
                    address = branch.Adress,
                    time = branch.Time,
                    latitude = branch.Latitude,
                    longitude = branch.Longitude,
                    map = branch.Map
                });
            }
            else
            {
                return Json(new { error = "Branch not found" });
            }
        }

        [HttpPost]
        public async Task<JsonResult> DeleteBranch(Guid id)
        {
            bool result = await _branchManager.DeleteBranchById(id);

            if (result)
            {
                return Json(new
                {
                    success = true,
                    message = "Branch detail deleted successfully."
                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    message = "Failed to delete branch detail."
                });
            }
        }


        [HttpPost]
        public async Task<JsonResult> UpdateBranchDetails(BranchDetailRequestDTO model)
        {
            BranchDetail branchDetail = new BranchDetail
            {
                Id = model.Id,

                SelectedDropdownValue = model.SelectedDropdownValue,
                BusinessType = model.BusinessType,
                Area = model.Area,
                Adress = model.Adress,
                Time = model.Time,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Map = model.Map,

                CreatedAt = DateTime.Now

            };

            bool result = await _branchManager.UpdateBranchdetails(branchDetail);

            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Branch deatail edited successfully.",
                    redirectUrl = Url.Action("Branches", "Branches")
                };

                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "Branch details uploaded successfully.",
                    redirectUrl = Url.Action("Branches", "Branches")
                };

                return Json(response);
            }
        }







        //////////////////////////////////////////////////////////
        /////// Koisk
        //////////////////////////////////////////////////////////

        [HttpPost]

        public async Task<JsonResult> UploadKoiskBanner(MultipleFileUploadVM model)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath);
            string filePath = Path.Combine(uploadsFolder, "Uploads", "original", "Koisk", "Banner");

            string filePosition = model.position;

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
            var koiskBannerImagePath = ".." + filePathToSave.Substring(uploadsFolder.Length).Replace("\\", "/");
            KoiskBanner koiskBanner = new KoiskBanner();
            koiskBanner.KoiskTopBannerImagePath = koiskBannerImagePath;

            bool result = await _koiskManager.UpdateKoiskBannerImagePath(koiskBanner);



            if (result == true)
            {
                var response = new
                {
                    Success = true,
                    Message = "Koisk Banner updated successfully.",
                    redirectUrl = Url.Action("Koisk", "Branches")
                };
                return Json(response);
            }
            else
            {
                var response = new
                {
                    Success = true,
                    Message = "koisk Banner updated failed.",
                    redirectUrl = Url.Action("Koisk", "Branches")
                };
                return Json(response);
            }
        }


        public void GetTopKoiskSlider(string folderName, string subfolder, string typefolder, string mainfolder)
        {
            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, folderName);
            string folderPath = Path.Combine(uploadsFolder, subfolder, typefolder, mainfolder);

            if (Directory.Exists(folderPath))
            {
                string[] fileNames = Directory.GetFiles(folderPath)
                    .Select(Path.GetFileName)
                    .ToArray();

                ViewBag.KoiskBannerPath = fileNames;
            }
            else
            {
                ViewBag.KoiskBannerPath = new string[0];
            }

        }




        [HttpPost]

        public async Task<JsonResult> uploadKoiskDetail(KoiskDetailRequestDTO model)
        {
            KoiskDetail koiskDetail = new KoiskDetail
            {
                PageTitle = model.PageTitle ?? "",
                SectionHeaderText = model.SectionHeaderText ?? "",
                FirstSectionText = model.FirstSectionText ?? "",
                SecondSectionText = model.SecondSectionText ?? "",
                ThirdSectionText = model.ThirdSectionText ?? "",
                FourthSectionText = model.FourthSectionText ?? "",
                FifthSectionText = model.FifthSectionText ?? "",
                SixthSectionText = model.SixthSectionText ?? "",
                DownloadText = model.DownloadText ?? "",
                CreatedAt = DateTime.Now

            };

        bool result = await _koiskManager.AddKoiskDetail(koiskDetail);

            var response = new
            {
                Success = true,
                Message = "Details uploaded successfully.",
                redirectUrl = Url.Action("Koisk", "Branches")
            };

            return Json(response);

        }


        private void GetKoiskDetails()
        {
            List<KoiskDetail> koiskDetail = _koiskManager.GetKoiskDetail();

            koiskDetail = koiskDetail.OrderByDescending(b => b.CreatedAt).ToList();

            KoiskDetail latestkoiskDetail = koiskDetail.FirstOrDefault();

            ViewBag.PageTitle = latestkoiskDetail?.PageTitle;
            ViewBag.SectionHeaderText = latestkoiskDetail?.SectionHeaderText;
            ViewBag.FirstSectionText = latestkoiskDetail?.FirstSectionText;
            ViewBag.SecondSectionText = latestkoiskDetail?.SecondSectionText;
            ViewBag.ThirdSectionText = latestkoiskDetail?.ThirdSectionText;
            ViewBag.FourthSectionText = latestkoiskDetail?.FourthSectionText;
            ViewBag.FifthSectionText = latestkoiskDetail?.FifthSectionText;
            ViewBag.SixthSectionText = latestkoiskDetail?.SixthSectionText;
            ViewBag.DownloadText = latestkoiskDetail?.DownloadText;
        }

    }
}
