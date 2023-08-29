using Automate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Application.Repositories
{
    public interface ICarRepository : IRepository<Car>
    {
        Task<Car> GetByIdAsync(int id);
        Task UpdateAsync(Car car);
        Task DeleteAsync(int id);
        Task AddAsync(Car car);
        Task<List<Car>> GetAllAsync();
    }
}
