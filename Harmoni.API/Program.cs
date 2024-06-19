
using FluentValidation.AspNetCore;
using Harmoni.Business.DTOs;
using Harmoni.Business.Mapping;
using Harmoni.Business.Services.Abstracts;
using Harmoni.Business.Services.Concretes;
using Harmoni.Core.RepAbstracts;
using Harmoni.Data.DAL;
using Harmoni.Data.RepConcretes;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Harmoni.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddCors(options=>
            //{
            //	options.AddDefaultPolicy(policy =>
            //	{
            //		policy.WithOrigins();
            //	});
            //});

            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            }).AddFluentValidation(opt => opt.RegisterValidatorsFromAssembly(typeof(SettingGetDTOValidator).Assembly)).AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            }); ;

			builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("cString")));

			builder.Services.AddAutoMapper(typeof(MapProfile));
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

          
            builder.Services.AddScoped<ISettingRepository, SettingRepository>();
            builder.Services.AddScoped<ISettingService,SettingService>();
            builder.Services.AddScoped<IFAQContentRepository, FAQContentRepository>();
            builder.Services.AddScoped<IFAQRepository, FAQRepository>();
            builder.Services.AddScoped<IFAQContentService, FAQContentService>();
            builder.Services.AddScoped<IFAQService, FAQService>();
            builder.Services.AddScoped<ISpeakerRepository, SpeakerRepository>();
            builder.Services.AddScoped<ISpeakerService, SpeakerService>();
            builder.Services.AddScoped<IAwardRepository, AwardRepository>();
            builder.Services.AddScoped<IAwardService, AwardService>();
            builder.Services.AddScoped<IAdvantageRepository, AdvantageRepository>();
            builder.Services.AddScoped<IAdvantageService, AdvantageService>();
			builder.Services.AddScoped<IGalleryRepository, GalleryRepository>();
			builder.Services.AddScoped<IGalleryService, GalleryService>();


			var app = builder.Build();


            // Retrieve the configuration and set WebRootPath
            var webRootPath = app.Configuration["WebRootPath"];

            // Log the WebRootPath to ensure it is read correctly
            Console.WriteLine($"WebRootPath: {webRootPath}"); // Add this line

            if (!string.IsNullOrEmpty(webRootPath))
            {
                // Ensure the IWebHostEnvironment is configured with the WebRootPath
                var env = app.Services.GetRequiredService<IWebHostEnvironment>();
                env.WebRootPath = webRootPath;
            }
            else
            {
                // Log or handle the scenario where the WebRootPath configuration is not set
                throw new Exception("WebRootPath configuration is not set.");
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthentication();
			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
