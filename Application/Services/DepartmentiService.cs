using AutoMapper;
using Microsoft.AspNetCore.Http;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.DepartamentiDTOs;
using RIIMS.Application.DTOs.InstitucioniDTOs;
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
    public class DepartmentiService : IDepartmentiService
    {
        private readonly IDepartmentiRepository _departmentiRepository;
        private readonly IInstitucioniRepository _institucioniRepository;
        private readonly IMapper _mapper;

        public DepartmentiService(IDepartmentiRepository departmentiRepository, IInstitucioniRepository institucioniRepository, IMapper mapper)
        {
            _departmentiRepository = departmentiRepository;
            _institucioniRepository = institucioniRepository;
            _mapper = mapper;
        }

        public async Task<List<DepartamentiDto>> GetAllAsync()
        {
            var aftesiteList = await _departmentiRepository.GetAllAsync();
            return _mapper.Map<List<DepartamentiDto>>(aftesiteList);
        }

        public async Task<DepartamentiDto?> GetByIdAsync(Guid id)
        {
            var aftesite = await _departmentiRepository.GetByIdAsync(id);
            return _mapper.Map<DepartamentiDto>(aftesite);
        }

        public async Task<DepartamentiDto> CreateAsync(AddDepartamentiRequestDto addDepartamenti)
        {
            var institution = await EnsureInstitutionExistsAsync(addDepartamenti.EmriInstitucionit);

            var aftesite = _mapper.Map<Departamenti>(addDepartamenti);
            aftesite.InstitucioniId = institution.Id;

            var createdAftesite = await _departmentiRepository.CreateAsync(aftesite);

            return _mapper.Map<DepartamentiDto>(createdAftesite);
        }

        public async Task<DepartamentiDto?> UpdateAsync(Guid id, UpdateDepartamentiRequestDto updateDepartamenti)
        {
            var institution = await EnsureInstitutionExistsAsync(updateDepartamenti.EmriInstitucionit);

            var aftesite = await _departmentiRepository.GetByIdAsync(id);
            if (aftesite == null) return null;

            _mapper.Map(updateDepartamenti, aftesite);
            aftesite.InstitucioniId = institution.Id;

            var updatedAftesite = await _departmentiRepository.UpdateAsync(id, aftesite);
            return _mapper.Map<DepartamentiDto>(updatedAftesite);
        }

        public async Task<DepartamentiDto?> DeleteAsync(Guid id)
        {
            var deletedAftesite = await _departmentiRepository.DeleteAsync(id);
            return _mapper.Map<DepartamentiDto>(deletedAftesite);
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

        public async Task<DepartamentiDto?> GetByNameAsync(string name)
        {
            var institucioni = await _institucioniRepository.GetByNameAsync(name);
            return _mapper.Map<DepartamentiDto>(institucioni);
        }

        // EXTRACT USER ID FROM HTTPCONTEXT
        public string? GetUserIdFromContext(HttpContext context)
        {
            var userIdClaim = context.User?.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim?.Value;
        }
    }
}
