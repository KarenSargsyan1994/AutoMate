using Automate.Application.DataTransferObjects.Technician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Application.Services.Interfaces
{
    public interface ITechnicianService
    {
        Task<TechnicianDto> GetByIdAsync(int id);
        Task<List<TechnicianDto>> GetAllAsync();
        Task UpdateAsync(int id, TechnicianDto technicianDto);
        Task AddAsync(TechnicianDto technicianDto);
        Task DeleteAsync(int id);
    }
}
