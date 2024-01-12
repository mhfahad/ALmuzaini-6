using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.Interface
{
    public interface IBranchManager
    {
        Task<bool> AddBranchTopText(BranchTopText topText);
        List<BranchTopText> GetBranchTopText();

        Branch GetBranchTopBanner();
        Task<bool> UpdateBranchBannerImagePath(Branch branch);

        Task<bool> AddBranchdetails(BranchDetail details);
        List<BranchDetail> GetBranchDetails();
        Task<BranchDetail> GetBranchById(Guid id);
        Task<bool> DeleteBranchById(Guid id);
        Task<bool> UpdateBranchdetails(BranchDetail brchDetail);

    }
}
