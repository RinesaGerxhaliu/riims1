using AutoMapper;
using Microsoft.AspNetCore.Http;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.UserGjuhetDTOs;
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
    public class UserGjuhetService : IUserGjuhetService
    {
        private readonly IUserGjuhetRepository _userGjuhetRepository;
        private readonly IGjuhetRepository _gjuhetRepository;
        private readonly INiveliGjuhesorRepository _niveliGjuhesorRepository;
        private readonly IMapper _mapper;

        public UserGjuhetService (IUserGjuhetRepository userGjuhetRepository, IGjuhetRepository gjuhetRepository, INiveliGjuhesorRepository niveliGjuhesorRepository, IMapper mapper)
        {
            _userGjuhetRepository = userGjuhetRepository;
            _gjuhetRepository = gjuhetRepository;
            _niveliGjuhesorRepository = niveliGjuhesorRepository;
            _mapper = mapper;
        }

        public async Task<UserGjuhetDTO> CreateAsync(int userId, AddUserGjuhetRequestDTO add)
        {
            var niveli = await EnsureNiveliExistsAsync(add.NiveliGjuhesor);
            var gjuha = await EnsureGjuhaExistsAsync(add.EmriGjuhes);

            var userGjuhet = _mapper.Map<UserGjuhet>(add);
            userGjuhet.UserId = userId;
            userGjuhet.NiveliGjuhesorId = niveli.Id;
            userGjuhet.GjuhaId = gjuha.Id;

            var createdGjuha = await _userGjuhetRepository.CreateAsync(userId, userGjuhet);

            return _mapper.Map<UserGjuhetDTO>(createdGjuha);
        }

        public async Task<UserGjuhetDTO?> DeleteAsync(Guid id)
        {
            var deletedGjuha = await _userGjuhetRepository.DeleteAsync(id);
            return _mapper.Map<UserGjuhetDTO>(deletedGjuha);
        }

        public async Task<List<UserGjuhetDTO>> GetAllAsync(int userId)
        {
            var userGjuhetList = await _userGjuhetRepository.GetAllAsync(userId);
            return _mapper.Map<List<UserGjuhetDTO>>(userGjuhetList);
        }

        public async Task<UserGjuhetDTO?> GetByIdAsync(Guid id)
        {
            var userGjuhet = await _userGjuhetRepository.GetByIdAsync(id);
            return _mapper.Map<UserGjuhetDTO>(userGjuhet);
        }

        public async Task<UserGjuhetDTO?> UpdateAsync(Guid id, UpdateUserGjuhetRequestDTO update)
        {
            var niveli = await EnsureNiveliExistsAsync(update.NiveliGjuhesor);
            var gjuha = await EnsureGjuhaExistsAsync(update.EmriGjuhes);

            var userGjuhet = await _userGjuhetRepository.GetByIdAsync(id);
            if (userGjuhet == null) return null;

            _mapper.Map(update, userGjuhet);
            userGjuhet.NiveliGjuhesorId = niveli.Id;
            userGjuhet.GjuhaId = gjuha.Id;

            var updatedGjuha = await _userGjuhetRepository.UpdateAsync(id, userGjuhet);
            return _mapper.Map<UserGjuhetDTO>(updatedGjuha);
        }

        private async Task<NiveliGjuhesor> EnsureNiveliExistsAsync(string niveliName)
        {
            var niveli = await _niveliGjuhesorRepository.GetByNameAsync(niveliName);
            if (niveli == null)
            {
                niveli = new NiveliGjuhesor
                {
                    Id = Guid.NewGuid(),
                    Niveli = niveliName
                };
                niveli = await _niveliGjuhesorRepository.CreateAsync(niveli);
            }
            return niveli;
        }

        private async Task<Gjuhet> EnsureGjuhaExistsAsync(string gjuhaName)
        {
            var gjuha = await _gjuhetRepository.GetByNameAsync(gjuhaName);
            if (gjuha == null)
            {
                gjuha = new Gjuhet
                {
                    Id = Guid.NewGuid(),
                    EmriGjuhes = gjuhaName
                };
                gjuha = await _gjuhetRepository.CreateAsync(gjuha);
            }
            return gjuha;
        }

        // EXTRACT USER ID FROM HTTPCONTEXT
        public string? GetUserIdFromContext(HttpContext context)
        {
            var userIdClaim = context.User?.FindFirst(ClaimTypes.NameIdentifier);
            return userIdClaim?.Value;
        }
    }
}
