using AutoMapper;
using Microsoft.AspNetCore.Http;
using RIIMS.Application.DTOs.LicensatDTOs;
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
    public class LicensaService : ILicensaService
    {
        private readonly ILicensaRepository _licensaRepository;
        private readonly IInstitucioniRepository _institucioniRepository;
        private readonly IMapper _mapper;

        public LicensaService(ILicensaRepository LicensaRepository, IInstitucioniRepository institucioniRepository, IMapper mapper)
        {
            _licensaRepository = LicensaRepository;
            _institucioniRepository = institucioniRepository;
            _mapper = mapper;
        }
        public async Task<LicensatDto> CreateAsync(string userId, AddLicensatRequestDto addLicensat)
        {
            var institution = await EnsureInstitutionExistsAsync(addLicensat.EmriInstitucionit);

            var licensat = _mapper.Map<Licensat>(addLicensat);
            licensat.UserId = userId;
            licensat.InstitucioniId = institution.Id;

            var createdLicensa = await _licensaRepository.CreateAsync(userId, licensat);

            return _mapper.Map<LicensatDto>(createdLicensa);
        }

        public async Task<LicensatDto?> DeleteAsync(Guid id)
        {
            var deletedLicensa = await _licensaRepository.DeleteAsync(id);
            return _mapper.Map<LicensatDto>(deletedLicensa);
        }

        public async Task<List<LicensatDto>> GetAllAsync(string userId)
        {
            var licensatList = await _licensaRepository.GetAllAsync(userId);
            return _mapper.Map<List<LicensatDto>>(licensatList);
        }

        public async Task<LicensatDto?> GetByIdAsync(Guid id)
        {
            var licensat = await _licensaRepository.GetByIdAsync(id);
            return _mapper.Map<LicensatDto>(licensat);
        }

        public async Task<LicensatDto?> UpdateAsync(Guid id, UpdateLicensatRequestDto updateLicensat)
        {
            var institution = await EnsureInstitutionExistsAsync(updateLicensat.EmriInstitucionit);

            var licensa = await _licensaRepository.GetByIdAsync(id);
            if (licensa == null) return null;

            _mapper.Map(updateLicensat, licensa);
            licensa.InstitucioniId = institution.Id;

            var updatedLicensa = await _licensaRepository.UpdateAsync(id, licensa);
            return _mapper.Map<LicensatDto>(updatedLicensa);
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
