using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class BranchRequestDTO
    {
        public IFormFile? BranchBannerImageFile { get; set; }
        public string? BranchBannerImagePath { get; set; }
    }
}
