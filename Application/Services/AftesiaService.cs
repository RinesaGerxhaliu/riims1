using Application.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Domain.Entities;
using RIIMSAPI.Domain.Interfaces;
using System.Security.Claims;

namespace RIIMS.Application.Services
{
    public class AftesiaService : IAftesiaService
    {
        private readonly IAftesiaRepository _aftesiaRepository;
        private readonly IInstitucioniRepository _institucioniRepository;
        private readonly IMapper _mapper;

        public AftesiaService(IAftesiaRepository aftesiaRepository, IInstitucioniRepository institucioniRepository, IMapper mapper)
        {
            _aftesiaRepository = aftesiaRepository;
            _institucioniRepository = institucioniRepository;
            _mapper = mapper;
        }

        // Get ALL AFTESITE
        public async Task<List<AftesiaDTO>> GetAllAsync(string userId)
        {
            var aftesiteList = await _aftesiaRepository.GetAllAsync(userId);
            return _mapper.Map<List<AftesiaDTO>>(aftesiteList); 
        }

        // GET AFTESIA BY ID
        public async Task<AftesiaDTO?> GetByIdAsync(Guid id)
        {
            var aftesite = await _aftesiaRepository.GetByIdAsync(id);
            return _mapper.Map<AftesiaDTO>(aftesite); 
        }

        // CREATE AFTESIA
        public async Task<AftesiaDTO> CreateAsync(string userId, AddAftesiaRequestDTO addAftesia)
        {
            var institution = await EnsureInstitutionExistsAsync(addAftesia.EmriInstitucionit);

            var aftesite = _mapper.Map<Aftesite>(addAftesia);
            aftesite.UserId = userId;
            aftesite.InstitucioniId = institution.Id;

            var createdAftesite = await _aftesiaRepository.CreateAsync(userId, aftesite);

            return _mapper.Map<AftesiaDTO>(createdAftesite);
        }

        // UPDATE AFTESIA BY ID
        public async Task<AftesiaDTO?> UpdateAsync(Guid id, UpdateAftesiaRequestDTO updateAftesiaRequest)
        {
            var institution = await EnsureInstitutionExistsAsync(updateAftesiaRequest.EmriInstitucionit);

            var aftesite = await _aftesiaRepository.GetByIdAsync(id);
            if (aftesite == null) return null;

            _mapper.Map(updateAftesiaRequest, aftesite);
            aftesite.InstitucioniId = institution.Id;

            var updatedAftesite = await _aftesiaRepository.UpdateAsync(id, aftesite);
            return _mapper.Map<AftesiaDTO>(updatedAftesite);
        }

        // DELETE AFTESIA BY ID
        public async Task<AftesiaDTO?> DeleteAsync(Guid id)
        {
            var deletedAftesite = await _aftesiaRepository.DeleteAsync(id);
            return _mapper.Map<AftesiaDTO>(deletedAftesite);
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

        // EXTRACT USER ID FROM HTTPCONTEXT
        public string? GetUserIdFromContext(HttpContext context)
        {
            var userIdClaim = context.User?.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim?.Value;
        }
    }
}

