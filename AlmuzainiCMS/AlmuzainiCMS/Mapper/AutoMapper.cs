using AlmuzainiCMS.Models.LoginVM;
using AlmuzainiCMS.Models.Models;
using AlmuzainiCMS.Models.RequestDto;
using AutoMapper;

namespace AlmuzainiCMS.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {


            CreateMap<UsersInfo, UsersInfoVM>();
            CreateMap<UsersInfoVM, UsersInfo>();
            CreateMap<CurrencyCodeRequestDto, CurrencyCode>();
            CreateMap<CompanyHistoryRequestDTO, CompanyHistory>();
            CreateMap<ChairmansMessageRequestDTO, ChairmanMessage>();
            CreateMap<MissionVisionValuesRequestDTO, MissionVisionValues>();
            CreateMap<CorporateSocialResponsibilityDTO, CorporateSocialResponsibility>();
            CreateMap<ForeignCurrencyRequestDTO, ForeignCurrency>();
            CreateMap<CorporateRequestDTO, Corporate>();
            CreateMap<RemittancesRequestDTO, Remittences>();
            CreateMap<ValueAddedBinifitsRequestDTO, ValueAddedBenifits>();
            CreateMap<ApplicationPageRequestDTO, ApplicationPage>();
            CreateMap<COntactUsRequestDTO, ContactUs>();
            CreateMap<BranchRequestDTO, Branch>();
            CreateMap<BranchTopTextRequestDTO, BranchTopText>();
            CreateMap<BranchDetailRequestDTO, BranchDetail>();
            CreateMap<HomeVUrlRequestDTO, HomeVUrl>();
            CreateMap<HomeMidSlideRequestDTO, HomeMidSlide>();
            CreateMap<HomeCompanyDetailRequestDTO, HomeCompanyDetail>();
            CreateMap<RateCalculatorNoteRequestDTO, RateCalculatorNote>();
            CreateMap<PromotionRequestDTO, Promotion>();
            CreateMap<PromotionNewsRequestDTO, PromotionNews>();
            CreateMap<NewsSectionRequestDTO, NewsSection>();
            CreateMap<NewsSectionNewsRequestDTO, NewsSectionNews>();
        }  
    }
}
