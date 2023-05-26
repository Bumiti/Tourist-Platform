using Microsoft.EntityFrameworkCore;
using Tourist_Platform.Models;
using Tourist_Platform.Services;

namespace Tourist_Platform
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<TouristDbContext>
                (p => p.UseSqlServer(builder.Configuration.GetConnectionString("mycon")));
            builder.Services.AddScoped<ILoginServices, LoginServices>();
            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Logins}/{action=Login}/{id?}");

            app.Run();
        }
    }
}