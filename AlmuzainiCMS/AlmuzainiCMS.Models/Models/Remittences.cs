using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.Models
{
    public class Remittences
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string? BannerImagePath { get; set; }
        public string? InnerSectionTitle { get; set; }
        public string? InnerSectionDescription { get; set; }

        public string? SliderOneImagePath { get; set; }
        public string? SliderTwoImagePath { get; set; }
        public string? SliderThreeImagePath { get; set; }
        public string? SliderFourImagePath { get; set; }
        public string? FirstSectionLeftTitle { get; set; }
        public string? FirstSectionLeftText { get; set; }
        public string? FirstSectionLeftImagePath  { get; set; }
        public string? FirstSectionRightTitle { get; set; } 
        public string? FirstSectionRightText { get; set; } 
        public string? FirstSectionRightImagePath { get; set; }
        public string? SecondSectionTitle { get; set; }
        public string? SecondSectionText { get; set; }
        public string? SecondSectionImagePath { get; set; }
        public string? ThirdSectionTitle { get; set; }
        public string? ThirdSectionText { get; set; }
        public string? ThirdSectionImagePath { get; set; }

        public string? FourthSectionLeftText { get; set; }
        public string? FourthSectionLeftTitle { get; set; }
        public string? FourthSectionRightText { get; set; }
        public string? FourthSectionRightTitle { get; set; }  

        public string? RemitNowText { get; set; }
        public string? RemitNowImageOne { get; set; }
        public string? RemitNowImageTwo { get; set; }
        public string? RemitNowImageOneText { get; set; }
        public string? RemitNowImageTwoText { get; set; }
        public string? VideoOneLink { get; set; } 
        public string? VideoOneText { get; set; }
        public string? VideoTwoLink { get; set; } 
        public string? VideoTwoText { get; set; }
        public string? VideoOneThumbnailImagePath { get; set; }
        public string? VideoTwoThumbnailImagePath { get; set; }


    }
}
