using Cafe.Infrastructure.Integrations.IOC;
using Cafe.UI.WEB.MVC.Dtos;

namespace Cafe.UI.WEB.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //contains information about current HttpContext :: the request, response, user, session 
            //If you use AddControllersWithViews(), it is not registered automatically, so you must register it yourself if you need it.

            builder.Services.ConfigIntegration(builder.Configuration);
            builder.Services.Configure<HTTPClientSettings>(builder.Configuration.GetSection("HTTPClientSettings")); // bind the HTTPClientSettings object with setting json file


            // Add services to the container. //DI container 
            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
