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
        Task<ICollection<ValuesItem>> GetMissionVisionValuesItems();
        Task<ValuesItem> GetMissionVisionValuesItemsBySerialNo(int serialNo);

        Task<bool> UpdateVision(MissionVisionValues missionVisionValues);
        Task<bool> UpdateMission(MissionVisionValues missionVisionValues);
        Task<bool> UpdateValues(MissionVisionValues missionVisionValues);   
        Task<bool> UpdateValuesItem(ValuesItem missionVisionValues);
        Task<bool> DeleteValuesItem(ValuesItem valuesItem);






    }
}
