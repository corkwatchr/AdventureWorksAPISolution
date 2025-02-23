
using AdventureWorksAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
			builder.Services.AddOpenApi();

			builder.Services.AddDbContext<AdventureWorksContext>(options =>
					options.UseSqlServer(builder.Configuration.GetConnectionString("AdventureWorksDb")));

			builder.Services.AddCors(OptionsBuilderConfigurationExtensions =>
			{
				OptionsBuilderConfigurationExtensions.AddPolicy("AllowAngularApp",
																		builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.MapOpenApi();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.UseCors("AllowAngularApp");
			app.MapControllers();

			app.Run();
		}
	}
}
