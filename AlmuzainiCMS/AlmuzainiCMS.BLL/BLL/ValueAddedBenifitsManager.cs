
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
    public class ValueAddedBenifitsManager : IValueAddedBenifitsManager
    {
        private readonly IValueAddedBenifitsRepository _repository;
        public ValueAddedBenifitsManager(IValueAddedBenifitsRepository repository)  
        {
            _repository = repository;
        }
        public async Task<ValueAddedBenifits> GetValueAddedBenifits()
        {
            ValueAddedBenifits valueAddedBenifits = new ValueAddedBenifits();

            valueAddedBenifits = await _repository.GetValueAddedBenifits();
            return await Task.FromResult(valueAddedBenifits);   
        }

        public async Task<bool> UpdateBannerImagePath(ValueAddedBenifits valueAddedBenifits)
        {
            try
            {
                bool result = await _repository.UpdateBannerImagePath(valueAddedBenifits);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateInnerSection(ValueAddedBenifits valueAddedBenifits)
        {
            try
            {
                bool result = await _repository.UpdateInnerSection(valueAddedBenifits);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateLeftSectionFirst(ValueAddedBenifits valueAddedBenifits)
        {
            try
            {
                bool result = await _repository.UpdateLeftSectionFirst(valueAddedBenifits);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateLeftSectionSecond(ValueAddedBenifits valueAddedBenifits)
        {
            try
            {
                bool result = await _repository.UpdateLeftSectionSecond(valueAddedBenifits);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateLeftSectionThird(ValueAddedBenifits valueAddedBenifits)
        {
            try
            {
                bool result = await _repository.UpdateLeftSectionThird(valueAddedBenifits);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateRightSectionFirst(ValueAddedBenifits valueAddedBenifits)
        {
            try
            {
                bool result = await _repository.UpdateRightSectionFirst(valueAddedBenifits);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateRightSectionFourth(ValueAddedBenifits valueAddedBenifits)
        {
            try
            {
                bool result = await _repository.UpdateRightSectionFourth(valueAddedBenifits);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateRightSectionSecond(ValueAddedBenifits valueAddedBenifits)
        {
            try
            {
                bool result = await _repository.UpdateRightSectionSecond(valueAddedBenifits);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> UpdateRightSectionThird(ValueAddedBenifits valueAddedBenifits)
        {
            try
            {
                bool result = await _repository.UpdateRightSectionThird(valueAddedBenifits);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
