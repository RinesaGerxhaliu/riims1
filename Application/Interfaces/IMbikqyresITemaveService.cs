using RIIMS.Application.DTOs.MbikqyresITemaveDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Interfaces
{
    public interface IMbikqyresITemaveService
    {
        Task<List<MbikqyresITemaveDTO>> GetAllAsync(string userId);
        Task<MbikqyresITemaveDTO?> GetByIdAsync(Guid id);
        Task<MbikqyresITemaveDTO> CreateAsync(string userId, AddMbikqyresRequestDTO add);
        Task<MbikqyresITemaveDTO?> UpdateAsync(Guid id, UpdateMbikqyresRequestDTO update);
        Task<MbikqyresITemaveDTO?> DeleteAsync(Guid id);
    }
}
