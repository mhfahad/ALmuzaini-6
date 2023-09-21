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
    public class ApplicationPageManager : IApplicationPageManager
    {
        private readonly IApplicationPageRepository _repository;
        public ApplicationPageManager(IApplicationPageRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> DeleteUserGuides(UserGuide userGuide)
        {
            bool result = await _repository.DeleteUserGuides(userGuide);  
            return await Task.FromResult(result);
        }

        public async Task<ApplicationPage> GetApplicationPage()
        {
            ApplicationPage applicationPage = new ApplicationPage();

            applicationPage = await _repository.GetApplicationPage();
            return await Task.FromResult(applicationPage);
        }

        public async Task<ICollection<UserGuide>> GetUserGuides()
        {
            ICollection<UserGuide> userGuide = new List<UserGuide>();

            userGuide = await _repository.GetUserGuides();
            return await Task.FromResult(userGuide);
        }

        public async Task<UserGuide> GetUserGuidesBySerialNo(int serial)
        {
            UserGuide userGuide = await _repository.GetUserGuidesBySerialNo(serial);
            return await Task.FromResult(userGuide);
        }

        public async Task<bool> UpdateAboutBoxDescriptionSection(ApplicationPage applicationPage)
        {
            try
            {
                bool result = await _repository.UpdateAboutBoxDescriptionSection(applicationPage);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateAppFeaturesSection(ApplicationPage applicationPage)
        {
            try
            {
                bool result = await _repository.UpdateAppFeaturesSection(applicationPage);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateApplicationIcon(ApplicationPage applicationPage)
        {
            try
            {
                bool result = await _repository.UpdateApplicationIcon(applicationPage);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateApplicationPageVideoLink(ApplicationPage applicationPage)
        {
            try
            {
                bool result = await _repository.UpdateApplicationPageVideoLink(applicationPage);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateApplicationSlider(ApplicationPage applicationPage)
        {
            try
            {
                bool result = await _repository.UpdateApplicationPageVideoLink(applicationPage);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateBannerImagePath(ApplicationPage applicationPage)
        {
            try
            {
                bool result = await _repository.UpdateBannerImagePath(applicationPage);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateInnerSection(ApplicationPage applicationPage)
        {
            try
            {
                bool result = await _repository.UpdateInnerSection(applicationPage);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateUserGuides(UserGuide userGuide)
        {
            try
            {
                bool result = await _repository.UpdateUserGuides(userGuide);   
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
