using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.BLL
{
    public class MissionVisionValuesManager : IMissionVisionValuesManager
    {
        private readonly IMissionVisionValuesRepository _repository;
        public MissionVisionValuesManager(IMissionVisionValuesRepository repository)
        {
            _repository = repository;
        }

        public async Task<MissionVisionValues> GetMissionVisionValues()
        {
            MissionVisionValues missionVisionValues = new MissionVisionValues();

            missionVisionValues = await _repository.GetMissionVisionValues();
            return await Task.FromResult(missionVisionValues);
        }

        public Task<bool> MissionVisionValuesExists()
        {
            bool result = _repository.MissionVisionValuesExists();
            return Task.FromResult(result);
        }

        

        public async Task<bool> UpdateMissionVisionValuesBanner(MissionVisionValues missionVisionValues)
        {
            try
            {
                bool result = await _repository.UpdateMissionVisionValuesBanner(missionVisionValues);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateVision(MissionVisionValues missionVisionValues)
        {
            try
            {
                bool result = await _repository.UpdateVision(missionVisionValues);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateMission(MissionVisionValues missionVisionValues)
        {
            try
            {
                bool result = await _repository.UpdateMission(missionVisionValues);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> UpdateValues(MissionVisionValues missionVisionValues)
        {
            try
            {
                bool result = await _repository.UpdateValues(missionVisionValues);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
