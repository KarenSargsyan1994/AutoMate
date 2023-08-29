using Automate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Application.Repositories
{
    public interface IOwnerRepository
    {
        Task<Owner> GetByIdAsync(int id);
        Task UpdateAsync(Owner owner);
        Task DeleteAsync(int id);
        Task AddAsync(Owner owner);
        Task<List<Owner>> GetAllAsync();
    }
}
