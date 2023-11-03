using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.DataBaseContext.DataBaseContext;
using AlmuzainiCMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.DAL
{
    public class BranchRepository : IBranchRepository
    {
        private readonly ProjectDbContext _context;
        public BranchRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBranchdetails(BranchDetail details)
        {
            _context.BranchDetails.Add(details);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddBranchTopText(BranchTopText topText)
        {
            _context.BranchTopTexts.Add(topText);
            return await _context.SaveChangesAsync() > 0;
        }

        public List<BranchDetail> GetBranchDetails()
        {
            List<BranchDetail> detailList = _context.BranchDetails.ToList() ?? new List<BranchDetail>();

            return detailList;
        }

        public Branch GetBranchTopBanner()
        {
            Branch branch = _context.Branches.FirstOrDefault();
            return branch;
        }

        public List<BranchTopText> GetBranchTopText()
        {
            List<BranchTopText> topTextList = _context.BranchTopTexts.ToList() ?? new List<BranchTopText>();

            return topTextList;
        }

        public async Task<bool> UpdateBranchBannerImagePath(Branch branch)
        {
            var count = _context.Branches.Count();
            if (count > 0)
            {
                var branchToUpdate = _context.Branches?.First();

                branchToUpdate.BranchesTopBannerImagePath = branch.BranchesTopBannerImagePath;

                _context.Entry(branchToUpdate).Property(i => i.BranchesTopBannerImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.Branches?.Add(branch);
                return await _context.SaveChangesAsync() > 0;
            }
        }
    }
}
