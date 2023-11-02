using AlmuzainiCMS.BLL.BLL;
using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AlmuzainiCMS.Models.RequestDto;

namespace AlmuzainiCMS.Controllers
{
    public class BranchesController : Controller
    {
        private readonly IBranchManager _branchManager;
        private readonly ILogger<ServicesController> _logger;

        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public BranchesController(ILogger<ServicesController> logger, IMapper mapper, IWebHostEnvironment webHostEnvironment, IBranchManager branchManager)
        {
            _branchManager = branchManager;
            _logger = logger;
            _mapper = mapper;
            _hostingEnvironment = webHostEnvironment;
        }

        public IActionResult Branches()
        {
            GetTopBranchSlider("uploads", "original", "Branch", "Banner");

            GetBranchToptitleandText();

            //Branch branch = _branchManager.GetBranchTopBanner();

            //ViewBag.BranchesTopBannerImageFileNames = branch?.BranchesTopBannerImagePath ?? "";

            return View();
        }

        private void GetBranchToptitleandText()
        {
            List<BranchTopText> branchTopTexts = _branchManager.GetBranchTopText();

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
    }
}
