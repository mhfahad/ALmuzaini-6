using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.Models
{
    public class ContactUs
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string? BannerImagePath { get; set; }
        public string? InnerSectionTitle { get; set; }
        public string? LeftSectionTitle { get; set; }
        public string? RightSectionTitle { get; set; }

        public string? LeftSubOneSectionTitle { get; set; }
        public string? LeftSubOneSectionIconPath { get; set; }
        public string? LeftSubOneSectionText { get; set; }
        public string? LeftSubTwoSectionTitle { get; set; }
        public string? LeftSubTwoSectionIconPath { get; set; }
        public string? LeftSubTwoSectionText { get; set; }
        public string? LeftSubThreeSectionTitle { get; set; }
        public string? LeftSubThreeSectionIconPath { get; set; }
        public string? LeftSubThreeSectionText { get; set; }
        public string? LeftSubFourSectionTitle { get; set; }
        public string? LeftSubFourSectionIconPath { get; set; }
        public string? LeftSubFourSectionText { get; set; }
        public string? LeftSubFiveSectionTitle { get; set; }
        public string? LeftSubFiveSectionIconPath { get; set; }
        public string? LeftSubFiveSectionText { get; set; }
        public string? RightSubOneSectionTitle { get; set; }
        public string? RightSubOneSectionIconPath { get; set; }
        public string? RightSubOneSectionText { get; set; }
        public string? RightSubTwoSectionTitle { get; set; }
        public string? RightSubTwoSectionIconPath { get; set; }
        public string? RightSubTwoSectionText { get; set; }
        public string? RightSubThreeSectionTitle { get; set; }
        public string? RightSubThreeSectionIconPath { get; set; }
        public string? RightSubThreeSectionText { get; set; }
        public string? RightSubFourSectionTitle { get; set; }
        public string? RightSubFourSectionIconPath { get; set; }
        public string? RightSubFourSectionText { get; set; }

        public string? NewsSectionOneTitle { get; set; }
        public string? NewsSectionOneImageath { get; set; }
        public string? NewsSectionOneText { get; set; }
        public string? NewsSectionTwoTitle { get; set; }
        public string? NewsSectionTwoImageath { get; set; }
        public string? NewsSectionTwoText { get; set; }
        public string? NewsSectionThreeTitle { get; set; }
        public string? NewsSectionThreeImageath { get; set; }
        public string? NewsSectionThreeText { get; set; }
        public string? NewsSectionFourTitle { get; set; }
        public string? NewsSectionFourImageath { get; set; }
        public string? NewsSectionFourText { get; set; }
        public string? NewsSectionFiveTitle { get; set; }
        public string? NewsSectionFiveImageath { get; set; }
        public string? NewsSectionFiveText { get; set; }   

    }
}
