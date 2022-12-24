using future_academy.Contexts;
using Microsoft.EntityFrameworkCore;

namespace future_academy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllersWithViews();

            //builder.Services.AddDbContext<UniversityContext>(
            //    opt => opt.UseMySql(
            //        builder.Configuration.GetConnectionString("defaultConnection"),
            //        new MySqlServerVersion(new Version(8, 0, 31)))
            //    );

            builder.Services.AddDbContext<UniversityContext>(opt =>
            {
                opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}