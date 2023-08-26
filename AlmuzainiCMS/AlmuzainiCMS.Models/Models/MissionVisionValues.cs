using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.Models
{
    public class MissionVisionValues
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        [Key]
        public Guid Id { get; set; }
        public string? MissionVisionBannerImagePath { get; set; }
        public string? VisionImagePath { get; set; }
        public string? VisionText { get; set; }
        public string? MissionImagePath { get; set; }
        public string? MissionText { get; set; }
        public string? ValuesImagePath { get; set; }
        public string? ValuesText { get; set; }

        public ICollection<ValuesItem>? ValuesItems { get; set; }


        //public string? ValuesItem1 { get; set; }
        //public string? ValuesItem2 { get; set; }
        //public string? ValuesItem3 { get; set; }
        //public string? ValuesItem4 { get; set; }
        //public string? ValuesItem5 { get; set; }
        //public string? ValuesItem6 { get; set; }
        //public string? ValuesItem7 { get; set; }
        //public string? ValuesItem8 { get; set; }
        //public string? ValuesItem9 { get; set; }
        //public string? ValuesItem10 { get; set; }
        
    }

    public class ValuesItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int SerialNo { get; set; }
        public string? ValuesItemText { get; set; }

        public Guid MissionVisionValuesId { get; set; }  
        public MissionVisionValues? MissionVisionValues  { get; set; }


    }
}
