
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.Models
{
    public class CorporateSocialResponsibility
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }    
        public string? CorporateSocialResponsibilityImagePath { get; set; }

        public string? FirstSection { get; set; }
        public string? SecondSection { get; set; }
        public string? ThirdSection { get; set; }
        public string? FourthSection { get; set; }
        public string? FifthSection { get; set; }
        public string? SixthSection { get; set; }
        public string? SeventhSection { get; set; }

    }

    public class CorporateSocialRespBanner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string? CorporateSocialRespBannerImagePath { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
