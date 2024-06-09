
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FullstackNorthwind.Business.Abstract;
using FullstackNorthwind.Business.Concrete;
using FullstackNorthwind.Business.DependencyResolvers.AutoFac;
using FullstackNorthwind.DataAccess.Abstract;
using FullstackNorthwind.DataAccess.Concrete.EntityFramework.Contexts;

namespace FullstackNorthwind.WebAPI;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.

		builder.Services.AddControllers();
		//builder.Services.AddScoped<IProductService, ProductManager>();
		//builder.Services.AddScoped<IProductDal, EfProductDal>();
		builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
			.ConfigureContainer<ContainerBuilder>(builder =>
			{
				builder.RegisterModule(new AutofacBusinessModule());
			});
		
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();


		app.MapControllers();

		app.Run();
	}
}
