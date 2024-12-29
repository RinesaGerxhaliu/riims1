using RIIMS.Application.DTOs.UserDTOs;
using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetAllAsync();
        Task<UserDTO?> GetByIdAsync(string userId);
        Task<UserDTO?> UpdateAsync(string userId, UpdateUserRequestDTO updateUserRequest);
        Task<UserDTO?> DeleteAsync(string userId);
    }
}
