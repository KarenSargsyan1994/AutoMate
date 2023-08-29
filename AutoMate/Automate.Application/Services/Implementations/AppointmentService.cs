using AutoMapper;
using Automate.Application.DataTransferObjects.Appointment;
using Automate.Application.DataTransferObjects.Maintenance;
using Automate.Application.Repositories;
using Automate.Application.Services.Interfaces;
using Automate.Domain.Entities;

namespace Automate.Application.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<AppointmentDto> GetByIdAsync(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment is null)
            {
                return new AppointmentDto();
            }

            return _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<List<AppointmentDto>> GetAllAsync()
        {
            var appointments = await _appointmentRepository.GetAll();
            return _mapper.Map<List<AppointmentDto>>(appointments);
        }

        public async Task<AppointmentDto> AddAsync(AppointmentDto appointmentDto)
        {
            var appointment = _mapper.Map<Appointment>(appointmentDto);
            var appointmentDb = await _appointmentRepository.Add(appointment);
            return _mapper.Map<AppointmentDto>(appointmentDb);
        }

        public async Task<AppointmentDto> UpdateAsync(int id, AppointmentDto appointmentDto)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);
            if (appointment is null)
            {
                throw new ArgumentNullException($"Cannot find any appointment based on this Id to update. Id:{id}");
            }

            appointment.Description = appointmentDto.Description;
            appointment.Date = appointmentDto.Date;
            appointment.Inactive = appointmentDto.Inactive;
            appointment.CarId = appointmentDto.CarId;
            appointment.TechnicianId = appointmentDto.TechnicianId;
            appointment.MaintenanceId = appointmentDto.MaintenanceId;

            await _appointmentRepository.UpdateAsync(appointment);
            return _mapper.Map<AppointmentDto>(appointment);
        }

        public async Task<List<AppointmentDto>> GetAsync()
        {
            var appointments = await _appointmentRepository.GetAll();
            if (appointments is null)
            {
                return new List<AppointmentDto>();
            }

            return _mapper.Map<List<AppointmentDto>>(appointments);
        }
    }
}
