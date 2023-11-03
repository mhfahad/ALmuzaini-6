using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.Interface
{
    public interface IBranchRepository
    {
        Task<bool> AddBranchTopText(BranchTopText topText);
        List<BranchTopText> GetBranchTopText();

        Branch GetBranchTopBanner();
        Task<bool> UpdateBranchBannerImagePath(Branch branch);

        Task<bool> AddBranchdetails(BranchDetail details);
        List<BranchDetail> GetBranchDetails();
    }
}
