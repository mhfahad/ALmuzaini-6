using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class HomeVUrlRequestDTO
    {
        public Guid Id { get; set; }
        public IFormFile? ImageFile { get; set; }

        public string? Title { get; set; }
        public string? VideoUrl { get; set; }
        
        public string? Position { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
