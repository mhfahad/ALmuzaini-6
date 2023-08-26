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
        }
    }
}
