using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.Models.RequestDto
{
    public  class ForeignCurrencyRequestDTO
    {
        public IFormFile? CashCurrencyBannerImageFile { get; set; }
        public string? CashCurrencyBannerImagePath  { get; set; }
        public string? InnerSectionPageHeader { get; set; }
        public string? InnerSectionPageDescription { get;set; }
        public string? FCDeliveryText  { get; set; }
        public IFormFile? FCDeliveryImageFile { get; set; }
        public string? FCDeliveryImagePath { get; set; }

        public string? FCExchangeTextFirstSection   { get; set; }
        public string? FCExchangeTextSecondSection  { get; set; }
        public string? FCExchangeTextThirdSection   { get; set; }

        public string? BuySellCurrencyText  { get; set; }

        public string? BuySellCurrencyLinkOne { get; set; }

        public string? BuySellCurrencyLinkTwoText  { get; set; }
        public IFormFile? QRCodeImageFile  { get; set; }

        public string? QRCodeImagePath { get; set; }

        public string? BuySellCurrencyORText { get; set; }
        public string? ORDescriptionText { get; set; }
        public IFormFile? BranchImageFile { get; set; }

        public string? BranchImagePath { get; set; }
        public IFormFile? SlideImageFileOne { get; set; }

        public string? SlideImageFileOnePath { get; set; }
        public IFormFile? SlideImageFileTwo { get; set; }

        public string? SlideImageFileTwoPath { get; set; }
        public IFormFile? SlideImageFileThree { get; set; }

        public string? SlideImageFileThreePath { get; set; }
        public IFormFile? SlideImageFileFour { get; set; }

        public string? SlideImageFileFourPath { get; set; }    
    }
}
