using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.DataBaseContext.DataBaseContext;
using AlmuzainiCMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.DAL
{
    public class ChairmanMessageRepository : IChairmanMessageRepository
    {
        private readonly ProjectDbContext _context;

        public ChairmanMessageRepository(ProjectDbContext context)
        {
            _context = context;
        }
        public async Task<ChairmanMessage> GetChairmanMessage()
        {
            ChairmanMessage chairmanMessage = _context.ChairmanMessage.FirstOrDefault();
            return await Task.FromResult(chairmanMessage);
        }

        public async Task<bool> UpdateChairmanInfo(ChairmanMessage chairmanMessage)
        {
            var count = _context.ChairmanMessage?.Count();
            if (count > 0)
            {
                var chairmanMessageToUpdate = _context.ChairmanMessage?.First();

                chairmanMessageToUpdate.ChairmanName = chairmanMessage.ChairmanName;
                chairmanMessageToUpdate.Designation = chairmanMessage.Designation;

                _context.Entry(chairmanMessageToUpdate).Property(i => i.ChairmanName).IsModified = true;
                _context.Entry(chairmanMessageToUpdate).Property(i => i.Designation).IsModified = true;

                if (!String.IsNullOrEmpty(chairmanMessage.ChairmanImagePath))
                {
                    chairmanMessageToUpdate.ChairmanImagePath = chairmanMessage.ChairmanImagePath;

                    _context.Entry(chairmanMessageToUpdate).Property(i => i.ChairmanImagePath).IsModified = true;
                }

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ChairmanMessage?.Add(chairmanMessage);
                return await _context.SaveChangesAsync() > 0;
            }
        }


        public async Task<bool> UpdateChairmanMessage(ChairmanMessage chairmanMessage)
        {
            var count = _context.ChairmanMessage?.Count();
            if (count > 0)
            {
                var chairmanMessageToUpdate = _context.ChairmanMessage?.First();

                chairmanMessageToUpdate.FirstSection = chairmanMessage.FirstSection;
                chairmanMessageToUpdate.SecondSection = chairmanMessage.SecondSection;
                chairmanMessageToUpdate.ThirdSection = chairmanMessage.ThirdSection;
                chairmanMessageToUpdate.FourthSection = chairmanMessage.FourthSection;
                chairmanMessageToUpdate.FifthSection = chairmanMessage.FifthSection;
                chairmanMessageToUpdate.SixthSection = chairmanMessage.SixthSection;
                chairmanMessageToUpdate.SeventhSection = chairmanMessage.SeventhSection;

                _context.Entry(chairmanMessageToUpdate).Property(i => i.FirstSection).IsModified = true;
                _context.Entry(chairmanMessageToUpdate).Property(i => i.SecondSection).IsModified = true;
                _context.Entry(chairmanMessageToUpdate).Property(i => i.ThirdSection).IsModified = true;
                _context.Entry(chairmanMessageToUpdate).Property(i => i.FourthSection).IsModified = true;
                _context.Entry(chairmanMessageToUpdate).Property(i => i.FifthSection).IsModified = true;
                _context.Entry(chairmanMessageToUpdate).Property(i => i.SixthSection).IsModified = true;
                _context.Entry(chairmanMessageToUpdate).Property(i => i.SeventhSection).IsModified = true;

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ChairmanMessage?.Add(chairmanMessage);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateChairmanMessageBanner(ChairmanMessage chairmanMessage)
        {
            var count = _context.ChairmanMessage?.Count();
            if (count > 0)
            {
                var chairmanMessageToUpdate = _context.ChairmanMessage?.First();

                chairmanMessageToUpdate.ChairmanMessageBannerImagePath = chairmanMessage.ChairmanMessageBannerImagePath;

                _context.Entry(chairmanMessageToUpdate).Property(i => i.ChairmanMessageBannerImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ChairmanMessage?.Add(chairmanMessage);
                return await _context.SaveChangesAsync() > 0;
            }
        }
    }
}
