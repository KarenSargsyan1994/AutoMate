using Automate.Application.DataTransferObjects.Car;
using Automate.Application.DataTransferObjects.Maintenance;
using Automate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Application.Services.Interfaces
{
    public interface IMaintenanceService
    {
        Task<MaintenanceDto> GetByIdAsync(int id);
        Task<List<MaintenanceDto>> GetAllAsync();
        Task UpdateAsync(int id, MaintenanceDto maintenanceDto);
        Task AddAsync(MaintenanceDto maintenanceDto);
        Task DeleteAsync(int id);
    }
}
