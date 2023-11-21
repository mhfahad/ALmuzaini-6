using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class HomeCompanyDetailRequestDTO
    {
        public string? Title { get; set; }
        public string? SubTitle { get; set; }

        public string? BoxOneTitle { get; set; }
        public string? BoxOneDesc { get; set; }

        public string? BoxTwoTitle { get; set; }
        public string? BoxTwoDesc { get; set; }

        public string? BoxThreeTitle { get; set; }
        public string? BoxThreeDesc { get; set; }

        public string? BoxFourTitle { get; set; }
        public string? BoxFourDesc { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
