using Automate.Application.DataTransferObjects.Appointment;
using Automate.Application.DataTransferObjects.Car;

namespace Automate.Application.Services.Interfaces
{
    public interface ICarService
    {
        Task<List<CarDto>> GetAllAsync();
        Task<CarDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, CarDto carDto);
        Task AddAsync(CarDto carDto);
    }
}
