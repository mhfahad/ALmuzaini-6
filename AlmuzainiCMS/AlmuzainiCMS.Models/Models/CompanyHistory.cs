using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.Models
{
    public class CompanyHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public string? FirstSection { get; set; }
        public string? SecondSection { get; set; }  
        public string? ThirdSection { get; set; }   
        public string? FourthSection { get; set; }  

        public string? ExpertiseImagePath { get; set; }
        public string? ExpertiseText { get; set; }
        public string? WorkforceImagePath { get; set; }
        public string? WorkforceText { get; set; }
        public string? TechnologyImagePath { get; set; }
        public string? TechnologyText { get; set; }
        public string? CompanyHistoryImagePath { get; set; }

        public string? CompanyProfileBannerImagePath { get; set; }   
    }
}
