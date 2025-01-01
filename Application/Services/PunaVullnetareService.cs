using AutoMapper;
using Microsoft.AspNetCore.Http;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.PunaVullnetareDTOs;
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
    public class PunaVullnetareService : IPunaVullnetareService
    {
        private readonly IPunaVullnetareRepository _punaVullnetareRepository;
        private readonly IInstitucioniRepository _institucioniRepository;
        private readonly IMapper _mapper;

        public PunaVullnetareService(IPunaVullnetareRepository punaVullnetareRepository, IInstitucioniRepository institucioniRepository, IMapper mapper)
        {
            _punaVullnetareRepository = punaVullnetareRepository;
            _institucioniRepository = institucioniRepository;
            _mapper = mapper;
        }

        public async Task<List<PunaVullnetareDTO>> GetAllAsync(string userId)
        {
            var aftesiteList = await _punaVullnetareRepository.GetAllAsync(userId);
            return _mapper.Map<List<PunaVullnetareDTO>>(aftesiteList);
        }

        public async Task<PunaVullnetareDTO?> GetByIdAsync(Guid id)
        {
            var aftesite = await _punaVullnetareRepository.GetByIdAsync(id);
            return _mapper.Map<PunaVullnetareDTO>(aftesite);
        }

        public async Task<PunaVullnetareDTO> CreateAsync(string userId, AddPunaVullnetareRequestDTO addPunaVullnetare)
        {
            var institution = await EnsureInstitutionExistsAsync(addPunaVullnetare.EmriInstitucionit);

            var punaVullnetare = _mapper.Map<PunaVullnetare>(addPunaVullnetare);
            punaVullnetare.UserId = userId;
            punaVullnetare.InstitucioniId = institution.Id;

            var createdAftesite = await _punaVullnetareRepository.CreateAsync(userId, punaVullnetare);

            return _mapper.Map<PunaVullnetareDTO>(createdAftesite);
        }

        public async Task<PunaVullnetareDTO?> UpdateAsync(Guid id, UpdatePunaVullnetareRequestDTO updatePunaVullnetareRequest)
        {
            var institution = await EnsureInstitutionExistsAsync(updatePunaVullnetareRequest.EmriInstitucionit);

            var aftesite = await _punaVullnetareRepository.GetByIdAsync(id);
            if (aftesite == null) return null;

            _mapper.Map(updatePunaVullnetareRequest, aftesite);
            aftesite.InstitucioniId = institution.Id;

            var updatedAftesite = await _punaVullnetareRepository.UpdateAsync(id, aftesite);
            return _mapper.Map<PunaVullnetareDTO>(updatedAftesite);
        }

        public async Task<PunaVullnetareDTO?> DeleteAsync(Guid id)
        {
            var deletedAftesite = await _punaVullnetareRepository.DeleteAsync(id);
            return _mapper.Map<PunaVullnetareDTO>(deletedAftesite);
        }

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
