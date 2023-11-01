
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
    public class RemittancesRepository : IRemittancesRepository
    {
        private readonly ProjectDbContext _context;

        public RemittancesRepository(ProjectDbContext context)   
        {
            _context = context;
        }
        public Task<Remittences> GetRemittances()
        {
            Remittences remittances  = _context.Remittences.FirstOrDefault();
            return Task.FromResult(remittances);
        }

        public async Task<bool> UpdateBannerImagePath(Remittences remittances)
        {
            var count = _context.Remittences.Count();
            if (count > 0)
            {
                var  remittancesToUpdate = _context.Remittences?.First();

                remittancesToUpdate.BannerImagePath = remittances.BannerImagePath;

                _context.Entry(remittancesToUpdate).Property(i => i.BannerImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.Remittences?.Add(remittances);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateFirstSectionLeft(Remittences remittances)
        {
            var count = _context.Remittences.Count();
            if (count > 0)
            {
                var remittancesToUpdate = _context.Remittences?.First();

                remittancesToUpdate.FirstSectionLeftTitle = remittances.FirstSectionLeftTitle;
                remittancesToUpdate.FirstSectionLeftText = remittances.FirstSectionLeftText;
                if (!string.IsNullOrEmpty(remittances.FirstSectionLeftImagePath))
                {
                    remittancesToUpdate.FirstSectionLeftImagePath = remittances.FirstSectionLeftImagePath;
                    _context.Entry(remittancesToUpdate).Property(i => i.FirstSectionLeftImagePath).IsModified = true;
                }

                _context.Entry(remittancesToUpdate).Property(i => i.FirstSectionLeftTitle).IsModified = true;
                _context.Entry(remittancesToUpdate).Property(i => i.FirstSectionLeftText).IsModified = true;
                
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.Remittences?.Add(remittances);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateFirstSectionRight(Remittences remittancesmodel)
        {
            var count = _context.Remittences.Count();
            if (count > 0)
            {
                var remittancesToUpdate = _context.Remittences?.First();

                remittancesToUpdate.FirstSectionRightTitle = remittancesmodel.FirstSectionRightTitle;
                remittancesToUpdate.FirstSectionRightText = remittancesmodel.FirstSectionRightText;
                if (!string.IsNullOrEmpty(remittancesmodel.FirstSectionRightImagePath))
                {
                    remittancesToUpdate.FirstSectionRightImagePath = remittancesmodel.FirstSectionRightImagePath;
                    _context.Entry(remittancesToUpdate).Property(i => i.FirstSectionRightImagePath).IsModified = true;
                }

                _context.Entry(remittancesToUpdate).Property(i => i.FirstSectionRightTitle).IsModified = true;
                _context.Entry(remittancesToUpdate).Property(i => i.FirstSectionRightText).IsModified = true;

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.Remittences?.Add(remittancesmodel);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateFourthSection(Remittences remittancesmodel)
        {
            var count = _context.Remittences.Count();
            if (count > 0)
            {
                var remittancesToUpdate = _context.Remittences?.First();

                remittancesToUpdate.FourthSectionLeftTitle = remittancesmodel.FourthSectionLeftTitle;
                remittancesToUpdate.FourthSectionLeftText = remittancesmodel.FourthSectionLeftText;

                remittancesToUpdate.FourthSectionRightTitle = remittancesmodel.FourthSectionRightTitle;
                remittancesToUpdate.FourthSectionRightText = remittancesmodel.FourthSectionRightText;

                _context.Entry(remittancesToUpdate).Property(i => i.FourthSectionLeftTitle).IsModified = true;
                _context.Entry(remittancesToUpdate).Property(i => i.FourthSectionLeftText).IsModified = true;
                _context.Entry(remittancesToUpdate).Property(i => i.FourthSectionRightTitle).IsModified = true;
                _context.Entry(remittancesToUpdate).Property(i => i.FourthSectionRightText).IsModified = true;

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.Remittences?.Add(remittancesmodel);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateInnerSection(Remittences remittances)
        {
            var count = _context.Remittences.Count();
            if (count > 0)
            {
                var remittancesToUpdate = _context.Remittences?.First();

                remittancesToUpdate.InnerSectionTitle = remittances.InnerSectionTitle;
                remittancesToUpdate.InnerSectionDescription = remittances.InnerSectionDescription;

              
                _context.Entry(remittancesToUpdate).Property(i => i.InnerSectionTitle).IsModified = true;
                _context.Entry(remittancesToUpdate).Property(i => i.InnerSectionDescription).IsModified = true;

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.Remittences?.Add(remittances);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateRemitNow(Remittences remittancesmodel)
        {
            var count = _context.Remittences.Count();
            if (count > 0)
            {
                var remittancesToUpdate = _context.Remittences?.First();

                remittancesToUpdate.RemitNowText = remittancesmodel.RemitNowText;
                remittancesToUpdate.RemitNowImageOneText = remittancesmodel.RemitNowImageOneText;
                remittancesToUpdate.RemitNowImageTwoText = remittancesmodel.RemitNowImageTwoText;

                if (!string.IsNullOrEmpty(remittancesmodel.RemitNowImageOne))
                {
                    remittancesToUpdate.RemitNowImageOne = remittancesmodel.RemitNowImageOne;
                    _context.Entry(remittancesToUpdate).Property(i => i.RemitNowImageOne).IsModified = true;
                }
                if (!string.IsNullOrEmpty(remittancesmodel.RemitNowImageTwo))
                {
                    remittancesToUpdate.RemitNowImageTwo = remittancesmodel.RemitNowImageTwo;
                    _context.Entry(remittancesToUpdate).Property(i => i.RemitNowImageTwo).IsModified = true;
                }
                _context.Entry(remittancesToUpdate).Property(i => i.RemitNowText).IsModified = true;
                _context.Entry(remittancesToUpdate).Property(i => i.RemitNowImageOneText).IsModified = true;
                _context.Entry(remittancesToUpdate).Property(i => i.RemitNowImageTwoText).IsModified = true;   

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.Remittences?.Add(remittancesmodel);
                return await _context.SaveChangesAsync() > 0;
            }
        }

       

        public async Task<bool> UpdateSecondSection(Remittences remittancesmodel)
        {
            var count = _context.Remittences.Count();
            if (count > 0)
            {
                var remittancesToUpdate = _context.Remittences?.First();

                remittancesToUpdate.SecondSectionTitle = remittancesmodel.SecondSectionTitle;
                remittancesToUpdate.SecondSectionText = remittancesmodel.SecondSectionText;
                if (!string.IsNullOrEmpty(remittancesmodel.SecondSectionImagePath))
                {
                    remittancesToUpdate.SecondSectionImagePath = remittancesmodel.SecondSectionImagePath;
                    _context.Entry(remittancesToUpdate).Property(i => i.SecondSectionImagePath).IsModified = true;
                }

                _context.Entry(remittancesToUpdate).Property(i => i.SecondSectionTitle).IsModified = true;
                _context.Entry(remittancesToUpdate).Property(i => i.SecondSectionText).IsModified = true;

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.Remittences?.Add(remittancesmodel);  
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateSliderImageFile(Remittences remittances)
        {
            var count = _context.Remittences.Count();
            if (count > 0)
            {
                var remittancesToUpdate = _context.Remittences?.First();

               
                if (!string.IsNullOrEmpty(remittances.SliderOneImagePath))
                {
                    remittancesToUpdate.SliderOneImagePath = remittances.SliderOneImagePath;
                    _context.Entry(remittancesToUpdate).Property(i => i.SliderOneImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(remittances.SliderTwoImagePath))
                {
                    remittancesToUpdate.SliderTwoImagePath = remittances.SliderTwoImagePath;
                    _context.Entry(remittancesToUpdate).Property(i => i.SliderTwoImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(remittances.SliderThreeImagePath))
                {
                    remittancesToUpdate.SliderThreeImagePath = remittances.SliderThreeImagePath;
                    _context.Entry(remittancesToUpdate).Property(i => i.SliderThreeImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(remittances.SliderFourImagePath))
                {
                    remittancesToUpdate.SliderFourImagePath = remittances.SliderFourImagePath;
                    _context.Entry(remittancesToUpdate).Property(i => i.SliderFourImagePath).IsModified = true;
                }

                

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.Remittences?.Add(remittances);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateThirdSection(Remittences remittancesmodel)
        {
            var count = _context.Remittences.Count();
            if (count > 0)
            {
                var remittancesToUpdate = _context.Remittences?.First();

                remittancesToUpdate.ThirdSectionTitle = remittancesmodel.ThirdSectionTitle;
                remittancesToUpdate.ThirdSectionText = remittancesmodel.ThirdSectionText;
                if (!string.IsNullOrEmpty(remittancesmodel.ThirdSectionImagePath))
                {
                    remittancesToUpdate.ThirdSectionImagePath = remittancesmodel.ThirdSectionImagePath;
                    _context.Entry(remittancesToUpdate).Property(i => i.ThirdSectionImagePath).IsModified = true;
                }

                _context.Entry(remittancesToUpdate).Property(i => i.ThirdSectionTitle).IsModified = true;
                _context.Entry(remittancesToUpdate).Property(i => i.ThirdSectionText).IsModified = true;

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.Remittences?.Add(remittancesmodel);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateVideoLink(Remittences remittances)
        {
            var count = _context.Remittences.Count();
            if (count > 0)
            {
                var remittancesToUpdate = _context.Remittences?.First();

                remittancesToUpdate.VideoOneText = remittances.VideoOneText;
                remittancesToUpdate.VideoOneLink = remittances.VideoOneLink;
                remittancesToUpdate.VideoTwoText = remittances.VideoTwoText;
                remittancesToUpdate.VideoTwoLink = remittances.VideoTwoLink;   

                _context.Entry(remittancesToUpdate).Property(i => i.VideoOneText).IsModified = true;
                _context.Entry(remittancesToUpdate).Property(i => i.VideoOneLink).IsModified = true;
                _context.Entry(remittancesToUpdate).Property(i => i.VideoTwoText).IsModified = true;
                _context.Entry(remittancesToUpdate).Property(i => i.VideoTwoLink).IsModified = true;

                if (!string.IsNullOrEmpty(remittances.VideoTwoThumbnailImagePath))
                {
                    remittancesToUpdate.VideoTwoThumbnailImagePath = remittances.VideoTwoThumbnailImagePath;
                    _context.Entry(remittancesToUpdate).Property(i => i.VideoTwoThumbnailImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(remittances.VideoOneThumbnailImagePath))
                {
                    remittancesToUpdate.VideoOneThumbnailImagePath = remittances.VideoOneThumbnailImagePath;
                    _context.Entry(remittancesToUpdate).Property(i => i.VideoOneThumbnailImagePath).IsModified = true;
                }



                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.Remittences?.Add(remittances);
                return await _context.SaveChangesAsync() > 0;
            }
        }
    }
}
