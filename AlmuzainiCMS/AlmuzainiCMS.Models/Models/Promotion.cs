using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace AlmuzainiCMS.Models.Models
{
    public class Promotion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string? BannerImagePath { get; set; }
        public string? InnerSectionTitle { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<PromotionNews>? PromotionNews { get; set; }   


    }

    public class PromotionNews{   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }    
      
        public string? ImagePath { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }   
        public DateTime? CreatedAt { get; set; }

      
    }
}
