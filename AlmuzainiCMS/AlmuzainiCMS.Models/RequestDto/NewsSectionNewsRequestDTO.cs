
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class NewsSectionNewsRequestDTO   
    {
        public IFormFile? ImageFile { get; set; }
        public string? ImagePath { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
