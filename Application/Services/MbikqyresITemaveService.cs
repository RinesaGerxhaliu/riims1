using AutoMapper;
using Microsoft.AspNetCore.Http;
using RIIMS.Application.DTOs.MbikqyresITemaveDTOs;
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
    public class MbikqyresITemaveService : IMbikqyresITemaveService
    {
        private readonly IMbikqyresITemaveRepository _mbikqyresITemaveRepository;
        private readonly IDepartmentiRepository _departamentiRepository;
        private readonly IMapper _mapper;

        public MbikqyresITemaveService(IMbikqyresITemaveRepository MbikqyresITemaveRepository, IDepartmentiRepository DepartmentiRepository, IMapper mapper)
        {
            _mbikqyresITemaveRepository = MbikqyresITemaveRepository;
            _departamentiRepository = DepartmentiRepository;
            _mapper = mapper;
        } 

        public async Task<MbikqyresITemaveDTO> CreateAsync(int userId, AddMbikqyresRequestDTO add)
        {
            var departamenti = await EnsureDepartamentExistsAsync(add.EmriDepartamentit);

            var mbikqyres = _mapper.Map<MbikqyresITemave>(add);
            mbikqyres.UserId = userId;
            mbikqyres.DepartamentiId = departamenti.Id;

            var createdMbikqyres = await _mbikqyresITemaveRepository.CreateAsync(userId, mbikqyres);

            return _mapper.Map<MbikqyresITemaveDTO>(createdMbikqyres);

        }

        public async Task<MbikqyresITemaveDTO?> DeleteAsync(Guid id)
        {
            var deletedMbikqyres = await _mbikqyresITemaveRepository.DeleteAsync(id);
            return _mapper.Map<MbikqyresITemaveDTO>(deletedMbikqyres);
        }

        public async Task<List<MbikqyresITemaveDTO>> GetAllAsync(int userId)
        {
            var mbikqyresList = await _mbikqyresITemaveRepository.GetAllAsync(userId);
            return _mapper.Map<List<MbikqyresITemaveDTO>>(mbikqyresList);
        }

        public async Task<MbikqyresITemaveDTO?> GetByIdAsync(Guid id)
        {
            var mbikqyres = await _mbikqyresITemaveRepository.GetByIdAsync(id);
            return _mapper.Map<MbikqyresITemaveDTO>(mbikqyres);
        }

        public async Task<MbikqyresITemaveDTO?> UpdateAsync(Guid id, UpdateMbikqyresRequestDTO update)
        {
            var departamenti = await EnsureDepartamentExistsAsync(update.EmriDepartamentit);

            var mbikqyres = await _mbikqyresITemaveRepository.GetByIdAsync(id);
            if (mbikqyres == null) return null;

            _mapper.Map(update, mbikqyres);
            mbikqyres.DepartamentiId = departamenti.Id;

            var updatedMbikqyres = await _mbikqyresITemaveRepository.UpdateAsync(id, mbikqyres);
            return _mapper.Map<MbikqyresITemaveDTO>(updatedMbikqyres);
        }
        private async Task<Departamenti> EnsureDepartamentExistsAsync(string departamentName)
        {
            var departamenti = await _departamentiRepository.GetByNameAsync(departamentName);
            if (departamenti == null)
            {
                departamenti = new Departamenti
                {
                    Id = Guid.NewGuid(),
                    Emri = departamentName
                };
                departamenti = await _departamentiRepository.CreateAsync(departamenti);
            }
            return departamenti;
        }

        // EXTRACT USER ID FROM HTTPCONTEXT
        public string? GetUserIdFromContext(HttpContext context)
        {
            var userIdClaim = context.User?.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim?.Value;
        }
    }
}
