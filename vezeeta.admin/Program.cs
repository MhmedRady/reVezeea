using Luxury_Back;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Text.Json.Serialization;
using vezeeta.BL;
using vezeeta.DBL;

namespace vezeeta.admin
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            #region services
            builder.Services.AddScoped<IAdminManager, AdminManager>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            #endregion

            #region Database

            builder.Services.AddDbContext<VezeetaDB>(
                a =>
                {
                    a.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
                });

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

            builder.Services.AddControllers()
               .AddJsonOptions(o => o.JsonSerializerOptions
                   .ReferenceHandler = ReferenceHandler.IgnoreCycles);

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