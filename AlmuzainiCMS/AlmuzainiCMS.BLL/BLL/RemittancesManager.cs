using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.DAL.DAL;
using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.BLL
{
    public class RemittancesManager : IRemittancesManager
    {
        private readonly IRemittancesRepository _remittancesRepository;
        public RemittancesManager(IRemittancesRepository remittancesRepository)
        {
            _remittancesRepository = remittancesRepository;
        }
        public async Task<Remittences> GetRemittances()
        {
            Remittences remittences = new Remittences();

            remittences = await _remittancesRepository.GetRemittances();
            return await Task.FromResult(remittences);
        }

        public async Task<bool> UpdateBannerImagePath(Remittences remittances)
        {
            try
            {
                bool result = await _remittancesRepository.UpdateBannerImagePath(remittances);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateFirstSectionLeft(Remittences remittances)
        {
            try
            {
                bool result = await _remittancesRepository.UpdateFirstSectionLeft(remittances);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateFirstSectionRight(Remittences remittancesmodel)
        {
            try
            {
                bool result = await _remittancesRepository.UpdateFirstSectionRight(remittancesmodel);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateFourthSection(Remittences remittancesmodel)
        {
            try
            {
                bool result = await _remittancesRepository.UpdateFourthSection(remittancesmodel);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateInnerSection(Remittences remittances)
        {
            try
            {
                bool result = await _remittancesRepository.UpdateInnerSection(remittances);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateRemitNow(Remittences remittancesmodel)
        {
            try
            {
                bool result = await _remittancesRepository.UpdateRemitNow(remittancesmodel);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateSecondSection(Remittences remittancesmodel)
        {
            try
            {
                bool result = await _remittancesRepository.UpdateSecondSection(remittancesmodel);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateSliderImageFile(Remittences remittances)
        {
            try
            {
                bool result = await _remittancesRepository.UpdateSliderImageFile(remittances);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateThirdSection(Remittences remittancesmodel)
        {
            try
            {
                bool result = await _remittancesRepository.UpdateThirdSection(remittancesmodel);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateVideoLink(Remittences remittances)
        {
            try
            {
                bool result = await _remittancesRepository.UpdateVideoLink(remittances);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
