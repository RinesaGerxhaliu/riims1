using AutoMapper;
using Microsoft.AspNetCore.Http;
using RIIMS.Application.DTOs.LicensatDTOs;
using RIIMS.Application.DTOs.ProjektiDTOs;
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
    public class ProjektiService : IProjektiService
    {
        private readonly IProjektiRepository _projektiRepository;
        private readonly IInstitucioniRepository _institucioniRepository;
        private readonly IMapper _mapper;

        public ProjektiService (IProjektiRepository     ProjektiRepository, IInstitucioniRepository institucioniRepository, IMapper mapper)
        {
            _projektiRepository = ProjektiRepository;
            _institucioniRepository = institucioniRepository;
            _mapper = mapper;
        } 

        public async Task<ProjektiDto> CreateAsync(string userId, AddProjektiRequestDto addProjekti)
        {
            var institution = await EnsureInstitutionExistsAsync(addProjekti.EmriInstitucionit);

            var projekti = _mapper.Map<Projekti>(addProjekti);
            projekti.UserId = userId;
            projekti.InstitucioniId = institution.Id;

            var createdProjekti = await _projektiRepository.CreateAsync(userId, projekti);

            return _mapper.Map<ProjektiDto>(createdProjekti);
        }

        public async Task<ProjektiDto?> DeleteAsync(Guid id)
        {
            var deletedProjekti = await _projektiRepository.DeleteAsync(id);
            return _mapper.Map<ProjektiDto>(deletedProjekti);
        }

        public async Task<List<ProjektiDto>> GetAllAsync(string userId)
        {
            var projektiList = await _projektiRepository.GetAllAsync(userId);
            return _mapper.Map<List<ProjektiDto>>(projektiList);
        }

        public async Task<ProjektiDto?> GetByIdAsync(Guid id)
        {
            var projekti = await _projektiRepository.GetByIdAsync(id);
            return _mapper.Map<ProjektiDto>(projekti);
        }

        public async Task<ProjektiDto?> UpdateAsync(Guid id, UpdateProjektiRequestDto updateProjekti)
        {
            var institution = await EnsureInstitutionExistsAsync(updateProjekti.EmriInstitucionit);

            var projekti = await _projektiRepository.GetByIdAsync(id);
            if (projekti == null) return null;

            _mapper.Map(updateProjekti, projekti);
            projekti.InstitucioniId = institution.Id;

            var updatedProjekti = await _projektiRepository.UpdateAsync(id, projekti);
            return _mapper.Map<ProjektiDto>(updatedProjekti);
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
