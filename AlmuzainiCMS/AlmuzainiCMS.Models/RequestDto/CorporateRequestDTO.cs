using AlmuzainiCMS.Models.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class CorporateRequestDTO
    {
        public IFormFile? BannerImageFile { get; set; }
        public string? BannerImagePath { get; set; }
        public string? InnerSectionTitle { get; set; }
        public string? InnerSectionDescription { get; set; }

        public string? SliderOneImagePath { get; set; }
        public string? SliderTwoImagePath { get; set; }
        public string? SliderThreeImagePath { get; set; }
        public string? SliderFourImagePath { get; set; }
        public IFormFile? SliderOneImageFile { get; set; }
        public IFormFile? SliderTwoImageFile { get; set; }
        public IFormFile? SliderThreeImageFile { get; set; }
        public IFormFile? SliderFourImageFile { get; set; }   

        public string? CorporateClientsText { get; set; }
        public string? ContactsText { get; set; }
        public string? RequiredDocumentsText { get; set; }
        public ICollection<string>? RequiredDocuments { get; set; }
    }
}
