
using Harmoni.Business.Mapping;
using Harmoni.Business.Services.Abstracts;
using Harmoni.Business.Services.Concretes;
using Harmoni.Core.RepAbstracts;
using Harmoni.Data.DAL;
using Harmoni.Data.RepConcretes;
using Microsoft.EntityFrameworkCore;

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
			builder.Services.AddControllers();
			builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("cString")));
			builder.Services.AddAutoMapper(typeof(MapProfile));
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ISettingRepository, SettingRepository>();
            builder.Services.AddScoped<ISettingService,SettingService>();
            var app = builder.Build();

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
