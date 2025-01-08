using AutoMapper;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.HonorsAndAwardsDTOs;
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
    public class HonorsAndAwardsService : IHonorsAndAwardsService
    {
        private readonly IHonorsAndAwardsRepository _honorsAndAwardsRepository;
        private readonly IInstitucioniRepository _institucioniRepository;
        private readonly IMapper _mapper;

        public HonorsAndAwardsService(IHonorsAndAwardsRepository honorsAndAwardsRepository, IInstitucioniRepository institucioniRepository, IMapper mapper)
        {
            _honorsAndAwardsRepository = honorsAndAwardsRepository;
            _institucioniRepository = institucioniRepository;
            _mapper = mapper;
        }

        // Get ALL HONORS&AWARDS
        public async Task<List<HonorsAndAwardsDTO>> GetAllAsync(string userId)
        {
            var honorsAndAwardsList = await _honorsAndAwardsRepository.GetAllAsync(userId);
            return _mapper.Map<List<HonorsAndAwardsDTO>>(honorsAndAwardsList);
        }

        // GET HONORS&AWARDS BY ID
        public async Task<HonorsAndAwardsDTO?> GetByIdAsync(Guid id)
        {
            var honorsAndAwards = await _honorsAndAwardsRepository.GetByIdAsync(id);
            return _mapper.Map<HonorsAndAwardsDTO>(honorsAndAwards);
        }

        // CREATE HONORS&AWARDS
        public async Task<HonorsAndAwardsDTO> CreateAsync(string userId, AddHonorsAndAwardsRequestDTO addHonorsAndAwards)
        {
            var institution = await EnsureInstitutionExistsAsync(addHonorsAndAwards.EmriInstitucionit);

            var honorsAndAwards = _mapper.Map<HonorsAndAwards>(addHonorsAndAwards);
            honorsAndAwards.UserId = userId;
            honorsAndAwards.InstitucioniId = institution.Id;

            var createdHonorsAndAwards = await _honorsAndAwardsRepository.CreateAsync(userId, honorsAndAwards);

            return _mapper.Map<HonorsAndAwardsDTO>(createdHonorsAndAwards);
        }

        // UPDATE HONORS&AWARDS BY ID
        public async Task<HonorsAndAwardsDTO?> UpdateAsync(Guid id, UpdateHonorsAndAwardsRequestDTO updateHonorsRequest)
        {
            var institution = await EnsureInstitutionExistsAsync(updateHonorsRequest.EmriInstitucionit);

            var honorsAndAwards = await _honorsAndAwardsRepository.GetByIdAsync(id);
            if (honorsAndAwards == null) return null;

            _mapper.Map(updateHonorsRequest, honorsAndAwards);
            honorsAndAwards.InstitucioniId = institution.Id;

            var updatedHonorsAndAwards = await _honorsAndAwardsRepository.UpdateAsync(id, honorsAndAwards);
            return _mapper.Map<HonorsAndAwardsDTO>(updatedHonorsAndAwards);
        }

        // DELETE HONORS&AWARDS BY ID
        public async Task<HonorsAndAwardsDTO?> DeleteAsync(Guid id)
        {
            var deletedHonorsAndAwards = await _honorsAndAwardsRepository.DeleteAsync(id);
            return _mapper.Map<HonorsAndAwardsDTO>(deletedHonorsAndAwards);
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
