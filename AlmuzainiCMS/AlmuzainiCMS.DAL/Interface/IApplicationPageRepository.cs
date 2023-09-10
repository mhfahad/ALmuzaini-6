﻿
using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.Interface
{
    public interface IApplicationPageRepository
    {
        Task<bool> DeleteUserGuides(UserGuide userGuide);
        Task<ApplicationPage> GetApplicationPage();
        Task<ICollection<UserGuide>> GetUserGuides();
        Task<UserGuide> GetUserGuidesBySerialNo(int serialNo);
        Task<bool> UpdateAboutBoxDescriptionSection(ApplicationPage applicationPage);
        Task<bool> UpdateAppFeaturesSection(ApplicationPage applicationPage);
        Task<bool> UpdateApplicationIcon(ApplicationPage applicationPage);
        Task<bool> UpdateApplicationPageVideoLink(ApplicationPage applicationPage);
        Task<bool> UpdateBannerImagePath(ApplicationPage applicationPage);
        Task<bool> UpdateInnerSection(ApplicationPage applicationPage);
        Task<bool> UpdateUserGuides(UserGuide applicationPage);
    }
}
