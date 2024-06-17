

using Harmoni.UI.Controllers;

namespace Harmoni.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
           
            builder.Services.AddScoped<HomeController>();
            builder.Services.AddScoped<HttpClient>();

			var app = builder.Build();

            var env = app.Services.GetRequiredService<IWebHostEnvironment>();
            var webRootPath = env.WebRootPath;

            // Set the WebRootPath as an environment variable.
            Environment.SetEnvironmentVariable("WebRootPath", webRootPath);

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
		 name: "areas",
		 pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}"
	   );

			app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
