using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.Models
{

    public class HomeMidSlide
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string? HeadDesc { get; set; }
        public string? Description { get; set; }

        public DateTime? CreatedAt { get; set; }
    }

    public class RateCalculatorNote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string? RateNote { get; set; }

        public DateTime? CreatedAt { get; set; }
    }

    public class HomeCompanyDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

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
