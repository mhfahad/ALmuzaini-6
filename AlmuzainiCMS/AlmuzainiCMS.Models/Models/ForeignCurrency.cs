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
    public class ForeignCurrency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? CashCurrencyBannerImagePath { get; set; }
        public string? InnerSectionPageHeader { get; set; }
        public string? InnerSectionPageDescription { get; set; }
        public string? FCDeliveryText { get; set; }
        
        public string? FCDeliveryImagePath { get; set; }

        public string? FCExchangeTextFirstSection { get; set; }
        public string? FCExchangeTextSecondSection { get; set; }
        public string? FCExchangeTextThirdSection { get; set; }

        public string? BuySellCurrencyText { get; set; }

        public string? BuySellCurrencyLinkOne { get; set; }
        public string? BuySellCurrencyLinkTwo { get; set; }  

        public string? BuySellCurrencyLinkOneText { get; set; }  
        public string? BuySellCurrencyLinkTwoText { get; set; }
        

        public string? QRCodeImagePath { get; set; }

        public string? BuySellCurrencyORText { get; set; }
        public string? ORDescriptionText { get; set; }
        

        public string? BranchImagePath { get; set; }
        

        public string? SlideImageFileOnePath { get; set; }
        
        public string? SlideImageFileTwoPath { get; set; }
        
        public string? SlideImageFileThreePath { get; set; }
        
        public string? SlideImageFileFourPath { get; set; }
    }
}
