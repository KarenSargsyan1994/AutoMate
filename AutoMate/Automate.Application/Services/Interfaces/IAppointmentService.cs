using Automate.Application.DataTransferObjects.Appointment;
using Automate.Application.DataTransferObjects.Technician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Application.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppointmentDto> GetByIdAsync(int id);
        Task<List<AppointmentDto>> GetAllAsync();
        Task<List<AppointmentDto>> GetAsync();
        Task<AppointmentDto> AddAsync(AppointmentDto appointmentDto);
        Task<AppointmentDto> UpdateAsync(int id, AppointmentDto appointmentDto);
    }
}
