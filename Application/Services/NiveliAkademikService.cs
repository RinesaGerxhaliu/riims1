using AutoMapper;
using RIIMS.Application.DTOs.InstitucioniDTOs;
using RIIMS.Application.DTOs.NiveliAkademikDTOs;
using RIIMS.Application.Interfaces;
using RIIMS.Domain.Entities;
using RIIMS.Domain.Interfaces;
using RIIMSAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Services
{
    public class NiveliAkademikService : INiveliAkademikService
    {
        private readonly INiveliAkademikRepository _niveliAkademikRepository;
        private readonly IMapper _mapper;

        public NiveliAkademikService(INiveliAkademikRepository niveliAkademikRepository, IMapper mapper)
        {
            _niveliAkademikRepository = niveliAkademikRepository;
            _mapper = mapper;
        }

        // GET ALL INSTITUCIONET
        public async Task<List<NiveliAkademikDto>> GetAllAsync()
        {
            var institucioniList = await _niveliAkademikRepository.GetAllAsync();
            return _mapper.Map<List<NiveliAkademikDto>>(institucioniList);
        }

        // GET INSTITUCIONI BY ID
        public async Task<NiveliAkademikDto?> GetByIdAsync(Guid id)
        {
            var institucioni = await _niveliAkademikRepository.GetByIdAsync(id);
            return _mapper.Map<NiveliAkademikDto>(institucioni);
        }

        // CREATE INSTITUCIONI
        public async Task<NiveliAkademikDto> CreateAsync(AddNiveliAkademikRequestDto addNiveliAkademik)
        {
            var institucioni = _mapper.Map<NiveliAkademik>(addNiveliAkademik);
            var createdInstitucioni = await _niveliAkademikRepository.CreateAsync(institucioni);

            return _mapper.Map<NiveliAkademikDto>(createdInstitucioni);
        }

        // UPDATE INSTITUCIONI
        public async Task<NiveliAkademikDto?> UpdateAsync(Guid id, UpdateNiveliAkademikRequestDto updateNiveliAkademik)
        {
            var institucioni = _mapper.Map<NiveliAkademik>(updateNiveliAkademik);
            var updatedInstitucioni = await _niveliAkademikRepository.UpdateAsync(id, institucioni);

            return _mapper.Map<NiveliAkademikDto>(updatedInstitucioni);
        }

        // DELETE INSTITUCIONI
        public async Task<NiveliAkademikDto?> DeleteAsync(Guid id)
        {
            var deletedInstitucioni = await _niveliAkademikRepository.DeleteAsync(id);
            return _mapper.Map<NiveliAkademikDto>(deletedInstitucioni); // Mapping to DTO
        }

        // GET INSTITUCIONI BY NAME
        public async Task<NiveliAkademikDto?> GetByNameAsync(string lvl)
        {
            var institucioni = await _niveliAkademikRepository.GetByNameAsync(lvl);
            return _mapper.Map<NiveliAkademikDto>(institucioni);
        }
    }
}
