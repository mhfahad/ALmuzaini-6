using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.Models
{
    public class ValueAddedBenifits
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string? BannerImagePath { get; set; }
        public string? InnerSectionTitle { get; set; }
        public string? InnerSectionDescription { get; set; }

        
        public string? LeftSectionFirstText  { get; set; }   
        public string? LeftSectionFirstImagePath { get; set; }
        public string? LeftSectionSecondText { get; set; }
        public string? LeftSectionSecondImagePath { get; set; }

        public string? LeftSectionThirdText { get; set; }
        public string? LeftSectionThirdImagePath { get; set; }

        public string? RightSectionFirstText { get; set; }
        public string? RightSectionFirstImagePath { get; set; }
        public string? RightSectionSecondText { get; set; }
        public string? RightSectionSecondImagePath { get; set; }

        public string? RightSectionThirdText { get; set; }
        public string? RightSectionThirdImagePath { get; set; }
        public string? RightSectionFourthText { get; set; }
        public string? RightSectionFourthImagePath { get; set; }  

    }
}
