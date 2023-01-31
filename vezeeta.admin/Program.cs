using AutoMapper;
using Luxury_Back;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Text.Json.Serialization;
using vezeeta.BL;
using vezeeta.DBL;

using Microsoft.EntityFrameworkCore.Migrations;
using vezeeta.BL.Managers.CenterManger;
using vezeeta.DBL.Repos.CenterRepo;
using vezeeta.DBL.UnitOfWork;
using vezeeta.DBL.Repos.SpecialityRepo;

namespace vezeeta.admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region SqlDbContext
            builder.Services.AddDbContext<VezeetaDB>(db =>
            {
    
        db.UseSqlServer(builder.Configuration.GetConnectionString("vezeetaDb"));
            });
            #endregion

            #region services
            builder.Services.AddControllers()
               .AddJsonOptions(o => o.JsonSerializerOptions
                   .ReferenceHandler = ReferenceHandler.IgnoreCycles);
            #endregion

            #region auth

            builder.Services.AddAuthentication("cookieAuth")
                .AddCookie("cookieAuth", a =>
                {
                    a.LoginPath = "/AdminAuth/login";
                    a.LogoutPath = "/AdminAuth/logout";
                });
            #endregion

            #region mapper
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            #endregion

            #region language
            builder.Services.AddLocalization();
            builder.Services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
            builder.Services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(Options =>
                {
                    Options.DataAnnotationLocalizerProvider = (Type, factory) => factory.Create(typeof(JsonStringLocalizerFactory));
                });
            builder.Services.Configure<RequestLocalizationOptions>(Options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo(name:"en-US"),
                     new CultureInfo(name:"ar-EG")

                };
                Options.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[0], uiCulture: supportedCultures[0]);

                Options.SupportedCultures = supportedCultures;
                Options.SupportedUICultures = supportedCultures;

            });
            #endregion

            #region Repos
            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<ICenterRepo, CenterRepo>();
            builder.Services.AddScoped<ISpecialityRepo, SpecialityRepo>();
            #endregion

            #region Manager
            builder.Services.AddScoped<IAdminManager, AdminManager>();
            builder.Services.AddScoped<IDepartmentManager, DepartmentManager>();
            builder.Services.AddScoped<ICenterManager, CenterManager>();
            #endregion

            #region UnitOfWork
            builder.Services.AddScoped<IUnitOfRepo, UnitOfRepo>();
            builder.Services.AddScoped<IUnitOfManger, UnitOfManger>();
            #endregion

            var app = builder.Build();

            #region App Language
            var supportedCultures = new[] { "en-US", "ar-EG" };
            var LocalizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(LocalizationOptions);
            #endregion

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
