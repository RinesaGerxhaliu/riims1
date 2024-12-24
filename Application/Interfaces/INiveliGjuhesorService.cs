using RIIMS.Application.DTOs.NiveliGjuhesorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Interfaces
{
    public interface INiveliGjuhesorService
    {
        Task<List<NiveliGjuhesorDTO>> GetAllAsync();
        Task<NiveliGjuhesorDTO?> GetByIdAsync(Guid id);
        Task<NiveliGjuhesorDTO> CreateAsync(AddNiveliGjuhesorRequestDTO add);
        Task<NiveliGjuhesorDTO?> UpdateAsync(Guid id, UpdateNiveliGjuhesorRequestDto update);
        Task<NiveliGjuhesorDTO?> DeleteAsync(Guid id);
        Task<NiveliGjuhesorDTO?> GetByNameAsync(string lvl);
    }
}
