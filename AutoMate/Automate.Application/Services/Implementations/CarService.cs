using AutoMapper;
using Automate.Application.DataTransferObjects.Appointment;
using Automate.Application.DataTransferObjects.Car;
using Automate.Application.DataTransferObjects.Maintenance;
using Automate.Application.Repositories;
using Automate.Application.Services.Interfaces;
using Automate.Domain.Entities;

namespace Automate.Application.Services.Implementations
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarService(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CarDto carDto)
        {
            var car = _mapper.Map<Car>(carDto);
            await _carRepository.AddAsync(car); 
        }

        public async Task<CarDto> GetByIdAsync(int id)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car is null)
            {
                return new CarDto();
            }

            return _mapper.Map<CarDto>(car);
        }

        public async Task<List<CarDto>> GetAllAsync()
        {
            var cars = await _carRepository.GetAllAsync();
            return _mapper.Map<List<CarDto>>(cars);
        }

        public async Task UpdateAsync(int id, CarDto carDto)
        {
            var car = await _carRepository.GetByIdAsync(id);
            if (car is null)
            {
                throw new ArgumentNullException($"Cannot find any car based on this Id to update. Id:{id}");
            }

            car.Brand = carDto.Brand;
            car.CurrentMileage = carDto.CurrentMileage;
            car.Number = carDto.Number;
            car.RegistrationNumber = carDto.RegistrationNumber;
            car.Color = carDto.Color;
            car.Inactive = carDto.Inactive;
            car.Model = carDto.Model;
            car.OriginCountry = carDto.OriginCountry;
            car.OwnerId = carDto.OwnerId;
            car.ProductionYear = carDto.ProductionYear;

            if (carDto.Appointments != null && carDto.Appointments.Any())
            {
                var dbAppointments = new List<Appointment>();
                var appointmentUpdated = carDto.Appointments.Where(e => e.CarId == car.Id).ToList();
                foreach (var appointment in appointmentUpdated)
                {
                    dbAppointments.Add(new Appointment(appointment.Id)
                    {
                        CarId = appointment.CarId,
                        Date = appointment.Date,
                        Description = appointment.Description,
                        Inactive = appointment.Inactive,
                        IsCompleted = appointment.IsCompleted,
                        MaintenanceId = appointment.MaintenanceId,
                        TechnicianId = appointment.TechnicianId,
                    });
                }

                var appointmentAdd = carDto.Appointments.Where(e => e.CarId == 0).ToList();
                foreach (var appointment in appointmentAdd)
                {
                    dbAppointments.Add(new Appointment(appointment.CarId)
                    {
                        Date = appointment.Date,
                        Description = appointment.Description,
                        Inactive = appointment.Inactive,
                        IsCompleted = appointment.IsCompleted,
                        MaintenanceId = appointment.MaintenanceId,
                        TechnicianId = appointment.TechnicianId,
                    });
                }
            }

            if (carDto.Maintenances != null && carDto.Maintenances.Any())
            {
                var dbMaintenances = new List<Maintenance>();
                var maintenancesUpdated = carDto.Maintenances.Where(e => e.CarId == car.Id).ToList();
                foreach (var maintenance in maintenancesUpdated)
                {
                    dbMaintenances.Add(new Maintenance(maintenance.Id)
                    {
                        CurrentMileage = maintenance.CurrentMileage,
                        Description = maintenance.Description,
                        DueDate = maintenance.DueDate,
                        Inactive = maintenance.Inactive,
                        IntervalInMiles = maintenance.IntervalInMiles,
                        NextServiceDate = maintenance.NextServiceDate,
                        PreviewServiceDate = maintenance.PreviewServiceDate,
                        Type = maintenance.Type,
                    });
                }

                var maintenancesAdd = carDto.Maintenances.Where(e => e.CarId == 0).ToList();
                foreach (var maintenance in maintenancesAdd)
                {
                    dbMaintenances.Add(new Maintenance(maintenance.Id)
                    {
                        CurrentMileage = maintenance.CurrentMileage,
                        Description = maintenance.Description,
                        DueDate = maintenance.DueDate,
                        Inactive = maintenance.Inactive,
                        IntervalInMiles = maintenance.IntervalInMiles,
                        NextServiceDate = maintenance.NextServiceDate,
                        PreviewServiceDate = maintenance.PreviewServiceDate,
                        Type = maintenance.Type,
                    });
                }
            }

            await _carRepository.UpdateAsync(car);
        }
    }
}
