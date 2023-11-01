
using AlmuzainiCMS.Models.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class NewsSectionRequestDTO   
    {
        public IFormFile? BannerImageFile { get; set; }
        public string? BannerImagePath { get; set; }
        public string? InnerSectionTitle { get; set; }

        public ICollection<PromotionNews>? PromotionNews { get; set; }
    }
}
