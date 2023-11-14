using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class HomeMidSlideRequestDTO
    {
        public Guid Id { get; set; }

        public string? HeadDesc { get; set; }
        public string? Description { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
