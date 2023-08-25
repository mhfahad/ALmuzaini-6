using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class ChairmansMessageRequestDTO
    {
        public string? ChairmanName { get; set; }
        public string? Designation  { get; set; }
        public string? ChairmanImagePath { get; set; }
        public IFormFile? ChairmanImageFile { get; set; }
        public string? FirstSection { get; set; }
        public string? SecondSection { get; set; }
        public string? ThirdSection { get; set; }
        public string? FourthSection { get; set; }
        public string? FifthSection { get; set; }
        public string? SixthSection { get; set; }
        public string? SeventhSection { get; set; }   



    }
}
