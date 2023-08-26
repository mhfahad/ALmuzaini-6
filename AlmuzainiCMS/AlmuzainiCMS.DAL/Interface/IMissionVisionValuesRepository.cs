using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.Interface
{
    public interface IMissionVisionValuesRepository
    {
        Task<bool> UpdateMissionVisionValuesBanner(MissionVisionValues missionVisionValues);
        bool MissionVisionValuesExists();
        Task<MissionVisionValues> GetMissionVisionValues();
        Task<bool> UpdateVision(MissionVisionValues missionVisionValues);
        Task<bool> UpdateMission(MissionVisionValues missionVisionValues);
        Task<bool> UpdateValues(MissionVisionValues missionVisionValues);
    }
}
