using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.PunaVullnetareDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Interfaces
{
    public interface IPunaVullnetareService
    {
        Task<List<PunaVullnetareDTO>> GetAllAsync(string userId);
        Task<PunaVullnetareDTO?> GetByIdAsync(Guid id);
        Task<PunaVullnetareDTO> CreateAsync(string userId, AddPunaVullnetareRequestDTO addAftesia);
        Task<PunaVullnetareDTO?> UpdateAsync(Guid id, UpdatePunaVullnetareRequestDTO updatePunaVullnetareRequestDTO);
        Task<PunaVullnetareDTO?> DeleteAsync(Guid id);
    }
}
