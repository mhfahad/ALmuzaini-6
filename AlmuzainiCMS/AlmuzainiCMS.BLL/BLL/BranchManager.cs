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

        public Branch GetBranchTopBanner()
        {
            Branch branch = new Branch();

            branch = _repository.GetBranchTopBanner();
            return branch;
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
