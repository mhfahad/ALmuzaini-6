using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class ValueAddedBinifitsRequestDTO
    {
        public IFormFile? ValueAddedBinifitsBannerImageFile { get; set; }
        public string? BannerImagePath { get; set; }
        public string? InnerSectionTitle { get; set; }
        public string? InnerSectionDescription { get; set; }


        public string? LeftSectionFirstText { get; set; }
        public string? LeftSectionFirstTitle { get; set; }
        public string? LeftSectionFirstImagePath { get; set; }
        public IFormFile? LeftSectionFirstImageFile { get; set; }

        public string? LeftSectionSecondText { get; set; }
        public string? LeftSectionSecondTitle { get; set; }
        public string? LeftSectionSecondImagePath { get; set; }
        public IFormFile? LeftSectionSecondImageFile { get; set; }

        public string? LeftSectionThirdTitle { get; set; }

        public string? LeftSectionThirdText { get; set; }
        public string? LeftSectionThirdImagePath { get; set; }
        public IFormFile? LeftSectionThirdImageFile { get; set; }

        public string? RightSectionFirstTitle { get; set; }  

        public string? RightSectionFirstText { get; set; }
        public string? RightSectionFirstImagePath { get; set; }
        public IFormFile? RightSectionFirstImageFile { get; set; }
        public string? RightSectionSecondTitle { get; set; }

        public string? RightSectionSecondText { get; set; }
        public string? RightSectionSecondImagePath { get; set; }
        public IFormFile? RightSectionSecondImageFile { get; set; }
        public string? RightSectionThirdTitle { get; set; }  

        public string? RightSectionThirdText { get; set; }
        public string? RightSectionThirdImagePath { get; set; }
        public IFormFile? RightSectionThirdImageFile { get; set; }
        public string? RightSectionFourthTitle { get; set; }  

        public string? RightSectionFourthText { get; set; }
        public string? RightSectionFourthImagePath { get; set; }
        public IFormFile? RightSectionFourthImageFile { get; set; }  

    }
}
