using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.BLL.BLL
{
    public class CorporateSocialResponsibilityManager : ICorporateSocialResponsibilityManager
    {
        private readonly ICorporateSocialResponsibilityRepository _repository;
        public CorporateSocialResponsibilityManager(ICorporateSocialResponsibilityRepository repository)
        {
            _repository = repository;
        }
        public async Task<CorporateSocialResponsibility> GetCorporateSocialResponsibility()
        {
            try
            {
                CorporateSocialResponsibility result = await _repository.GetCorporateSocialResponsibility();
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new CorporateSocialResponsibility());
            }
        }

        public async Task<bool> UpdateCorporateSocialResponsibilityImage(CorporateSocialResponsibility corporateSocialResponsibility)
        {
            try
            {
                bool result = await _repository.UpdateCorporateSocialResponsibilityImage(corporateSocialResponsibility);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateCorporateSocialResponsibilitySection(CorporateSocialResponsibility corporateSocialResponsibility)
        {
            try
            {
                bool result = await _repository.UpdateCorporateSocialResponsibilitySection(corporateSocialResponsibility);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
