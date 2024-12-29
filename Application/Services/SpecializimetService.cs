using AutoMapper;
using Microsoft.AspNetCore.Http;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.SpecializimiDTOs;
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
    public class SpecializimetService : ISpecializimiService
    {
        private readonly ISpecializimetRepository _specializimetRepository;
        private readonly IInstitucioniRepository _institucioniRepository;
        private readonly IMapper _mapper;

        public SpecializimetService(ISpecializimetRepository specializimetRepository, IInstitucioniRepository institucioniRepository, IMapper mapper)
        {
            _specializimetRepository = specializimetRepository;
            _institucioniRepository = institucioniRepository;
            _mapper = mapper;
        }

        public async Task<List<SpecializimetDTO>> GetAllAsync(string userId)
        {
            var aftesiteList = await _specializimetRepository.GetAllAsync(userId);
            return _mapper.Map<List<SpecializimetDTO>>(aftesiteList);
        }

        public async Task<SpecializimetDTO?> GetByIdAsync(Guid id)
        {
            var aftesite = await _specializimetRepository.GetByIdAsync(id);
            return _mapper.Map<SpecializimetDTO>(aftesite);
        }

        public async Task<SpecializimetDTO> CreateAsync(string userId, AddSpecializimetRequestDTO addSpecializimet)
        {
            var institution = await EnsureInstitutionExistsAsync(addSpecializimet.EmriInstitucionit);

            var aftesite = _mapper.Map<Specializimet>(addSpecializimet);
            aftesite.UserId = userId;
            aftesite.InstitucioniId = institution.Id;

            var createdAftesite = await _specializimetRepository.CreateAsync(userId, aftesite);

            return _mapper.Map<SpecializimetDTO>(createdAftesite);
        }

        public async Task<SpecializimetDTO?> UpdateAsync(Guid id, UpdateSpecializimetRequestDTO updateSpecializimetRequest)
        {
            var institution = await EnsureInstitutionExistsAsync(updateSpecializimetRequest.EmriInstitucionit);

            var aftesite = await _specializimetRepository.GetByIdAsync(id);
            if (aftesite == null) return null;

            _mapper.Map(updateSpecializimetRequest, aftesite);
            aftesite.InstitucioniId = institution.Id;

            var updatedAftesite = await _specializimetRepository.UpdateAsync(id, aftesite);
            return _mapper.Map<SpecializimetDTO>(updatedAftesite);
        }

        public async Task<SpecializimetDTO?> DeleteAsync(Guid id)
        {
            var deletedAftesite = await _specializimetRepository.DeleteAsync(id);
            return _mapper.Map<SpecializimetDTO>(deletedAftesite);
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
        public string? GetUserIdFromContext(HttpContext context)
        {
            var userIdClaim = context.User?.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim?.Value;
        }
    }
}
