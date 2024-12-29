using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.PublikimiDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Interfaces
{
    public interface IPublikimiService
    {
        Task<List<PublikimiDTO>> GetAllAsync(string userId);
        Task<PublikimiDTO?> GetByIdAsync(Guid id);
        Task<PublikimiDTO> CreateAsync(string userId, AddPublikimiRequestDTO addPublikimi);
        Task<PublikimiDTO?> UpdateAsync(Guid id, UpdatePublikimiRequestDTO updatePublikimi);
        Task<PublikimiDTO?> DeleteAsync(Guid id);
    }
}
