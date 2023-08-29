using AutoMapper;
using Automate.Application.DataTransferObjects.Appointment;
using Automate.Application.DataTransferObjects.Car;
using Automate.Application.DataTransferObjects.Maintenance;
using Automate.Application.DataTransferObjects.Owner;
using Automate.Application.DataTransferObjects.Technician;
using Automate.Domain.Entities;

namespace Automate.Application
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<CarDto, Car>();
            CreateMap<AppointmentDto, Appointment>();
            CreateMap<MaintenanceDto, Maintenance>();
            CreateMap<OwnerDto, Owner>();
            CreateMap<TechnicianDto, Technician>();
        }
    }
}
