using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.Interface
{
    public interface IMissionVisionValuesManager
    {
        Task<bool> MissionVisionValuesExists();
        Task<bool> UpdateMissionVisionValuesBanner(MissionVisionValues missionVisionValues);
        Task<MissionVisionValues> GetMissionVisionValues();  
    }
}
