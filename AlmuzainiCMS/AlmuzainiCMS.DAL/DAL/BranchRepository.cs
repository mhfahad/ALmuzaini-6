﻿using AlmuzainiCMS.DAL.Interface;
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

        public Branch GetBranchTopBanner()
        {
            Branch branch = _context.Branches.FirstOrDefault();
            return branch;
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
