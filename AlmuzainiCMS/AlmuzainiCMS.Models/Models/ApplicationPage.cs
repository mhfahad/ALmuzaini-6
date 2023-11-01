using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.Models
{
    public class ApplicationPage   
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string? BannerImagePath { get; set; }
        public string? InnerSectionTitle { get; set; }
        public string? ABoutBoxDescription { get; set; }
        public string? UserGuideTitle { get; set; }

        public string? ApplePlayStoreIconImagePath  { get; set; }
        public string? GooglePlayStoreIconImagePath  { get; set; }
        public string? AppGalleryIconImagePath  { get; set; }
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
        public string? AppFeaturesSectionTitle { get; set; }  
        public string? AppFeaturesSectionOneTitle { get; set; }  
        public string? AppFeaturesSectionOneImagePath { get; set; }  
        public string? AppFeaturesSectionOneDescriptionSectionOne { get; set; }  
        public string? AppFeaturesSectionOneDescriptionSectionTwo { get; set; }

        public string? AppFeaturesSectionTwoTitle { get; set; }
        public string? AppFeaturesSectionTwoImagePath { get; set; }
        public string? AppFeaturesSectionTwoDescriptionSectionOne { get; set; }
        public string? AppFeaturesSectionTwoDescriptionSectionTwo { get; set; }
        public string? AppFeaturesSectionThreeTitle { get; set; }
        public string? AppFeaturesSectionThreeImagePath { get; set; }
        public string? AppFeaturesSectionThreeDescriptionSectionOne { get; set; }
        public string? AppFeaturesSectionThreeDescriptionSectionTwo { get; set; }
        public string? AppFeaturesSectionFourthTitle { get; set; }
        public string? AppFeaturesSectionFourthImagePath { get; set; }
        public string? AppFeaturesSectionFourthDescriptionSectionOne { get; set; }
        public string? AppFeaturesSectionFourthDescriptionSectionTwo { get; set; }
        public string? AppTutorialsSectionTitle { get; set; }
        public string? VideoOneLink { get; set; }
        public string? VideoOneTitle { get; set; }
        public string? VideoOneThumbnailImagePath { get; set; }
        public string? VideoTwoThumbnailImagePath { get; set; }
        public string? VideoThreeThumbnailImagePath { get; set; }
        public string? VideoFourThumbnailImagePath { get; set; }
        public string? VideoFiveThumbnailImagePath { get; set; }  
        public string? VideoTwoLink { get; set; }
        public string? VideoTwoTitle { get; set; }
        public string? VideoThreeLink { get; set; }
        public string? VideoThreeTitle { get; set; }
        public string? VideoFourLink { get; set; }
        public string? VideoFourTitle { get; set; }
        public string? VideoFiveLink { get; set; }
        public string? VideoFiveTitle { get; set; }
           
        
        public ICollection<UserGuide>? UserGuides { get; set; }   
    }
    public class UserGuide 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int SerialNo { get; set; }
        public string? UserGuideText { get; set; }   

        public Guid ApplicationPageId { get; set; }     
        public ApplicationPage? Application { get; set; }  


    }
}
