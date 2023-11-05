using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.Models
{
    public class Branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string? BranchesTopBannerImagePath { get; set; }
    }


    public class BranchTopText
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string? Title { get; set; }
        public string? Description { get; set; }

        public DateTime? CreatedAt { get; set; }
    }

    public class BranchDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string? SelectedDropdownValue { get; set; }
        public string? Area { get; set; }
        public string? Adress { get; set; }
        public string? Time { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? Map { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
