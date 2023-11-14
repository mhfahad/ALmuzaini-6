using AlmuzainiCMS.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmuzainiCMS.DataBaseContext.DataBaseContext
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
        : base(options)
        {
        }

        public DbSet<UsersInfo> usersInfos { get; set; }
        //public DbSet<CurrencyRate> CurrencyRates { get; set; }
        public DbSet<CurrencyCode> CurrenyCodes { get; set; }
        public DbSet<CurrencyRequest> CurrencyRequests { get; set; }
        public DbSet<GetTTRateResult> GetTrateResults { get; set; }

        public DbSet<News> News { get; set; }
        public DbSet<CompanyHistory> CompanyHistory { get; set; }
        public DbSet<ChairmanMessage> ChairmanMessage { get; set; }
        public DbSet<MissionVisionValues> MissionVisionValues { get; set; }
        public DbSet<ValuesItem> ValuesItems  { get; set; }
        public DbSet<CorporateSocialResponsibility> CorporateSocialResponsibilities { get; set; }
        public DbSet<ForeignCurrency> ForeignCurrency { get; set; }
        public DbSet<Corporate> Corporate { get; set; }
        public DbSet<RequiredDocument> RequiredDocuments { get; set; }   
        public DbSet<Remittences> Remittences { get; set; } 
        public DbSet<ValueAddedBenifits> ValueAddedBenifits { get; set; } 
        
        public DbSet<ApplicationPage> ApplicationPages { get; set; }    
        public DbSet<UserGuide> UserGuides { get; set; }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<BranchTopText> BranchTopTexts { get; set; }
        public DbSet<BranchDetail> BranchDetails { get; set; }

        public DbSet<HomeVUrl> HomeVUrls { get; set; }
        public DbSet<HomeMidSlide> HomeMidSlides { get; set; }

        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionNews> PromotionNews { get; set; }
 
        public DbSet<NewsSection> NewsSections { get; set; }
        public DbSet<NewsSectionNews> NewsSectionNews { get; set; }   

        public DbSet<ContactUs> ContactUs { get; set; }


    }
}
