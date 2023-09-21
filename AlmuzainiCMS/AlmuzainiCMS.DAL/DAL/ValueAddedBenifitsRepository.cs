using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.DataBaseContext.DataBaseContext;
using AlmuzainiCMS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DAL.DAL
{
    public class ValueAddedBenifitsRepository : IValueAddedBenifitsRepository
    {
        private readonly ProjectDbContext _context;

        public ValueAddedBenifitsRepository(ProjectDbContext context)  
        {
            _context = context;
        }
        public async Task<ValueAddedBenifits> GetValueAddedBenifits()
        {
            ValueAddedBenifits valueAddedBenifits = _context.ValueAddedBenifits.FirstOrDefault();
            return await Task.FromResult(valueAddedBenifits);   
        }

        public async Task<bool> UpdateBannerImagePath(ValueAddedBenifits valueAddedBenifits)
        {
            var count = _context.ValueAddedBenifits.Count();
            if (count > 0)
            {
                var valueAddedBenifitsToUpdate = _context.ValueAddedBenifits?.First();

                valueAddedBenifitsToUpdate.BannerImagePath = valueAddedBenifits.BannerImagePath;   

                _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.BannerImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ValueAddedBenifits?.Add(valueAddedBenifits);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateInnerSection(ValueAddedBenifits valueAddedBenifits)
        {
            var count = _context.ValueAddedBenifits.Count();
            if (count > 0)
            {
                var valueAddedBenifitsToUpdate = _context.ValueAddedBenifits?.First();

                valueAddedBenifitsToUpdate.InnerSectionTitle = valueAddedBenifits.InnerSectionTitle;
                valueAddedBenifitsToUpdate.InnerSectionDescription = valueAddedBenifits.InnerSectionDescription;


                _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.InnerSectionTitle).IsModified = true;
                _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.InnerSectionDescription).IsModified = true;

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ValueAddedBenifits?.Add(valueAddedBenifits);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateLeftSectionFirst(ValueAddedBenifits valueAddedBenifits)
        {
            var count = _context.ValueAddedBenifits.Count();
            if (count > 0)
            {
                var valueAddedBenifitsToUpdate = _context.ValueAddedBenifits?.First();

                valueAddedBenifitsToUpdate.LeftSectionFirstTitle = valueAddedBenifits.LeftSectionFirstTitle;
                valueAddedBenifitsToUpdate.LeftSectionFirstText = valueAddedBenifits.LeftSectionFirstText;
                if (!string.IsNullOrEmpty(valueAddedBenifits.LeftSectionFirstImagePath))
                {
                    valueAddedBenifitsToUpdate.LeftSectionFirstImagePath = valueAddedBenifits.LeftSectionFirstImagePath;
                    _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.LeftSectionFirstImagePath).IsModified = true;
                }

                _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.LeftSectionFirstTitle).IsModified = true;
                _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.LeftSectionFirstText).IsModified = true;

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ValueAddedBenifits?.Add(valueAddedBenifits);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateLeftSectionSecond(ValueAddedBenifits valueAddedBenifits)
        {
            var count = _context.ValueAddedBenifits.Count();
            if (count > 0)
            {
                var valueAddedBenifitsToUpdate = _context.ValueAddedBenifits?.First();

                valueAddedBenifitsToUpdate.LeftSectionSecondTitle = valueAddedBenifits.LeftSectionSecondTitle;
                valueAddedBenifitsToUpdate.LeftSectionSecondText = valueAddedBenifits.LeftSectionSecondText;
                if (!string.IsNullOrEmpty(valueAddedBenifits.LeftSectionSecondImagePath))
                {
                    valueAddedBenifitsToUpdate.LeftSectionSecondImagePath = valueAddedBenifits.LeftSectionSecondImagePath;
                    _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.LeftSectionSecondImagePath).IsModified = true;
                }

                _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.LeftSectionSecondTitle).IsModified = true;
                _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.LeftSectionSecondText).IsModified = true;

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ValueAddedBenifits?.Add(valueAddedBenifits);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateLeftSectionThird(ValueAddedBenifits valueAddedBenifits)
        {
            var count = _context.ValueAddedBenifits.Count();
            if (count > 0)
            {
                var valueAddedBenifitsToUpdate = _context.ValueAddedBenifits?.First();

                valueAddedBenifitsToUpdate.LeftSectionThirdTitle = valueAddedBenifits.LeftSectionThirdTitle;
                valueAddedBenifitsToUpdate.LeftSectionThirdText = valueAddedBenifits.LeftSectionThirdText;
                if (!string.IsNullOrEmpty(valueAddedBenifits.LeftSectionThirdImagePath))
                {
                    valueAddedBenifitsToUpdate.LeftSectionThirdImagePath = valueAddedBenifits.LeftSectionThirdImagePath;
                    _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.LeftSectionThirdImagePath).IsModified = true;
                }

                _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.LeftSectionThirdTitle).IsModified = true;
                _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.LeftSectionThirdText).IsModified = true;

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ValueAddedBenifits?.Add(valueAddedBenifits);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateRightSectionFirst(ValueAddedBenifits valueAddedBenifits)
        {
            var count = _context.ValueAddedBenifits.Count();
            if (count > 0)
            {
                var valueAddedBenifitsToUpdate = _context.ValueAddedBenifits?.First();

                valueAddedBenifitsToUpdate.RightSectionFirstTitle = valueAddedBenifits.RightSectionFirstTitle;
                valueAddedBenifitsToUpdate.RightSectionFirstText = valueAddedBenifits.RightSectionFirstText;
                if (!string.IsNullOrEmpty(valueAddedBenifits.RightSectionFirstImagePath))
                {
                    valueAddedBenifitsToUpdate.RightSectionFirstImagePath = valueAddedBenifits.RightSectionFirstImagePath;
                    _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.RightSectionFirstImagePath).IsModified = true;
                }

                _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.RightSectionFirstTitle).IsModified = true;
                _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.RightSectionFirstText).IsModified = true;

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ValueAddedBenifits?.Add(valueAddedBenifits);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateRightSectionFourth(ValueAddedBenifits valueAddedBenifits)
        {
            var count = _context.ValueAddedBenifits.Count();
            if (count > 0)
            {
                var valueAddedBenifitsToUpdate = _context.ValueAddedBenifits?.First();

                valueAddedBenifitsToUpdate.RightSectionFourthTitle = valueAddedBenifits.RightSectionFourthTitle;
                valueAddedBenifitsToUpdate.RightSectionFourthText = valueAddedBenifits.RightSectionFourthText;
                if (!string.IsNullOrEmpty(valueAddedBenifits.RightSectionFourthImagePath))
                {
                    valueAddedBenifitsToUpdate.RightSectionFourthImagePath = valueAddedBenifits.RightSectionFourthImagePath;
                    _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.RightSectionFourthImagePath).IsModified = true;
                }

                _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.RightSectionFourthTitle).IsModified = true;
                _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.RightSectionFourthText).IsModified = true;

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ValueAddedBenifits?.Add(valueAddedBenifits);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateRightSectionSecond(ValueAddedBenifits valueAddedBenifits)
        {
            var count = _context.ValueAddedBenifits.Count();
            if (count > 0)
            {
                var valueAddedBenifitsToUpdate = _context.ValueAddedBenifits?.First();

                valueAddedBenifitsToUpdate.RightSectionSecondTitle = valueAddedBenifits.RightSectionSecondTitle;
                valueAddedBenifitsToUpdate.RightSectionSecondText = valueAddedBenifits.RightSectionSecondText;
                if (!string.IsNullOrEmpty(valueAddedBenifits.RightSectionSecondImagePath))
                {
                    valueAddedBenifitsToUpdate.RightSectionSecondImagePath = valueAddedBenifits.RightSectionSecondImagePath;
                    _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.RightSectionSecondImagePath).IsModified = true;
                }

                _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.RightSectionSecondTitle).IsModified = true;
                _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.RightSectionSecondText).IsModified = true;

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ValueAddedBenifits?.Add(valueAddedBenifits);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateRightSectionThird(ValueAddedBenifits valueAddedBenifits)
        {
            var count = _context.ValueAddedBenifits.Count();
            if (count > 0)
            {
                var valueAddedBenifitsToUpdate = _context.ValueAddedBenifits?.First();

                valueAddedBenifitsToUpdate.RightSectionThirdTitle = valueAddedBenifits.RightSectionThirdTitle;
                valueAddedBenifitsToUpdate.RightSectionThirdText = valueAddedBenifits.RightSectionThirdText;
                if (!string.IsNullOrEmpty(valueAddedBenifits.RightSectionThirdImagePath))
                {
                    valueAddedBenifitsToUpdate.RightSectionThirdImagePath = valueAddedBenifits.RightSectionThirdImagePath;
                    _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.RightSectionThirdImagePath).IsModified = true;
                }

                _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.RightSectionThirdTitle).IsModified = true;
                _context.Entry(valueAddedBenifitsToUpdate).Property(i => i.RightSectionThirdText).IsModified = true;

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ValueAddedBenifits?.Add(valueAddedBenifits);
                return await _context.SaveChangesAsync() > 0;
            }
        }
    }
}
