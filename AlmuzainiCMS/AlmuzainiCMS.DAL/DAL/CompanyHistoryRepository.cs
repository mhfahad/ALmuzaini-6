using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.DataBaseContext.DataBaseContext;
using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.DAL
{
    public class CompanyHistoryRepository : ICompanyHistoryRepository
    {
        private readonly ProjectDbContext _context;

        public CompanyHistoryRepository(ProjectDbContext context)   
        {
            _context = context;
        }

        public Task<CompanyHistory> GetCompanyHistorySection()
        {
            CompanyHistory companyHistory = _context.CompanyHistory.First();    
            return Task.FromResult(companyHistory);
        }

        //
        public async Task<ChairmanMessage> GetChairmanMessage()
        {
            ChairmanMessage chairmanMessage = _context.ChairmanMessage.First();
            return await Task.FromResult(chairmanMessage);
        }

        public async Task<bool> UpdateCompanyHistorySection(CompanyHistory companyHistory)
        {
            var count = _context.CompanyHistory?.Count();

            if (count > 0)
            {
                var companyHistoryToUpdate = _context.CompanyHistory?.FirstOrDefault();

                
                companyHistoryToUpdate.FirstSection = companyHistory.FirstSection;
                companyHistoryToUpdate.SecondSection = companyHistory.SecondSection;
                companyHistoryToUpdate.ThirdSection = companyHistory.ThirdSection;
                companyHistoryToUpdate.FourthSection = companyHistory.FourthSection;

                _context.Entry(companyHistoryToUpdate).Property(i => i.FirstSection).IsModified = true;
                _context.Entry(companyHistoryToUpdate).Property(i => i.SecondSection).IsModified = true;
                _context.Entry(companyHistoryToUpdate).Property(i => i.ThirdSection).IsModified = true;
                _context.Entry(companyHistoryToUpdate).Property(i => i.FourthSection).IsModified = true;
                return await _context.SaveChangesAsync() > 0;

            }
            else
            {
                _context.CompanyHistory?.Add(companyHistory);
                return await _context.SaveChangesAsync() > 0;
            }

           
        }

        public async Task<bool> UpdateExpertise(CompanyHistory companyHistory)
        {
            var count = _context.CompanyHistory?.Count();   
            if(count > 0)
            {
                var companyHistoryToUpdate = _context.CompanyHistory?.First();
                companyHistoryToUpdate.ExpertiseText = companyHistory.ExpertiseText;
                _context.Entry(companyHistoryToUpdate).Property(i => i.ExpertiseText).IsModified = true;


                if (!String.IsNullOrEmpty(companyHistory.ExpertiseImagePath))
                {
                    companyHistoryToUpdate.ExpertiseImagePath = companyHistory.ExpertiseImagePath;
                    _context.Entry(companyHistoryToUpdate).Property(i => i.ExpertiseImagePath).IsModified = true;
                }
                              
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.CompanyHistory?.Add(companyHistory);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateWorkforce(CompanyHistory companyHistory)
        {
            var count = _context.CompanyHistory?.Count();
            if (count > 0)
            {
                var companyHistoryToUpdate = _context.CompanyHistory?.First();
                companyHistoryToUpdate.WorkforceText = companyHistory.WorkforceText;
                _context.Entry(companyHistoryToUpdate).Property(i => i.WorkforceText).IsModified = true;

                if (!String.IsNullOrEmpty(companyHistory.WorkforceImagePath))
                {
                    companyHistoryToUpdate.WorkforceImagePath = companyHistory.WorkforceImagePath;
                    _context.Entry(companyHistoryToUpdate).Property(i => i.WorkforceImagePath).IsModified = true;
                }

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.CompanyHistory?.Add(companyHistory);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        
        public async Task<bool> UpdateTechnology(CompanyHistory companyHistory)
        {
            var count = _context.CompanyHistory?.Count();
            if (count > 0)
            {
                var companyHistoryToUpdate = _context.CompanyHistory?.First();
                companyHistoryToUpdate.TechnologyText = companyHistory.TechnologyText;
                
                _context.Entry(companyHistoryToUpdate).Property(i => i.TechnologyText).IsModified = true;

                if (!String.IsNullOrEmpty(companyHistory.TechnologyImagePath))
                {
                    companyHistoryToUpdate.TechnologyImagePath = companyHistory.TechnologyImagePath;

                    _context.Entry(companyHistoryToUpdate).Property(i => i.TechnologyImagePath).IsModified = true;
                }
                
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.CompanyHistory?.Add(companyHistory);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        //UpdateCompanyHistoryImagePath
        public async Task<bool> UpdateCompanyHistoryImagePath(CompanyHistory companyHistory)
        {
            var count = _context.CompanyHistory?.Count();
            if (count > 0)
            {
                var companyHistoryToUpdate = _context.CompanyHistory?.First();
                
                companyHistoryToUpdate.CompanyHistoryImagePath = companyHistory.CompanyHistoryImagePath;

                _context.Entry(companyHistoryToUpdate).Property(i => i.CompanyHistoryImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.CompanyHistory?.Add(companyHistory);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        
        public async Task<bool> UpdateCompanyProfileBannerImagePath(CompanyHistory companyHistory)
        {
            var count = _context.CompanyHistory?.Count();
            if (count > 0)
            {
                var companyHistoryToUpdate = _context.CompanyHistory?.First();

                companyHistoryToUpdate.CompanyProfileBannerImagePath = companyHistory.CompanyProfileBannerImagePath;

                _context.Entry(companyHistoryToUpdate).Property(i => i.CompanyProfileBannerImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.CompanyHistory?.Add(companyHistory);
                return await _context.SaveChangesAsync() > 0;
            }
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

    }
}
