﻿using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.Interface
{
    public interface IBranchRepository
    {
        Branch GetBranchTopBanner();
        Task<bool> UpdateBranchBannerImagePath(Branch branch);
    }
}
