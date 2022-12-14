using AutoMapper;
using Luxury_Back;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Text.Json.Serialization;
using vezeeta.BL.Managers;
using vezeeta.BL.Managers.DepartmentManager;
using vezeeta.BL.Mapper;
using vezeeta.DBL.db.context;
using vezeeta.DBL.Repos.UserRepo;

namespace vezeeta.admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            builder.Services.AddDbContext<VezeetaDB>(db =>
            {
                db.UseSqlServer(builder.Configuration.GetConnectionString("vezeetaDb"));
            });

            builder.Services.AddControllers()
               .AddJsonOptions(o => o.JsonSerializerOptions
                   .ReferenceHandler = ReferenceHandler.IgnoreCycles);
            #region Repos
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            #endregion

            #region Manager
            builder.Services.AddScoped<IDepartmentManager, DepartmentManager>();
            #endregion

            #region Mappers
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            #endregion

            var app = builder.Build();

            #region Language
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

/*
 * migrationBuilder.InsertData(
                table: "departments",
                columns: new[]
                {
                    "name_ar",
                    "name_en",
                    "is_active",
                },
                values: new object[,]
                {
                    {"??????", "hospital", true },
                    {"????? ????", "Private clinic", true },
                    {"?????? ??????", "Outpatient clinics", true },
                }
                
                );
*/