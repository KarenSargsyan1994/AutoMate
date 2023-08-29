using Automate.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Application.Repositories
{
    public interface IMaintenanceRepository : IRepository<Maintenance>
    {
        Task<Maintenance> GetByIdAsync(int id);
        Task UpdateAsync(Maintenance maintenance);
        Task DeleteAsync(int id);
    }
}
