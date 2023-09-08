using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class RemittancesRequestDTO
    {
        public IFormFile? BannerImageFile { get; set; }
        public string? BannerImagePath { get; set; }
        public string? InnerSectionTitle { get; set; }
        public string? InnerSectionDescription { get; set; }

        public IFormFile? SliderOneImageFile { get; set; }
        public IFormFile? SliderTwoImageFile { get; set; }
        public IFormFile? SliderThreeImageFile { get; set; }
        public IFormFile? SliderFourImageFile { get; set; }

        public string? SliderOneImagePath { get; set; }
        public string? SliderTwoImagePath { get; set; }
        public string? SliderThreeImagePath { get; set; }
        public string? SliderFourImagePath { get; set; }
        public string? FirstSectionLeftTitle { get; set; }
        public string? FirstSectionLeftText { get; set; }
        public IFormFile? FirstSectionLeftImageFile { get; set; } 
        public string? FirstSectionLeftImagePath { get; set; }
        public string? FirstSectionRightTitle { get; set; }
        public string? FirstSectionRightText { get; set; }
        public IFormFile? FirstSectionRightImageFile { get; set; }  
        public string? FirstSectionRightImagePath { get; set; }
        public string? SecondSectionTitle { get; set; }
        public string? SecondSectionText { get; set; }
        public IFormFile? SecondSectionImageFile { get; set; }    

        public string? SecondSectionImagePath { get; set; }
        public string? ThirdSectionTitle { get; set; }
        public string? ThirdSectionText { get; set; }
        public IFormFile? ThirdSectionImageFile { get; set; }  

        public string? ThirdSectionImagePath { get; set; }

        public string? FourthSectionLeftText { get; set; }
        public string? FourthSectionLeftTitle { get; set; }
        public string? FourthSectionRightText { get; set; }
        public string? FourthSectionRightTitle { get; set; }

        public string? RemitNowText { get; set; }
        public IFormFile? RemitNowImageOneFile { get; set; }
        public string? RemitNowImageOneText { get; set; }
        public string? RemitNowImageOne { get; set; }
        public IFormFile? RemitNowImageTwoFile { get; set; }
        public string? RemitNowImageTwoText { get; set; }  
        public string? RemitNowImageTwo { get; set; }

        public string? VideoOneLink { get; set; }
        public string? VideoOneText { get; set; }
        
        public IFormFile? VideoOneThumbnailImageFile { get; set; }  
        public string? VideoTwoLink { get; set; }
        public string? VideoTwoText { get; set; }
        public string? VideoOneThumbnailImagePath { get; set; }
        public string? VideoTwoThumbnailImagePath { get; set; }
        public IFormFile? VideoTwoThumbnailImageFile { get; set; } 
    }
}
