using AutoMapper;
using RIIMS.Application.DTOs.EksperiencaDTOs;
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
    public class EksperiencaService : IEksperiencaService
    {
        private readonly IEksperiencaRepository _eksperiencaRepository;
        private readonly IInstitucioniRepository _institucioniRepository;
        private readonly IMapper _mapper;

        public EksperiencaService(IEksperiencaRepository eksperiencaRepository, 
            IInstitucioniRepository institucioniRepository, 
            IMapper mapper)
        {
            _eksperiencaRepository = eksperiencaRepository;
            _institucioniRepository = institucioniRepository;
            _mapper = mapper;
        }

        // GET ALL EKSPERIENCAT
        public async Task<List<EksperiencaDTO>> GetAllAsync(string userId)
        {
            var eksperiencatList = await _eksperiencaRepository.GetAllAsync(userId);
            return _mapper.Map<List<EksperiencaDTO>>(eksperiencatList);
        }

        // GET EKSPERIENCA BY ID
        public async Task<EksperiencaDTO?> GetByIdAsync(Guid id)
        {
            var eksperienca = await _eksperiencaRepository.GetByIdAsync(id);
            return _mapper.Map<EksperiencaDTO>(eksperienca);
        }

        // CREATE EKSPERIENCA
        public async Task<EksperiencaDTO> CreateAsync(string userId, AddEksperiencaRequestDTO addEksperienca)
        {
            var institution = await EnsureInstitutionExistsAsync(addEksperienca.EmriInstitucionit);

            var eksperienca = _mapper.Map<Eksperienca>(addEksperienca);
            eksperienca.UserId = userId;
            eksperienca.InstitucioniId = institution.Id;

            var createdEksperienca = await _eksperiencaRepository.CreateAsync(userId, eksperienca);

            return _mapper.Map<EksperiencaDTO>(createdEksperienca);
        }

        // UPDATE EKSPERIENCA BY ID
        public async Task<EksperiencaDTO?> UpdateAsync(Guid id, UpdateEksperiencaRequestDTO updateEksperiencaRequest)
        {
            var institution = await EnsureInstitutionExistsAsync(updateEksperiencaRequest.EmriInstitucionit);

            var updatedEksperienca = await _eksperiencaRepository.GetByIdAsync(id);
            if (updatedEksperienca == null) return null;

            _mapper.Map(updateEksperiencaRequest, updatedEksperienca);
            updatedEksperienca.InstitucioniId = institution.Id;

            var updatedAftesite = await _eksperiencaRepository.UpdateAsync(id, updatedEksperienca);
            return _mapper.Map<EksperiencaDTO>(updatedEksperienca);
        }

        // DELETE EKSPERIENCA BY ID
        public async Task<EksperiencaDTO?> DeleteAsync(Guid id)
        {
            var deletedEksperienca = await _eksperiencaRepository.DeleteAsync(id);
            return _mapper.Map<EksperiencaDTO>(deletedEksperienca);
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
    }
}
