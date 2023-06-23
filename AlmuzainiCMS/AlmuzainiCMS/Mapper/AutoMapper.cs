using AlmuzainiCMS.Models.LoginVM;
using AlmuzainiCMS.Models.Models;
using AutoMapper;

namespace AlmuzainiCMS.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {


            CreateMap<UsersInfo, UsersInfoVM>();
            CreateMap<UsersInfoVM, UsersInfo>();

        }
    }
}
