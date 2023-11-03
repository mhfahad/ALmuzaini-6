using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.DataBaseContext.DataBaseContext;
using AlmuzainiCMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.BLL
{
    public class BranchManager : IBranchManager
    {
        private readonly IBranchRepository _repository;
        public BranchManager(IBranchRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddBranchdetails(BranchDetail details)
        {
            try
            {
                bool result = await _repository.AddBranchdetails(details);

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {

                return await Task.FromResult(false);

            }
        }

        public async Task<bool> AddBranchTopText(BranchTopText topText)
        {
            try
            {
                bool result = await _repository.AddBranchTopText(topText);

                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {

                return await Task.FromResult(false);

            }
        }

        public List<BranchDetail> GetBranchDetails()
        {
            List<BranchDetail> branchDetail = new List<BranchDetail>();

            branchDetail = _repository.GetBranchDetails();
            return branchDetail;
        }

        public Branch GetBranchTopBanner()
        {
            Branch branch = new Branch();

            branch = _repository.GetBranchTopBanner();
            return branch;
        }

        public List<BranchTopText> GetBranchTopText()
        {
            List<BranchTopText> branchTopText = new List<BranchTopText>();

            branchTopText = _repository.GetBranchTopText();
            return branchTopText;
        }

        public async Task<bool> UpdateBranchBannerImagePath(Branch branch)
        {
            try
            {
                bool result = await _repository.UpdateBranchBannerImagePath(branch);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
