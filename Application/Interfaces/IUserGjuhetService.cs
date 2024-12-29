using RIIMS.Application.DTOs.UserGjuhetDTOs;
using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Interfaces
{
    public interface IUserGjuhetService
    {
        Task<List<UserGjuhetDTO>> GetAllAsync(string userId);
        Task<UserGjuhetDTO?> GetByIdAsync(Guid id);
        Task<UserGjuhetDTO> CreateAsync(string userId, AddUserGjuhetRequestDTO add);
        Task<UserGjuhetDTO?> UpdateAsync(Guid id, UpdateUserGjuhetRequestDTO update);
        Task<UserGjuhetDTO?> DeleteAsync(Guid id);
    }
}
