
using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.Interface
{
    public interface IContactUsRepository
    {
        Task<ContactUs> GetContactUs();
        Task<bool> UpdateBannerImagePath(ContactUs contactUS);
        Task<bool> UpdateInnerSection(ContactUs contactUs);
        Task<bool> UpdateLeftSection(ContactUs contactUS);
        Task<bool> UpdateNewsSection(ContactUs contactUS);
        Task<bool> UpdateRightSection(ContactUs contactUS);
    }
}
