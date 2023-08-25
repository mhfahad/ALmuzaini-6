using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.Interface
{
    public interface IChairmanMessageRepository
    {
        Task<bool> UpdateChairmanMessageBanner(ChairmanMessage chairmanMessage);
        Task<bool> UpdateChairmanInfo(ChairmanMessage chairmanMessage);
        Task<bool> UpdateChairmanMessage(ChairmanMessage chairmanMessage);
        Task<ChairmanMessage> GetChairmanMessage();

    }
}
