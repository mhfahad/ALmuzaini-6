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

    }
}
