using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.SpecializimiDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Interfaces
{
    public interface ISpecializimiService
    {
        Task<List<SpecializimetDTO>> GetAllAsync(int userId);
        Task<SpecializimetDTO?> GetByIdAsync(Guid id);
        Task<SpecializimetDTO> CreateAsync(int userId, AddSpecializimetRequestDTO addSpecializimet);
        Task<SpecializimetDTO?> UpdateAsync(Guid id, UpdateSpecializimetRequestDTO updateSpecializimetRequest);
        Task<SpecializimetDTO?> DeleteAsync(Guid id);
    }
}
