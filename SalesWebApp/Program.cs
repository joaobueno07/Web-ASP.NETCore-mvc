using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebApp.Data;
using SalesWebApp.Services;


namespace SalesWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string configDb = "server=localhost;userid=root;password=jctbueno17071997@;database=bancoteste";

            builder.Services.AddDbContext<SalesWebAppContext>(options =>
               options.UseMySql(configDb, ServerVersion.AutoDetect(configDb)));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<SellerService>();
            builder.Services.AddScoped<DepartmentService>();


            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var enUS = new CultureInfo("en-US");
                var localizationOptions = new RequestLocalizationOptions
                {
                    DefaultRequestCulture = new RequestCulture(enUS),
                    SupportedCultures = new List<CultureInfo> { enUS },
                    SupportedUICultures = new List<CultureInfo> { enUS }
                };

                app.UseRequestLocalization(localizationOptions);


                var services = scope.ServiceProvider;
                SeedingService.Seed(services);
            }


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

            app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
