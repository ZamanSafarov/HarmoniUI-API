

using Harmoni.UI.Controllers;
using Harmoni.UI.DTOs.account;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Harmoni.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
	        .AddJwtBearer(options =>
	            {
		        options.TokenValidationParameters = new TokenValidationParameters
		        {
			        ValidateIssuer = true,
			        ValidateAudience = true,
			        ValidateLifetime = true,
			        ValidateIssuerSigningKey = true,
			        ValidIssuer = builder.Configuration["Jwt:issuer"],
			        ValidAudience = builder.Configuration["Jwt:audience"],
			        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:secretKey"]))
		        };
	        });
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

		

		
			app.Use(async (context, next) =>
			{
				var isAuth = context.Request.Cookies.TryGetValue("JWToken", out string jwtToken);

				if (jwtToken is not null) {
					var handler = new JwtSecurityTokenHandler();
					JwtSecurityToken token = handler.ReadJwtToken(jwtToken);
					string role = token.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Role)?.Value;
					
					if (context.Request.Path.StartsWithSegments("/admin", StringComparison.OrdinalIgnoreCase) && role == "User")
					{
						context.Response.Redirect("/NotFound");
						return;
					}
				}
				else
				{
					if (context.Request.Path.StartsWithSegments("/admin", StringComparison.OrdinalIgnoreCase) && !isAuth)
					{
						context.Response.Redirect("/NotFound");
						return;
					}
				}


				
				await next();
			});

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
