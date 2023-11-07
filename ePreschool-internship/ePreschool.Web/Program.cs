using ePreschool.Infrastructure;
using ePreschool.Infrastructure.Reporsitories;
using ePreschool.Infrastructure.UnitOfWork;
using ePreschool.Service;
using ePreschool.Service.Mapper;
using AutoMapper;

using Microsoft.EntityFrameworkCore;
using ePreschool.Shared.ModelBinders.DecimalModelBinder;
using ePreschool.Shared.ModelBinders.DateTimeModelBinder;
using ePreschool.Shared.Services.Crypto;
using ePreschool.Web.Services.UserManager;
using Microsoft.AspNetCore.Mvc.Razor;
using ePreschool.Shared.Config;
using Microsoft.AspNetCore.Localization;
using FluentValidation.AspNetCore;
using ePreschool.Web.Services.FlashMessages;
using ePreschool.Infrastructure.Repositories;
using ePreschool.Web.Services.Toastr;
using ePreschool.Web.Services.ActivityLogger;
using ePreschool.Web.Services.Dropdown;
using ePreschool.Shared.Services;
using ePreschool.Web.Services.FileManager;
using ePreschool.Shared.Services.Email;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSingleton<ICrypto, Crypto>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IPreschoolsService, PreschoolsService>();
builder.Services.AddScoped<ICountiresService, CountiresService>();
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
builder.Services.AddScoped<IPreschoolsRepository, PreschoolsRepository>();
builder.Services.AddScoped<IPreschoolsService, PreschoolsService>();
builder.Services.AddScoped<IBusinessUnitRepository, BusinessUnitRepository>();
builder.Services.AddScoped<IBusinessUnitService, BusinessUnitService>();
builder.Services.AddScoped<IApplicationUserRoleRepository, ApplicationUserRoleRepository>();
builder.Services.AddScoped<IApplicationUserRoleService, ApplicationUserRoleService>();
builder.Services.AddScoped<IEmail, Email>();
builder.Services.AddScoped<IBusinessUnitProgramRepository, BusinessUnitProgramRepository>();
builder.Services.AddScoped<IBusinessUnitProgramService, BusinessUnitProgramService>();
builder.Services.AddScoped<IChildRepository, ChildRepository>();
builder.Services.AddScoped<IChildService, ChildService>();
builder.Services.AddScoped<IParentChildRepository, ParentChildRepository>();
builder.Services.AddScoped<IParentChildService, ParentChildService>();
builder.Services.AddScoped<IParentRepository, ParentRepository>();
builder.Services.AddScoped<IParentService, ParentService>();
builder.Services.AddScoped<IWorkingProgramRepository, WorkingProgramRepository>();
builder.Services.AddScoped<IWorkingProgramService, WorkingProgramService>();




builder.Services.AddScoped<ILogService, LogService>();

builder.Services.AddScoped<IToastr, Toastr>();
builder.Services.AddScoped<IActivityLogger, ActivityLogger>();
builder.Services.AddScoped<IFileManager, FileManager>();





builder.Services.AddScoped<IApplicationUsersRepository, ApplicationUsersRepository>();
builder.Services.AddScoped<ICitiesRepository, CitiesRepository>();
builder.Services.AddScoped<ICitiesService, CitiesService>();

builder.Services.AddScoped<ILogRepository, LogRepository>();

builder.Services.AddScoped<IDropdown, Dropdown>();
builder.Services.AddScoped<ILanguageManager, LanguageManager>();




builder.Services.AddAutoMapper(typeof(Program), typeof(MapperProfiles));
builder.Services.AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Program>());
builder.Services.AddScoped<IFlashMessages, FlashMessages>();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllersWithViews(options => {
    options.ModelBinderProviders.Add(new DecimalModelBinderProvider());
    options.ModelBinderProviders.Add(new DateTimeModelBinderProvider());
}).AddSessionStateTempDataProvider()
    .AddDataAnnotationsLocalization()
        .AddSessionStateTempDataProvider()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix, options =>
{
    options.ResourcesPath = LocalizerConfig.TranslationsRelativePath;
})
    ;
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

#region Localization

builder.Services.AddLocalization(options => options.ResourcesPath = LocalizerConfig.TranslationsRelativePath);

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture(LocalizerConfig.DefaultLanguage.CultureInfo.Name);
    options.SupportedCultures = options.SupportedUICultures = LocalizerConfig.SupportedLanguages.Select(sl => sl.CultureInfo).ToList();
});

#endregion

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();
app.UseMiddleware<RequestLocalizationMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await app.RunAsync();
