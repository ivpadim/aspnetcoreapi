using CityInfo.API.Entities;
using CityInfo.API.Services;
using CityInfo.API.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace CityInfo.API
{
	public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
			// Add framework services.
			services.AddMvc()
					.AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()));
			// Remove the lower case
			//.AddJsonOptions(o =>
			//{
			//	if(o.SerializerSettings.ContractResolver != null)
			//	{
			//		var castedResolver = o.SerializerSettings.ContractResolver as DefaultContractResolver;
			//		castedResolver.NamingStrategy = null;
			//	}
			//});

			services.Configure<MailSettings>(Configuration.GetSection("mailSettings"));
#if DEBUG
			services.AddTransient<IMailService, LocalMailService>();
#else
            services.AddTransient<IMailService, CloudMailService>();
#endif
			services.AddDbContext<CitiesDbContext>(o => o.UseSqlServer(Configuration["connectionStrings:citiesDbContextConnectionString"]));
			services.AddScoped<ICityRepository, CityRepository>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CitiesDbContext citiesDbContext)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			//loggerFactory.AddProvider(new NLogLoggerProvider());
			loggerFactory.AddNLog();

			citiesDbContext.EnsureSeedDataForContext();

			app.UseStatusCodePages();

			AutoMapper.Mapper.Initialize(config =>
			{
				config.CreateMap<Entities.City, Models.CityWithoutPointsOfInterestDto>();
				config.CreateMap<Entities.City, Models.CityDto>();
				config.CreateMap<Entities.PointOfInterest, Models.PointOfInterestDto>();
				config.CreateMap<Models.PointOfInterestForCreationDto, Entities.PointOfInterest>();
				config.CreateMap<Models.PointOfInterestForUpdateDto, Entities.PointOfInterest>();
				config.CreateMap<Entities.PointOfInterest, Models.PointOfInterestForUpdateDto>();
			});

            app.UseMvc();
        }
    }
}
