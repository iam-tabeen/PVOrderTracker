using Microsoft.EntityFrameworkCore;
using OrderTracker.Data;
namespace PVOrderTracker

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
          
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(); // <-- Enable session services
            builder.Services.AddDistributedMemoryCache(); // <-- Required for session
            builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=orders.db")); // For local database

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseRouting();

            app.UseStaticFiles();
            app.UseSession(); // <-- Enable session middleware
            app.UseAuthorization();
            // temp edit to trigger commit

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");

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
