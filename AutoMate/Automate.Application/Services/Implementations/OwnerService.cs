using AutoMapper;
using Automate.Application.DataTransferObjects.Owner;
using Automate.Application.Repositories;
using Automate.Application.Services.Interfaces;
using Automate.Domain.Entities;

namespace Automate.Application.Services.Implementations
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerService(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository=ownerRepository;
            _mapper=mapper;
        }

        public async Task AddAsync(OwnerDto ownerDto)
        {
            var owner = _mapper.Map<Owner>(ownerDto);
            await _ownerRepository.AddAsync(owner);
        }

        public async Task<List<OwnerDto>> GetAllAsync()
        {
            var owners = await _ownerRepository.GetAllAsync();
            return _mapper.Map<List<OwnerDto>>(owners);
        }

        public async Task<OwnerDto> GetByIdAsync(int id)
        {
            var owner = await _ownerRepository.GetByIdAsync(id);
            return _mapper.Map<OwnerDto>(owner);
        }

        public async Task UpdateAsync(int id, OwnerDto ownerDto)
        {
            var owner = _mapper.Map<Owner>(ownerDto);
            await _ownerRepository.UpdateAsync(owner);
        }
    }
}
