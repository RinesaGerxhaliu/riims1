using Application.Interfaces;
using AutoMapper;
using RIIMS.Application.DTOs.InstitucioniDTOs;
using RIIMS.Domain.Entities;
using RIIMSAPI.Domain.Interfaces;

namespace RIIMS.Application.Services
{
    public class InstitucioniService : IInstitucioniService
    {
        private readonly IInstitucioniRepository _institucioniRepository;
        private readonly IMapper _mapper;

        public InstitucioniService(IInstitucioniRepository institucioniRepository, IMapper mapper)
        {
            _institucioniRepository = institucioniRepository;
            _mapper = mapper;
        }

        // GET ALL INSTITUCIONET
        public async Task<List<InstitucioniDTO>> GetAllAsync()
        {
            var institucioniList = await _institucioniRepository.GetAllAsync();
            return _mapper.Map<List<InstitucioniDTO>>(institucioniList);
        }

        // GET INSTITUCIONI BY ID
        public async Task<InstitucioniDTO?> GetByIdAsync(Guid id)
        {
            var institucioni = await _institucioniRepository.GetByIdAsync(id);
            return _mapper.Map<InstitucioniDTO>(institucioni);
        }

        // CREATE INSTITUCIONI
        public async Task<InstitucioniDTO> CreateAsync(AddInstitucioniRequestDTO addInstitucioniRequestDto)
        {
            var institucioni = _mapper.Map<Institucioni>(addInstitucioniRequestDto);
            var createdInstitucioni = await _institucioniRepository.CreateAsync(institucioni);

            return _mapper.Map<InstitucioniDTO>(createdInstitucioni);
        }

        // UPDATE INSTITUCIONI
        public async Task<InstitucioniDTO?> UpdateAsync(Guid id, UpdateInstitucioniRequestDTO updateInstitucioniRequestDto)
        {
            var institucioni = _mapper.Map<Institucioni>(updateInstitucioniRequestDto);
            var updatedInstitucioni = await _institucioniRepository.UpdateAsync(id, institucioni);

            return _mapper.Map<InstitucioniDTO>(updatedInstitucioni);
        }

        // DELETE INSTITUCIONI
        public async Task<InstitucioniDTO?> DeleteAsync(Guid id)
        {
            var deletedInstitucioni = await _institucioniRepository.DeleteAsync(id);
            return _mapper.Map<InstitucioniDTO>(deletedInstitucioni); // Mapping to DTO
        }

        // GET INSTITUCIONI BY NAME
        public async Task<InstitucioniDTO?> GetByNameAsync(string name)
        {
            var institucioni = await _institucioniRepository.GetByNameAsync(name);
            return _mapper.Map<InstitucioniDTO>(institucioni);
        }
    }
}
