using Automate.Application.DataTransferObjects.Car;
using Automate.Application.DataTransferObjects.Owner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Application.Services.Interfaces
{
    public interface IOwnerService
    {
        Task<List<OwnerDto>> GetAllAsync();
        Task<OwnerDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, OwnerDto ownerDto);
        Task AddAsync(OwnerDto ownerDto);
    }
}
