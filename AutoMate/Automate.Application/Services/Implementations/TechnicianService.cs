using AutoMapper;
using Automate.Application.DataTransferObjects.Technician;
using Automate.Application.Repositories;
using Automate.Application.Services.Interfaces;
using Automate.Domain.Entities;

namespace Automate.Application.Services.Implementations
{
    public class TechnicianService : ITechnicianService
    {
        private readonly ITechnicianRepository _technicianRepository;
        private readonly IMapper _mapper;

        public TechnicianService(ITechnicianRepository technicianRepository, IMapper mapper)
        {
            _technicianRepository=technicianRepository;
            _mapper=mapper;
        }

        public async Task AddAsync(TechnicianDto technicianDto)
        {
            var technician = _mapper.Map<Technician>(technicianDto);
            await _technicianRepository.Add(technician);
        }

        public async Task<List<TechnicianDto>> GetAllAsync()
        {
            var technicians = await _technicianRepository.GetAll();
            return _mapper.Map<List<TechnicianDto>>(technicians);
        }

        public async Task<TechnicianDto> GetByIdAsync(int id)
        {
            var technician = await _technicianRepository.GetByIdAsync(id);
            if (technician is null)
            {
                return new TechnicianDto();
            }

            return _mapper.Map<TechnicianDto>(technician);
        }

        public async Task UpdateAsync(int id, TechnicianDto technicianDto)
        {
            var technician = await _technicianRepository.GetByIdAsync(id);
            if (technician is null)
            {
                throw new ArgumentNullException($"Cannot find any technician based on this Id to update. Id:{id}");
            }

            technician.Certification = technicianDto.Certification;
            technician.Specialization = technicianDto.Specialization;
            technician.Phone = technicianDto.Phone;
            technician.Email = technicianDto.Email;
            technician.Inactive = technicianDto.Inactive;
            technician.Name = technicianDto.Name;

            await _technicianRepository.UpdateAsync(technician);
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
