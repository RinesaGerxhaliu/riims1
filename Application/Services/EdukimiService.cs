using AutoMapper;
using Microsoft.AspNetCore.Http;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.EdukimiDTOs;
using RIIMS.Application.Interfaces;
using RIIMS.Domain.Entities;
using RIIMS.Domain.Interfaces;
using RIIMSAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Services
{
    public class EdukimiService : IEdukimiService
    {
        private readonly IEdukimiRepository _edukimiRepository;
        private readonly IInstitucioniRepository _institucioniRepository;
        private readonly INiveliAkademikRepository _niveliAkademikRepository;
        private readonly IMapper _mapper;

        public EdukimiService(IEdukimiRepository edukimiRepository, 
            IInstitucioniRepository institucioniRepository, 
            INiveliAkademikRepository niveliAkademikRepository,
            IMapper mapper)
        {
            _edukimiRepository = edukimiRepository;
            _institucioniRepository = institucioniRepository;
            _niveliAkademikRepository = niveliAkademikRepository;
            _mapper = mapper;
        }

        // Get ALL EDUKIMET
        public async Task<List<EdukimiDTO>> GetAllAsync(string userId)
        {
            var edukimetList = await _edukimiRepository.GetAllAsync(userId);
            return _mapper.Map<List<EdukimiDTO>>(edukimetList);
        }

        // GET EDUKIMI BY ID
        public async Task<EdukimiDTO?> GetByIdAsync(Guid id)
        {
            var edukimet = await _edukimiRepository.GetByIdAsync(id);
            return _mapper.Map<EdukimiDTO>(edukimet);
        }

        // CREATE EDUKIMI
        public async Task<EdukimiDTO> CreateAsync(string userId, AddEdukimiRequestDTO addEdukimi)
        {
            var institution = await EnsureInstitutionExistsAsync(addEdukimi.Institucioni);
            var niveli = await EnsureNiveliExistsAsync(addEdukimi.NiveliAkademik);

            var edukimi = _mapper.Map<Edukimi>(addEdukimi);
            edukimi.UserId = userId;
            edukimi.InstitucioniId = institution.Id;
            edukimi.NiveliAkademikId = niveli.Id;

            var createdEdukimi = await _edukimiRepository.CreateAsync(userId, edukimi);

            return _mapper.Map<EdukimiDTO>(createdEdukimi);
        }

        // UPDATE EDUKIMI BY ID
        public async Task<EdukimiDTO?> UpdateAsync(Guid id, UpdateEdukimiRequestDTO updateEdukimi)
        {
            var institution = await EnsureInstitutionExistsAsync(updateEdukimi.Institucioni);
            var niveli = await EnsureNiveliExistsAsync(updateEdukimi.NiveliAkademik);

            var edukimi = await _edukimiRepository.GetByIdAsync(id);
            if (edukimi == null) return null;

            _mapper.Map(updateEdukimi, edukimi);
            edukimi.InstitucioniId = institution.Id;
            edukimi.NiveliAkademikId = niveli.Id;

            var updatedEdukimi = await _edukimiRepository.UpdateAsync(id, edukimi);
            return _mapper.Map<EdukimiDTO>(updatedEdukimi);
        }

        // DELETE EDUKIMI BY ID
        public async Task<EdukimiDTO?> DeleteAsync(Guid id)
        {
            var deletedEdukimi = await _edukimiRepository.DeleteAsync(id);
            return _mapper.Map<EdukimiDTO>(deletedEdukimi);
        }

        // ENSURE INSTITUTION EXISTENCE
        private async Task<Institucioni> EnsureInstitutionExistsAsync(string institutionName)
        {
            var institution = await _institucioniRepository.GetByNameAsync(institutionName);
            if (institution == null)
            {
                institution = new Institucioni
                {
                    Id = Guid.NewGuid(),
                    Emri = institutionName
                };
                institution = await _institucioniRepository.CreateAsync(institution);
            }
            return institution;
        }

        // ENSURE NIVELI EXISTS
        private async Task<NiveliAkademik> EnsureNiveliExistsAsync(string level)
        {
            var niveli = await _niveliAkademikRepository.GetByNameAsync(level);
            if (niveli == null)
            {
                niveli = new NiveliAkademik
                {
                    Id = Guid.NewGuid(),
                    lvl = level
                };
                niveli = await _niveliAkademikRepository.CreateAsync(niveli);
            }
            return niveli;
        }
    }
}
