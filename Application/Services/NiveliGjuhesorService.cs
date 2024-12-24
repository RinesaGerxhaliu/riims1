using AutoMapper;
using RIIMS.Application.DTOs.NiveliAkademikDTOs;
using RIIMS.Application.DTOs.NiveliGjuhesorDTOs;
using RIIMS.Application.Interfaces;
using RIIMS.Domain.Entities;
using RIIMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Services
{
    public class NiveliGjuhesorService : INiveliGjuhesorService
    {
        private readonly INiveliGjuhesorRepository _niveliGjuhesorRepository;
        private readonly IMapper _mapper;

        public NiveliGjuhesorService(INiveliGjuhesorRepository niveliGjuhesorRepository, IMapper mapper)
        {
            _niveliGjuhesorRepository = niveliGjuhesorRepository;
            _mapper = mapper;
        }
        public async Task<NiveliGjuhesorDTO> CreateAsync(AddNiveliGjuhesorRequestDTO add)
        {
            var niveli = _mapper.Map<NiveliGjuhesor>(add);
            var createdNiveli = await _niveliGjuhesorRepository.CreateAsync(niveli);

            return _mapper.Map<NiveliGjuhesorDTO>(createdNiveli);
        }

        public async Task<NiveliGjuhesorDTO?> DeleteAsync(Guid id)
        {
            var deletedNiveli = await _niveliGjuhesorRepository.DeleteAsync(id);
            return _mapper.Map<NiveliGjuhesorDTO>(deletedNiveli);
        }

        public async Task<List<NiveliGjuhesorDTO>> GetAllAsync()
        {
            var niveliList = await _niveliGjuhesorRepository.GetAllAsync();
            return _mapper.Map<List<NiveliGjuhesorDTO>>(niveliList);
        }

        public async Task<NiveliGjuhesorDTO?> GetByIdAsync(Guid id)
        {
            var niveli = await _niveliGjuhesorRepository.GetByIdAsync(id);
            return _mapper.Map<NiveliGjuhesorDTO>(niveli);
        }

        public async Task<NiveliGjuhesorDTO?> GetByNameAsync(string lvl)
        {
            var niveli = await _niveliGjuhesorRepository.GetByNameAsync(lvl);
            return _mapper.Map<NiveliGjuhesorDTO>(niveli);
        }

        public async Task<NiveliGjuhesorDTO?> UpdateAsync(Guid id, UpdateNiveliGjuhesorRequestDto update)
        {
            var niveli = _mapper.Map<NiveliGjuhesor>(update);
            var updatedNiveli = await _niveliGjuhesorRepository.UpdateAsync(id, niveli);

            return _mapper.Map<NiveliGjuhesorDTO>(updatedNiveli);
        }
    }
}
