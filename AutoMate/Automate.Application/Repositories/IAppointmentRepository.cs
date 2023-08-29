using Automate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Application.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<Appointment> GetByIdAsync(int id);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(int id);
    }
}
