using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.Models
{
    public class Promotion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string? BannerImagePath { get; set; }
        public string? InnerSectionTitle { get; set; }

        public ICollection<PromotionNews>? PromotionNews { get; set; }   


    }

    public class PromotionNews{   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }    
        public int SerialNo { get; set; }
        public string? ImagePath { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }   
        public DateTime? CreatedAt { get; set; }

        public Guid? PromotionId { get; set; }
        public Promotion? Promotion { get; set; }    

    }
}
