using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class BranchDetailRequestDTO
    {
        public string? Area { get; set; }
        public string? Adress { get; set; }
        public string? Time { get; set; }
        public string? Map { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
