using AutoMapper;
using Automate.Application.DataTransferObjects.Maintenance;
using Automate.Application.DataTransferObjects.Technician;
using Automate.Application.Repositories;
using Automate.Application.Services.Interfaces;
using Automate.Domain.Entities;

namespace Automate.Application.Services.Implementations
{
    public class MaintenanceService : IMaintenanceService
    {
        private readonly IMaintenanceRepository _maintenanceRepository;
        private readonly IMapper _mapper;

        public MaintenanceService(IMaintenanceRepository maintenanceRepository, IMapper mapper)
        {
            _maintenanceRepository=maintenanceRepository;
            _mapper=mapper;
        }

        public async Task<MaintenanceDto> GetByIdAsync(int id)
        {
            var maintenance = await _maintenanceRepository.GetByIdAsync(id);
            if (maintenance is null)
            {
                return new MaintenanceDto();
            }

            return _mapper.Map<MaintenanceDto>(maintenance);
        }

        public async Task<List<MaintenanceDto>> GetAllAsync()
        {
            var maintenances = await _maintenanceRepository.GetAll();
            return _mapper.Map<List<MaintenanceDto>>(maintenances);
        }

        public async Task AddAsync(MaintenanceDto maintenanceDto)
        {
            var maintenanceDb = _mapper.Map<Maintenance>(maintenanceDto);
            await _maintenanceRepository.Add(maintenanceDb);
        }

        public async Task UpdateAsync(int id, MaintenanceDto maintenanceDto)
        {
            var maintenance = await _maintenanceRepository.GetByIdAsync(id);
            if (maintenance is null)
            {
                throw new ArgumentNullException($"Cannot find any maintenance based on this Id to update. Id:{id}");
            }

            maintenance.DueDate = maintenanceDto.DueDate;
            maintenance.PreviewServiceDate = maintenanceDto.PreviewServiceDate;
            maintenance.NextServiceDate = maintenanceDto.NextServiceDate;
            maintenance.CurrentMileage = maintenanceDto.CurrentMileage;
            maintenance.IntervalInMiles = maintenanceDto.IntervalInMiles;
            maintenance.CarId = maintenanceDto.CarId;
            maintenance.Description = maintenanceDto.Description;
            maintenance.Type = maintenanceDto.Type;

            await _maintenanceRepository.UpdateAsync(maintenance);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
