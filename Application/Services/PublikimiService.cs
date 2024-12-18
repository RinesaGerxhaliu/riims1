using AutoMapper;
using Microsoft.AspNetCore.Http;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.PublikimiDTOs;
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
    public class PublikimiService : IPublikimiService
    {
        private readonly IPublikimiRepository _publikimiRepository;
        private readonly IDepartmentiRepository _departmentiRepository;
        private readonly IMapper _mapper;

        public PublikimiService(IPublikimiRepository publikimiRepository, IDepartmentiRepository departmentiRepository, IMapper mapper)
        {
            _publikimiRepository = publikimiRepository;
            _departmentiRepository = departmentiRepository;
            _mapper = mapper;
        }

        public async Task<List<PublikimiDTO>> GetAllAsync(int userId)
        {
            var aftesiteList = await _publikimiRepository.GetAllAsync(userId);
            return _mapper.Map<List<PublikimiDTO>>(aftesiteList);
        }

        public async Task<PublikimiDTO?> GetByIdAsync(Guid id)
        {
            var aftesite = await _publikimiRepository.GetByIdAsync(id);
            return _mapper.Map<PublikimiDTO>(aftesite);
        }

        public async Task<PublikimiDTO> CreateAsync(int userId, AddPublikimiRequestDTO addPublikimi)
        {
            var institution = await EnsureInstitutionExistsAsync(addPublikimi.EmriDepartamentit);

            var aftesite = _mapper.Map<Publikimi>(addPublikimi);
            aftesite.UserId = userId;
            aftesite.DepartamentiId = institution.Id;

            var createdAftesite = await _publikimiRepository.CreateAsync(userId, aftesite);

            return _mapper.Map<PublikimiDTO>(createdAftesite);
        }
        public async Task<PublikimiDTO?> UpdateAsync(Guid id, UpdatePublikimiRequestDTO updatePublikimi)
        {
            var institution = await EnsureInstitutionExistsAsync(updatePublikimi.EmriDepartamentit);

            var aftesite = await _publikimiRepository.GetByIdAsync(id);
            if (aftesite == null) return null;

            _mapper.Map(updatePublikimi, aftesite);
            aftesite.DepartamentiId = institution.Id;

            var updatedAftesite = await _publikimiRepository.UpdateAsync(id, aftesite);
            return _mapper.Map<PublikimiDTO>(updatedAftesite);
        }

        public async Task<PublikimiDTO?> DeleteAsync(Guid id)
        {
            var deletedAftesite = await _publikimiRepository.DeleteAsync(id);
            return _mapper.Map<PublikimiDTO>(deletedAftesite);
        }

        // ENSURE Department EXISTENCE
        private async Task<Departamenti> EnsureInstitutionExistsAsync(string institutionName)
        {
            var institution = await _departmentiRepository.GetByNameAsync(institutionName);
            if (institution == null)
            {
                institution = new Departamenti
                {
                    Id = Guid.NewGuid(),
                    Emri = institutionName
                };
                institution = await _departmentiRepository.CreateAsync(institution);
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
