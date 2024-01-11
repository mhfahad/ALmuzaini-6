using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public class KoiskDetailRequestDTO
    {
        public Guid Id { get; set; }

        public string? PageTitle { get; set; }

        public string? SectionHeaderText { get; set; }
        public string? FirstSectionText { get; set; }
        public string? SecondSectionText { get; set; }
        public string? ThirdSectionText { get; set; }
        public string? FourthSectionText { get; set; }
        public string? FifthSectionText { get; set; }
        public string? SixthSectionText { get; set; }

        public string? DownloadText { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
