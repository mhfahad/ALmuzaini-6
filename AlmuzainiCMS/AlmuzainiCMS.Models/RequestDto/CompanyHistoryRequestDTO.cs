
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class CompanyHistoryRequestDTO
    {
        //public Guid? Id { get; set; }

        public string? FirstSection { get; set; }
        public string? SecondSection { get; set; }
        public string? ThirdSection { get; set; }
        public string? FourthSection { get; set; }

        public string? ExpertiseImagePath { get; set; }
        public string? ExpertiseText { get; set; }
        public IFormFile? ExpertiseImageFile { get; set; }
        public string? WorkforceImagePath { get; set; }
        public string? WorkforceText { get; set; }
        public IFormFile? WorkforceImageFile { get; set; }  
        public string? TechnologyImagePath { get; set; }
        public string? TechnologyText { get; set; }
        public IFormFile? TechnologyImageFile { get; set; }   
        public string? CompanyHistoryImagePath { get; set; }
    }
}
