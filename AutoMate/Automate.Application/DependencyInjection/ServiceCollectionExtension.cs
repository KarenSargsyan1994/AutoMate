using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Automate.Application.Services.Implementations;
using Automate.Application.Services.Interfaces;
using Automate.Application.Commands.Owner;
using FluentValidation;
using MediatR;

namespace Automate.Application.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static void AddAutoMateApplicationDI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg =>cfg.RegisterServicesFromAssembly(typeof(CreateOwnerCommand).Assembly));

            services.AddValidatorsFromAssemblyContaining<CreateOwnerCommandValidator>();

            // Services 
            services.AddScoped<IAppointmentService, AppointmentService>();
            services.AddScoped<IMaintenanceService, MaintenanceService>();
            services.AddScoped<ITechnicianService, TechnicianService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IOwnerService, OwnerService>();
        }
    }
}
