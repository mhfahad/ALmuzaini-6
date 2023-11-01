using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.Interface
{
    public interface IValueAddedBenifitsManager
    {
        Task<ValueAddedBenifits> GetValueAddedBenifits();
        Task<bool> UpdateBannerImagePath(ValueAddedBenifits valueAddedBenifits);
        Task<bool> UpdateInnerSection(ValueAddedBenifits valueAddedBenifits);
        Task<bool> UpdateLeftSectionFirst(ValueAddedBenifits valueAddedBenifits);
        Task<bool> UpdateLeftSectionSecond(ValueAddedBenifits valueAddedBenifits);
        Task<bool> UpdateLeftSectionThird(ValueAddedBenifits valueAddedBenifits);
        Task<bool> UpdateRightSectionFirst(ValueAddedBenifits valueAddedBenifits);
        Task<bool> UpdateRightSectionFourth(ValueAddedBenifits valueAddedBenifits);
        Task<bool> UpdateRightSectionSecond(ValueAddedBenifits valueAddedBenifits);
        Task<bool> UpdateRightSectionThird(ValueAddedBenifits valueAddedBenifits);
    }
}
