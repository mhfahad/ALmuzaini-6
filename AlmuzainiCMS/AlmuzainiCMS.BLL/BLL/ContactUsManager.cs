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
    public class ContactUsManager : IContactUsManager
    {
        private readonly IContactUsRepository _repository;
        public ContactUsManager(IContactUsRepository repository)
        {
            _repository = repository;
        }
        public async Task<ContactUs> GetContactUs()
        {
            ContactUs contactUs= new ContactUs();

            contactUs = await _repository.GetContactUs();
            return await Task.FromResult(contactUs);  
        }

        public async Task<bool> UpdateBannerImagePath(ContactUs contactUS)
        {
            try
            {
                bool result = await _repository.UpdateBannerImagePath(contactUS);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateInnerSection(ContactUs contactUs)
        {
            try
            {
                bool result = await _repository.UpdateInnerSection(contactUs);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateLeftSection(ContactUs contactUS)
        {
            try
            {
                bool result = await _repository.UpdateLeftSection(contactUS);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateNewsSection(ContactUs contactUS)
        {

            try
            {
                bool result = await _repository.UpdateNewsSection(contactUS);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateRightSection(ContactUs contactUS)
        {
            try
            {
                bool result = await _repository.UpdateRightSection(contactUS);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
