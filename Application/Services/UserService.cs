using AutoMapper;
using Microsoft.AspNetCore.Http;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.UserDTOs;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly INiveliAkademikRepository _niveliAkademikRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, INiveliAkademikRepository niveliAkademikRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _niveliAkademikRepository = niveliAkademikRepository;
            _mapper = mapper;
        }

        // Get ALL USERS
        public async Task<List<UserDTO>> GetAllAsync()
        {
            var userList = await _userRepository.GetAllAsync();
            return _mapper.Map<List<UserDTO>>(userList);
        }

        // GET USER BY ID
        public async Task<UserDTO?> GetByIdAsync(string id)  
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserDTO>(user);
        }


        // UPDATE USER BY ID
        public async Task<UserDTO?> UpdateAsync(string id, UpdateUserRequestDTO updateUser)
        {
            var institution = await EnsureNiveliExistsAsync(updateUser.NiveliAkademik);

            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            _mapper.Map(updateUser, user);
            user.NiveliAkademikId = institution.Id;

            var updatedUser = await _userRepository.UpdateAsync(id, user);
            return _mapper.Map<UserDTO>(updatedUser);
        }

        // DELETE USER BY ID
        public async Task<UserDTO?> DeleteAsync(string id)  
        {
            var deletedUser = await _userRepository.DeleteAsync(id);
            return _mapper.Map<UserDTO>(deletedUser);
        }

        // ENSURE NIVELI EXISTS
        private async Task<NiveliAkademik> EnsureNiveliExistsAsync(string level)
        {
            var niveli = await _niveliAkademikRepository.GetByNameAsync(level);
            if (niveli == null)
            {
                niveli = new NiveliAkademik
                {
                    Id = Guid.NewGuid(),
                    lvl = level
                };
                niveli = await _niveliAkademikRepository.CreateAsync(niveli);
            }
            return niveli;
        }
    }
}
