using Automate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Application.Repositories
{
    public interface ITechnicianRepository : IRepository<Technician>
    {
        Task<Technician> GetByIdAsync(int id);
        Task UpdateAsync(Technician technician);
        Task DeleteAsync(int id);
    }
}
