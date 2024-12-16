using RIIMS.Application.DTOs.InstitucioniDTOs;
using RIIMS.Application.DTOs.NiveliAkademikDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Interfaces
{
    public interface INiveliAkademikService
    {
        Task<List<NiveliAkademikDto>> GetAllAsync();
        Task<NiveliAkademikDto?> GetByIdAsync(Guid id);
        Task<NiveliAkademikDto> CreateAsync(AddNiveliAkademikRequestDto addNiveliAkademik);
        Task<NiveliAkademikDto?> UpdateAsync(Guid id, UpdateNiveliAkademikRequestDto updateNiveliAkademik);
        Task<NiveliAkademikDto?> DeleteAsync(Guid id);
        Task<NiveliAkademikDto?> GetByNameAsync(string lvl);
    }
}
