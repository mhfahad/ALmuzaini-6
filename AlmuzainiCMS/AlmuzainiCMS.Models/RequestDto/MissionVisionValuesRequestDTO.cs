using AlmuzainiCMS.Models.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class MissionVisionValuesRequestDTO
    {
        public IFormFile? MissionVisionBannerImageFile { get; set; }
        public string? MissionVisionBannerImagePath  { get; set; }

        public IFormFile? VisionImageFile { get; set; }
        public string? VisionImagePath { get; set; }
        public string? VisionText  { get; set; }

        public IFormFile? MissionImageFile { get; set; }
        public string? MissionImagePath { get; set; }
        public string? MissionText { get; set; }

        public IFormFile? ValuesImageFile { get; set; }
        public string? ValuesImagePath { get; set; }
        public string? ValuesText { get; set; }

        public List<string>? ValuesItemList { get; set; }





    }


    public class ValuesItemDTO   
    {
        public Guid Id { get; set; }

        public string? ValuesItemText { get; set; }

        public Guid MissionVisionValuesId { get; set; }
        public MissionVisionValues? MissionVisionValues { get; set; }


    }

}
