
using AlmuzainiCMS.Models.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class ApplicationPageRequestDTO
    {
        public IFormFile? BannerImageFile { get; set; }
        public string? BannerImagePath { get; set; }
        public string? InnerSectionTitle { get; set; }
        public string? ABoutBoxDescription { get; set; }
        public string? UserGuideTitle { get; set; }
        public IFormFile? ApplePlayStoreIconImageFile { get; set; }
        public IFormFile? GooglePlayStoreImageFile { get; set; }
        public IFormFile? AppGalleryImageFile { get; set; }  

        public string? ApplePlayStoreIconImagePath { get; set; }
        public string? GooglePlayStoreIconImagePath { get; set; }
        public string? AppGalleryIconImagePath { get; set; }
        public IFormFile? SliderOneImageFile { get; set; }
        public IFormFile? SliderTwoImageFile { get; set; }
        public IFormFile? SliderThreeImageFile { get; set; }
        public IFormFile? SliderFourImageFile { get; set; }  
        public string? SliderOneImagePath { get; set; }
        public string? SliderTwoImagePath { get; set; }
        public string? SliderThreeImagePath { get; set; }
        public string? SliderFourImagePath { get; set; }

        public string? ApplicationIconOneImagePath { get; set; }
        public string? ApplicationIconOneTitle { get; set; }
        public string? ApplicationIconTwoTitle { get; set; }
        public string? ApplicationIconTwoImagePath { get; set; }
        public string? ApplicationIconThreeTitle { get; set; }
        public string? ApplicationIconThreeImagePath { get; set; }
        public string? ApplicationIconFourTitle { get; set; }

        public string? ApplicationIconFourImagePath { get; set; }
        public string? ApplicationIconFiveTitle { get; set; }

        public string? ApplicationIconFiveImagePath { get; set; }
        public string? ApplicationIconSixTitle { get; set; }

        public string? ApplicationIconSixImagePath { get; set; }

        public IFormFile? ApplicationIconOneFile { get; set; }
        public IFormFile? ApplicationIconTwoImageFile { get; set; }
        public IFormFile? ApplicationIconThreeImageFile { get; set; }
        public IFormFile? ApplicationIconFourImageFile { get; set; }  
        public IFormFile? ApplicationIconFiveImageFile { get; set; }
        public IFormFile? ApplicationIconSixFile { get; set; }


        public string? AppFeaturesSectionTitle { get; set; }
        public string? AppFeaturesSectionOneTitle { get; set; }
        public string? AppFeaturesSectionOneImagePath { get; set; }

        public IFormFile? AppFeaturesSectionOneImageFile { get; set; }  

        public string? AppFeaturesSectionOneDescriptionSectionOne { get; set; }
        public string? AppFeaturesSectionOneDescriptionSectionTwo { get; set; }

        public string? AppFeaturesSectionTwoTitle { get; set; }
        public string? AppFeaturesSectionTwoImagePath { get; set; }
        public IFormFile? AppFeaturesSectionTwoImageFile { get; set; }  
        public string? AppFeaturesSectionTwoDescriptionSectionOne { get; set; }
        public string? AppFeaturesSectionTwoDescriptionSectionTwo { get; set; }
        public string? AppFeaturesSectionThreeTitle { get; set; }
        public string? AppFeaturesSectionThreeImagePath { get; set; }
        public IFormFile? AppFeaturesSectionThreeImageFile { get; set; }  

        public string? AppFeaturesSectionThreeDescriptionSectionOne { get; set; }
        public string? AppFeaturesSectionThreeDescriptionSectionTwo { get; set; }
        public string? AppFeaturesSectionFourthTitle { get; set; }
        public string? AppFeaturesSectionFourthImagePath { get; set; }
        public IFormFile? AppFeaturesSectionFourthImageFile { get; set; } 

        public string? AppFeaturesSectionFourthDescriptionSectionOne { get; set; }
        public string? AppFeaturesSectionFourthDescriptionSectionTwo { get; set; }
        public string? AppTutorialsSectionTitle { get; set; }
        public string? VideoOneLink { get; set; }
        public string? VideoOneTitle { get; set; }
        public IFormFile? VideoOneThumbnailImageFile { get; set; }
        public string? VideoOneThumbnailImagePath  { get; set; }
        public string? VideoTwoLink { get; set; }
        public string? VideoTwoTitle { get; set; }
        public IFormFile? VideoTwoThumbnailImageFile { get; set; }
        public string? VideoTwoThumbnailImagePath { get; set; }
        public string? VideoThreeLink { get; set; }
        public string? VideoThreeTitle { get; set; }
        public IFormFile? VideoThreeThumbnailImageFile { get; set; }
        public string? VideoThreeThumbnailImagePath { get; set; }  
        public string? VideoFourLink { get; set; }
        public string? VideoFourTitle { get; set; }
        public IFormFile? VideoFourThumbnailImageFile { get; set; }
        public string? VideoFourThumbnailImagePath { get; set; }
        public string? VideoFiveLink { get; set; }
        public string? VideoFiveTitle { get; set; }
        public IFormFile? VideoFiveThumbnailImageFile { get; set; }
        public string? VideoFiveThumbnailImagePath { get; set; }  
        public ICollection<string>? UserGuides { get; set; }
    }
}
