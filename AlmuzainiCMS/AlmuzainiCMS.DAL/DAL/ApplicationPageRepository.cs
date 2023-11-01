
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
    public class ApplicationPageRepository : IApplicationPageRepository
    {
        private readonly ProjectDbContext _context;

        public ApplicationPageRepository(ProjectDbContext context)   
        {
            _context = context;
        }

        public async Task<bool> DeleteUserGuides(UserGuide userGuide)
        {
            var itemToDelete = _context.UserGuides.Find(userGuide.Id);
            if (itemToDelete != null)
            {
                _context.UserGuides.Remove(itemToDelete);
                return await _context.SaveChangesAsync() > 0;
            }

            return await Task.FromResult(false);
        }

        public async Task<ApplicationPage> GetApplicationPage()
        {
            ApplicationPage applicationPage  = _context.ApplicationPages.FirstOrDefault();
            return await Task.FromResult(applicationPage);
        }

        public Task<ICollection<UserGuide>> GetUserGuides()
        {
            ICollection<UserGuide> userGuides = _context.UserGuides.OrderBy(a => a.SerialNo).ToList();
            return Task.FromResult(userGuides);
        }

        public Task<UserGuide> GetUserGuidesBySerialNo(int serialNo)
        {
            UserGuide userGuide = new UserGuide();
            if (_context.UserGuides.Count() > 0)
            {
                userGuide = _context.UserGuides.Where(a => a.SerialNo == serialNo).FirstOrDefault();
            }

            return Task.FromResult(userGuide);
        }

        public async Task<bool> UpdateAboutBoxDescriptionSection(ApplicationPage applicationPage)
        {
            var count = _context.ApplicationPages.Count();
            if (count > 0)
            {
                var appPagesToUpdate = _context.ApplicationPages?.First();

                appPagesToUpdate.ABoutBoxDescription = applicationPage.ABoutBoxDescription;
              

                if (!string.IsNullOrEmpty(applicationPage.ApplePlayStoreIconImagePath))
                {
                    appPagesToUpdate.ApplePlayStoreIconImagePath = applicationPage.ApplePlayStoreIconImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.ApplePlayStoreIconImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(applicationPage.GooglePlayStoreIconImagePath))
                {
                    appPagesToUpdate.GooglePlayStoreIconImagePath = applicationPage.GooglePlayStoreIconImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.GooglePlayStoreIconImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(applicationPage.AppGalleryIconImagePath))
                {
                    appPagesToUpdate.AppGalleryIconImagePath = applicationPage.AppGalleryIconImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.AppGalleryIconImagePath).IsModified = true;
                }
                _context.Entry(appPagesToUpdate).Property(i => i.ABoutBoxDescription).IsModified = true;
                

                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ApplicationPages?.Add(applicationPage);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateAppFeaturesSection(ApplicationPage applicationPage)
        {
            var count = _context.ApplicationPages.Count();
            if (count > 0)
            {
                var appPagesToUpdate = _context.ApplicationPages?.First();

                appPagesToUpdate.AppFeaturesSectionTitle = applicationPage.AppFeaturesSectionTitle;
                appPagesToUpdate.AppFeaturesSectionOneDescriptionSectionOne = applicationPage.AppFeaturesSectionOneDescriptionSectionOne;
                appPagesToUpdate.AppFeaturesSectionOneDescriptionSectionTwo = applicationPage.AppFeaturesSectionOneDescriptionSectionTwo;
                appPagesToUpdate.AppFeaturesSectionOneTitle = applicationPage.AppFeaturesSectionOneTitle;

                appPagesToUpdate.AppFeaturesSectionTwoTitle = applicationPage.AppFeaturesSectionTwoTitle;
                appPagesToUpdate.AppFeaturesSectionTwoDescriptionSectionOne = applicationPage.AppFeaturesSectionTwoDescriptionSectionOne;
                appPagesToUpdate.AppFeaturesSectionTwoDescriptionSectionTwo = applicationPage.AppFeaturesSectionTwoDescriptionSectionTwo;

                appPagesToUpdate.AppFeaturesSectionThreeTitle = applicationPage.AppFeaturesSectionThreeTitle;
                appPagesToUpdate.AppFeaturesSectionThreeDescriptionSectionOne = applicationPage.AppFeaturesSectionThreeDescriptionSectionOne;
                appPagesToUpdate.AppFeaturesSectionThreeDescriptionSectionTwo = applicationPage.AppFeaturesSectionThreeDescriptionSectionTwo;

                appPagesToUpdate.AppFeaturesSectionFourthTitle = applicationPage.AppFeaturesSectionFourthTitle;
                appPagesToUpdate.AppFeaturesSectionFourthDescriptionSectionOne = applicationPage.AppFeaturesSectionFourthDescriptionSectionOne;
                appPagesToUpdate.AppFeaturesSectionFourthDescriptionSectionTwo = applicationPage.AppFeaturesSectionFourthDescriptionSectionTwo;

                _context.Entry(appPagesToUpdate).Property(i => i.AppFeaturesSectionTitle).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.AppFeaturesSectionOneDescriptionSectionOne).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.AppFeaturesSectionOneDescriptionSectionTwo).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.AppFeaturesSectionOneTitle).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.AppFeaturesSectionTwoTitle).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.AppFeaturesSectionTwoDescriptionSectionOne).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.AppFeaturesSectionTwoDescriptionSectionTwo).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.AppFeaturesSectionThreeTitle).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.AppFeaturesSectionThreeDescriptionSectionOne).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.AppFeaturesSectionThreeDescriptionSectionTwo).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.AppFeaturesSectionFourthTitle).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.AppFeaturesSectionFourthDescriptionSectionOne).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.AppFeaturesSectionFourthDescriptionSectionTwo).IsModified = true;


                if (!string.IsNullOrEmpty(applicationPage.AppFeaturesSectionOneImagePath))
                {
                    appPagesToUpdate.AppFeaturesSectionOneImagePath = applicationPage.AppFeaturesSectionOneImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.AppFeaturesSectionOneImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(applicationPage.AppFeaturesSectionTwoImagePath))
                {
                    appPagesToUpdate.AppFeaturesSectionTwoImagePath = applicationPage.AppFeaturesSectionTwoImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.AppFeaturesSectionTwoImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(applicationPage.AppFeaturesSectionThreeImagePath))
                {
                    appPagesToUpdate.AppFeaturesSectionThreeImagePath = applicationPage.AppFeaturesSectionThreeImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.AppFeaturesSectionThreeImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(applicationPage.AppFeaturesSectionFourthImagePath))
                {
                    appPagesToUpdate.AppFeaturesSectionFourthImagePath = applicationPage.AppFeaturesSectionFourthImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.AppFeaturesSectionFourthImagePath).IsModified = true;
                }



                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ApplicationPages?.Add(applicationPage);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateApplicationIcon(ApplicationPage applicationPage)
        {
            var count = _context.ApplicationPages.Count();
            if (count > 0)
            {
                var appPagesToUpdate = _context.ApplicationPages?.First();


                if (!string.IsNullOrEmpty(applicationPage.ApplicationIconOneImagePath))
                {
                    appPagesToUpdate.ApplicationIconOneImagePath = applicationPage.ApplicationIconOneImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.ApplicationIconOneImagePath).IsModified = true;
                }

                if (!string.IsNullOrEmpty(applicationPage.ApplicationIconTwoImagePath))
                {
                    appPagesToUpdate.ApplicationIconTwoImagePath = applicationPage.ApplicationIconTwoImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.ApplicationIconTwoImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(applicationPage.ApplicationIconThreeImagePath))
                {
                    appPagesToUpdate.ApplicationIconThreeImagePath = applicationPage.ApplicationIconThreeImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.ApplicationIconThreeImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(applicationPage.ApplicationIconFourImagePath))
                {
                    appPagesToUpdate.ApplicationIconFourImagePath = applicationPage.ApplicationIconFourImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.ApplicationIconFourImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(applicationPage.ApplicationIconFiveImagePath))
                {
                    appPagesToUpdate.ApplicationIconFiveImagePath = applicationPage.ApplicationIconFiveImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.ApplicationIconFiveImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(applicationPage.ApplicationIconSixImagePath))
                {
                    appPagesToUpdate.ApplicationIconSixImagePath = applicationPage.ApplicationIconSixImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.ApplicationIconSixImagePath).IsModified = true;
                }


                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ApplicationPages?.Add(applicationPage);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateApplicationPageVideoLink(ApplicationPage applicationPage)
        {
            var count = _context.ApplicationPages.Count();
            if (count > 0)
            {
                var appPagesToUpdate = _context.ApplicationPages?.First();

                appPagesToUpdate.VideoOneTitle = applicationPage.VideoOneTitle;
                appPagesToUpdate.VideoOneLink = applicationPage.VideoOneLink;
                appPagesToUpdate.VideoTwoTitle = applicationPage.VideoTwoTitle;
                appPagesToUpdate.VideoTwoLink = applicationPage.VideoTwoLink;
                appPagesToUpdate.VideoThreeTitle = applicationPage.VideoThreeTitle;

                appPagesToUpdate.VideoThreeLink = applicationPage.VideoThreeLink;
                appPagesToUpdate.VideoFourLink = applicationPage.VideoFourLink;
                appPagesToUpdate.VideoFiveLink = applicationPage.VideoFiveLink;
                appPagesToUpdate.VideoFourTitle = applicationPage.VideoFourTitle;
                appPagesToUpdate.VideoFiveTitle = applicationPage.VideoFiveTitle;

                _context.Entry(appPagesToUpdate).Property(i => i.VideoOneTitle).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.VideoOneLink).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.VideoTwoTitle).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.VideoTwoLink).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.VideoThreeTitle).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.VideoThreeLink).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.VideoFourLink).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.VideoFiveLink).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.VideoFourTitle).IsModified = true;
                _context.Entry(appPagesToUpdate).Property(i => i.VideoFiveTitle).IsModified = true;

                if (!string.IsNullOrEmpty(applicationPage.VideoTwoThumbnailImagePath))
                {
                    appPagesToUpdate.VideoTwoThumbnailImagePath = applicationPage.VideoTwoThumbnailImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.VideoTwoThumbnailImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(applicationPage.VideoOneThumbnailImagePath))
                {
                    appPagesToUpdate.VideoOneThumbnailImagePath = applicationPage.VideoOneThumbnailImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.VideoOneThumbnailImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(applicationPage.VideoThreeThumbnailImagePath))
                {
                    appPagesToUpdate.VideoThreeThumbnailImagePath = applicationPage.VideoThreeThumbnailImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.VideoThreeThumbnailImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(applicationPage.VideoFourThumbnailImagePath))
                {
                    appPagesToUpdate.VideoFourThumbnailImagePath = applicationPage.VideoFourThumbnailImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.VideoFourThumbnailImagePath).IsModified = true;
                }
                if (!string.IsNullOrEmpty(applicationPage.VideoFiveThumbnailImagePath))
                {
                    appPagesToUpdate.VideoFiveThumbnailImagePath = applicationPage.VideoFiveThumbnailImagePath;
                    _context.Entry(appPagesToUpdate).Property(i => i.VideoFiveThumbnailImagePath).IsModified = true;
                }



                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ApplicationPages?.Add(applicationPage);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateBannerImagePath(ApplicationPage applicationPage)
        {
            var count = _context.ApplicationPages.Count();
            if (count > 0)
            {
                var applicationPagesToUpdate = _context.ApplicationPages?.First();

                applicationPagesToUpdate.BannerImagePath = applicationPage.BannerImagePath;

                _context.Entry(applicationPagesToUpdate).Property(i => i.BannerImagePath).IsModified = true;
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ApplicationPages?.Add(applicationPage);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateInnerSection(ApplicationPage applicationPage)
        {
            var count = _context.ApplicationPages.Count();
            if (count > 0)
            {
                var applicationPagesToUpdate = _context.ApplicationPages?.First();

                applicationPagesToUpdate.InnerSectionTitle = applicationPage.InnerSectionTitle;
             


                _context.Entry(applicationPagesToUpdate).Property(i => i.InnerSectionTitle).IsModified = true;
                
                return await _context.SaveChangesAsync() > 0;
            }
            else
            {
                _context.ApplicationPages?.Add(applicationPage);
                return await _context.SaveChangesAsync() > 0;
            }
        }

        public async Task<bool> UpdateUserGuides(UserGuide userGuide)
        {
            int count = _context.UserGuides.Count();
            userGuide.SerialNo = count + 1;


            _context.UserGuides.AddRange(userGuide);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
