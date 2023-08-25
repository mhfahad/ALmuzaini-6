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
    public class ChairmanMessageManager :IChairmanMessageManager
    {
        private readonly IChairmanMessageRepository _repository;
        public ChairmanMessageManager(IChairmanMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> UpdateChairmanInfo(ChairmanMessage chairmanMessage)
        {
            try
            {
                bool result = await _repository.UpdateChairmanInfo(chairmanMessage);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }



        public async Task<bool> UpdateChairmanMessage(ChairmanMessage chairmanMessage)
        {
            try
            {
                bool result = await _repository.UpdateChairmanMessage(chairmanMessage);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<ChairmanMessage> GetChairmanMessage()
        {
            ChairmanMessage chairmanMessage = new ChairmanMessage();

            chairmanMessage = await _repository.GetChairmanMessage();
            return await Task.FromResult(chairmanMessage);
        }

        public async Task<bool> UpdateChairmanMessageBanner(ChairmanMessage chairmanMessage)
        {
            try
            {
                bool result = await _repository.UpdateChairmanMessageBanner(chairmanMessage);
                return await Task.FromResult(result);
            }
            catch (Exception ex)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
