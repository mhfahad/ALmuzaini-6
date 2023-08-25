using AlmuzainiCMS.BLL.BLL;
using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.DAL.DAL.User;
using AlmuzainiCMS.DAL.Interface.User;
using AlmuzainiCMS.DataBaseContext.DataBaseContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
//using Rms_Core_313.Data;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AlmuzainiCMS.DAL.Interface.Currency;
using AlmuzainiCMS.DAL.DAL.CurrencyDAL;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.StaticFiles;
using SixLabors.ImageSharp.Web.DependencyInjection;
using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.DAL.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<StaticFileOptions>(options =>
{
    var provider = new FileExtensionContentTypeProvider();
    provider.Mappings[".webp"] = "image/webp";
    options.ContentTypeProvider = provider;
});

//HttpClientFactory configure
builder.Services.AddHttpClient("GetTTRate", c =>
{
    c.BaseAddress = new Uri("https://rateapi.muzaini.com:68/api/v1/Remittance/GetTTRate");
    c.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
    c.DefaultRequestHeaders.Add("ChannelID", "mobapi");
    c.DefaultRequestHeaders.Add("MechineID", "MachineID");
    c.DefaultRequestHeaders.Add("SessionID", "12345678901234567890123456789012");
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors( option =>
{
    option.AddPolicy( name: "AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
    });
});

builder.Services.AddDbContextPool<ProjectDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DbContext, ProjectDbContext>();
builder.Services.AddScoped<IUserCreateManager, UserCreateManager>();
builder.Services.AddScoped<IUserCreateRepository, UserCreateRepository>();
builder.Services.AddTransient<ICurrencySyncManager, CurrencySyncManager>();
builder.Services.AddTransient<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<INewsManager, NewsManager>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<ICompanyHistoryManager, CompanyHistoryManager>();
builder.Services.AddScoped<ICompanyHistoryRepository, CompanyHistoryRepository>();
builder.Services.AddScoped<IChairmanMessageManager, ChairmanMessageManager>();
builder.Services.AddScoped<IChairmanMessageRepository, ChairmanMessageRepository>();

builder.Services.AddScoped<IMissionVisionValuesManager, MissionVisionValuesManager>();
builder.Services.AddScoped<IMissionVisionValuesRepository, MissionVisionValuesRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(10);  
});

//builder.Services.AddImageSharp().SetMimeTypeMap(new Dictionary<string, string>
//        {
//            { "image/webp", "webp" }
//        });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//builder.Services.AddTransient<IUserInfoManager, UserInfoManager>();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();
app.UseAuthorization();
app.UseCors("AllowAll");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
