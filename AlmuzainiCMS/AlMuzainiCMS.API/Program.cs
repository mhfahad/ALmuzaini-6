using AlmuzainiCMS.BLL.BLL;
using AlmuzainiCMS.BLL.Interface;
using AlmuzainiCMS.DAL.DAL;
using AlmuzainiCMS.DAL.Interface;
using AlmuzainiCMS.DataBaseContext.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Protocol;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler.ToJson();
    
    //options.refeReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//add 
builder.Services.AddDbContextPool<ProjectDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DbContext, ProjectDbContext>();
builder.Services.AddScoped<INewsManager, NewsManager>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<ICompanyHistoryManager, CompanyHistoryManager>();
builder.Services.AddScoped<ICompanyHistoryRepository, CompanyHistoryRepository>();
builder.Services.AddScoped<IChairmanMessageManager, ChairmanMessageManager>();
builder.Services.AddScoped<IChairmanMessageRepository, ChairmanMessageRepository>();

builder.Services.AddScoped<IMissionVisionValuesManager, MissionVisionValuesManager>();
builder.Services.AddScoped<IMissionVisionValuesRepository, MissionVisionValuesRepository>();
builder.Services.AddScoped<ICorporateSocialResponsibilityManager, CorporateSocialResponsibilityManager>();
builder.Services.AddScoped<ICorporateSocialResponsibilityRepository, CorporateSocialResponsibilityRepository>();
builder.Services.AddScoped<IForeignCurrencyManager, ForeignCurrencyManager>();
builder.Services.AddScoped<IForeignCurrencyRepository, ForeignCurrencyRepository>();
builder.Services.AddScoped<IRemittancesRepository, RemittancesRepository>();
builder.Services.AddScoped<IRemittancesManager, RemittancesManager>();
builder.Services.AddScoped<IValueAddedBenifitsRepository, ValueAddedBenifitsRepository>();
builder.Services.AddScoped<IValueAddedBenifitsManager, ValueAddedBenifitsManager>();
builder.Services.AddScoped<IApplicationPageManager, ApplicationPageManager>();
builder.Services.AddScoped<IApplicationPageRepository, ApplicationPageRepository>();

builder.Services.AddScoped<IBranchManager, BranchManager>();
builder.Services.AddScoped<IBranchRepository, BranchRepository>();

builder.Services.AddScoped<IKoiskManager, KoiskManager>();
builder.Services.AddScoped<IKoiskRepository, KoiskRepository>();

builder.Services.AddScoped<IHomeManager, HomeManager>();
builder.Services.AddScoped<IHomeRepository, HomeRepository>();

builder.Services.AddScoped<IPromotionsManager, PromotionsManager>();
builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();

builder.Services.AddScoped<INewsPageManager, NewsPageManager>();
builder.Services.AddScoped<INewsPageRepository, NewsPageRepository>();
builder.Services.AddScoped<IContactUsManager, ContactUsManager>();
builder.Services.AddScoped<IContactUsRepository, ContactUsRepository>();

//builder.Services.AddAutoMapper(typeof(Program).Assembly);




//builder.Services.AddAutoMapper(typeof(Program).Assembly);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
