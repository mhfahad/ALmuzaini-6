using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.Models
{
    public class Corporate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string? BannerImagePath { get; set; }  
        public string? InnerSectionTitle { get; set; }
        public string? InnerSectionDescription  { get; set; }
       
        public string? SliderOneImagePath { get; set; }
        public string? SliderTwoImagePath { get; set; }
        public string? SliderThreeImagePath { get; set; }
        public string? SliderFourImagePath { get; set; }
        public string? CorporateClientsText  { get; set; }
        public string? ContactsText { get; set; }   

        public string? RequiredDocumentsText { get; set; }
        public ICollection<RequiredDocument>? RequiredDocuments { get; set; }   
    }

    public class RequiredDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int SerialNo { get; set; }
        public string? RequiredDocumentText { get; set; }  
          
        public Guid CorporateId { get; set; }   
        public Corporate? Corporate { get; set; }        


    }
}
