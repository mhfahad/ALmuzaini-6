﻿using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.Interface
{
    public interface IHomeManager
    {
        Task<bool> AddHomeVUrlText(HomeVUrl topText);
        List<HomeVUrl> GetHomeVUrl();

        Task<HomeVUrl> GetVideoById(Guid id);
        Task<bool> DeleteVideoById(Guid id);

    }
}
