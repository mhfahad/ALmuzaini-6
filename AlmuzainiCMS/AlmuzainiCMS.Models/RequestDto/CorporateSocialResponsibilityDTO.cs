
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class CorporateSocialResponsibilityDTO
    {
        public IFormFile? CorporateSocialResponsibilyImageFile { get; set; }
        public string? CorporateSocialResponsibilityImagePath  { get; set; }

        public string? FirstSection { get; set; }
        public string? SecondSection { get; set; }
        public string? ThirdSection { get; set; }
        public string? FourthSection { get; set; }
        public string? FifthSection { get; set; }
        public string? SixthSection { get; set; }
        public string? SeventhSection { get; set; }




    }
}
