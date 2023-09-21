using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.Models
{
    public class NewsSection
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string? BannerImagePath { get; set; }
        public string? InnerSectionTitle { get; set; }

        public ICollection<NewsSectionNews>? NewsSectionNews { get; set; }   
    }
    public class NewsSectionNews   
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int SerialNo { get; set; }
        public string? ImagePath { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }

        public Guid? NewsSectionId { get; set; }   
        public NewsSection? NewsSection { get; set; }    

    }
}
