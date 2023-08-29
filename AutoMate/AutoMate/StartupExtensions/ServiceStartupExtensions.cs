using AutoMapper.EquivalencyExpression;
using Automate.Application.Repositories;
using Automate.Infrastructure.Data;
using Automate.Infrastructure.Data.Repositories;
using Automate.Infrastructure.Database.Repositories;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

namespace App.StartupExtensions
{
    public static class ServiceStartupExtensions
    {
        /// <summary>
        /// Configures core configurations, routing, compression and etc
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <param name="configuration">Configuration</param>
        /// <returns>Service Collection</returns>
        public static IServiceCollection ConfigureAppCore(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddControllers(config =>
            //{
            //    config.Filters.Add<ExceptionHandlerFilter>();
            //    config.Filters.Add<ResultFilter>();
            //})
            //    .AddNewtonsoftJson(options =>
            //    {
            //        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //    });

            //JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            //{
            //    ContractResolver = new CamelCasePropertyNamesContractResolver(),
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //};

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
            });

            services.AddOptions()
                .AddMemoryCache()
                .AddHttpContextAccessor();



            services.AddHealthChecks();

            return services;
        }

        /// <summary>
        /// Configures db context pool
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <param name="configuration">Configuration</param>
        /// <returns>Service Collection</returns>
        public static IServiceCollection ConfigureAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Automate");

            services.AddDbContext<AutomateDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
                options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
            }, ServiceLifetime.Scoped);


            return services;
        }

        /// <summary>
        /// Configures Cross-Origin Resource Sharing
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <param name="configuration">Configuration</param>
        /// <returns>Service Collection</returns>
        public static IServiceCollection ConfigureAppCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options => options.AddPolicy("Cors", policy => policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(host => true)
                .WithExposedHeaders("Content-Disposition")));

            return services;
        }

        /// <summary>
        /// Configures services
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <returns>Service Collection</returns>
        public static IServiceCollection ConfigureAppServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddCollectionMappers();
            },
            typeof(Automate.Application.MappingProfile));

            // Repositories
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IMaintenanceRepository, MaintenanceRepository>();
            services.AddScoped<ITechnicianRepository, TechnicianRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();

            return services;
        }
    }
}
