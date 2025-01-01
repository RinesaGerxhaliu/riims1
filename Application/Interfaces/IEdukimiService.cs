using RIIMS.Application.DTOs.EdukimiDTOs;
using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Interfaces
{
    public interface IEdukimiService
    {
        Task<List<EdukimiDTO>> GetAllAsync(string userId);
        Task<EdukimiDTO?> GetByIdAsync(Guid id);
        Task<EdukimiDTO> CreateAsync(string userId, AddEdukimiRequestDTO edukimi);
        Task<EdukimiDTO?> UpdateAsync(Guid id, UpdateEdukimiRequestDTO edukimi);
        Task<EdukimiDTO?> DeleteAsync(Guid id);
    }
}
