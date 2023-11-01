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
    public class MissionVisionValuesRepository : IMissionVisionValuesRepository
    {
        private readonly ProjectDbContext _context;
        public MissionVisionValuesRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public Task<MissionVisionValues> GetMissionVisionValues()
        {

            MissionVisionValues missionVisionValues = new MissionVisionValues();
            if(_context.MissionVisionValues.Count() > 0)
            {
                missionVisionValues = _context.MissionVisionValues.Include(a => a.ValuesItems).ToList().FirstOrDefault();
                    //.SingleOrDefault(b => b.Id == missionVisionValues.Id);
            }

            //MissionVisionValues missionVisionValues = _context.MissionVisionValues.FirstOrDefault();

            //MissionVisionValues missionVisionValues1 = _context.MissionVisionValues.Include(m => m.ValuesItems).SingleOrDefault(mvv => mvv.Id == missionVisionValues.Id);

            //var authorWithArticles = context.Authors
            //    .Include(a => a.NewsArticles)
            //    .SingleOrDefault(a => a.AuthorId == authorId);

            return Task.FromResult(missionVisionValues);
        }

        public bool MissionVisionValuesExists()
        {
            bool result = _context.MissionVisionValues.Count() > 0;
            return result;
        }

       
        public async Task<bool> UpdateMissionVisionValuesBanner(MissionVisionValues missionVisionValues)
        {
            var count = _context.MissionVisionValues?.Count();
            if (count > 0)
            {
                var missionVisionValuesToUpdate = _context.MissionVisionValues?.First();

                missionVisionValuesToUpdate.MissionVisionBannerImagePath = missionVisionValues.MissionVisionBannerImagePath;

                _context.Entry(missionVisionValuesToUpdate).Property(i => i.MissionVisionBannerImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.MissionVisionValues?.Add(missionVisionValues);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateVision(MissionVisionValues missionVisionValues)
        {
            var count = _context.MissionVisionValues.Count();
            if (count > 0)
            {
                var missionVision = _context.MissionVisionValues?.FirstOrDefault();
                missionVision.VisionText = missionVisionValues.VisionText;
                _context.Entry(missionVision).Property(i => i.VisionText).IsModified = true;


                if (!String.IsNullOrEmpty(missionVisionValues.VisionImagePath))
                {
                    missionVision.VisionImagePath = missionVisionValues.VisionImagePath;
                    _context.Entry(missionVision).Property(i => i.VisionImagePath).IsModified = true;
                }

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.MissionVisionValues.Add(missionVisionValues);
                return await _context.SaveChangesAsync() > 0;
            }
        }
        public async Task<bool> UpdateMission(MissionVisionValues missionVisionValues)
        {
            var count = _context.MissionVisionValues.Count();
            if (count > 0)
            {
                var missionVision = _context.MissionVisionValues?.FirstOrDefault();
                missionVision.MissionText = missionVisionValues.MissionText;
                _context.Entry(missionVision).Property(i => i.MissionText).IsModified = true;


                if (!String.IsNullOrEmpty(missionVisionValues.MissionImagePath))
                {
                    missionVision.MissionImagePath = missionVisionValues.MissionImagePath;
                    _context.Entry(missionVision).Property(i => i.MissionImagePath).IsModified = true;
                }

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.MissionVisionValues.Add(missionVisionValues);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateValues(MissionVisionValues missionVisionValues)
        {
            var count = _context.MissionVisionValues.Count();
            if (count > 0)
            {
                var missionVision = _context.MissionVisionValues?.FirstOrDefault();
                missionVision.ValuesText = missionVisionValues.ValuesText;
                _context.Entry(missionVision).Property(i => i.ValuesText).IsModified = true;


                if (!String.IsNullOrEmpty(missionVisionValues.ValuesImagePath))
                {
                    missionVision.ValuesImagePath = missionVisionValues.ValuesImagePath;
                    _context.Entry(missionVision).Property(i => i.ValuesImagePath).IsModified = true;
                }

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.MissionVisionValues.Add(missionVisionValues);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        //UpdateValuesItem
        public async Task<bool> UpdateValuesItem(ValuesItem valuesItem)
        {
            int count = _context.ValuesItems.Count();
            valuesItem.SerialNo = count + 1;
            

            _context.ValuesItems.AddRange(valuesItem);
            return await _context.SaveChangesAsync() > 0;

            
        }

        public async Task<bool> DeleteValuesItem(ValuesItem valuesItem)    
        {
            var itemToDelete = _context.ValuesItems.Find(valuesItem.Id);
            if (itemToDelete != null)
            {
                _context.ValuesItems.Remove(itemToDelete);
                return await _context.SaveChangesAsync() > 0;
            }

            return await Task.FromResult(false);
            


        }

        

        public Task<ICollection<ValuesItem>> GetMissionVisionValuesItems()
        {
            ICollection<ValuesItem>  missionVisionValuesItems = _context.ValuesItems.OrderBy(a => a.SerialNo).ToList();
            return Task.FromResult(missionVisionValuesItems);    
        }
        public Task<ValuesItem> GetMissionVisionValuesItemsBySerialNo(int serialNo)
        {
            ValuesItem missionVisionValuesItems = new ValuesItem();
            if (_context.ValuesItems.Count() > 0)
            {
               missionVisionValuesItems = _context.ValuesItems.Where(a => a.SerialNo == serialNo).FirstOrDefault();
            }
            
            return Task.FromResult(missionVisionValuesItems);
        }
        
    }
}
