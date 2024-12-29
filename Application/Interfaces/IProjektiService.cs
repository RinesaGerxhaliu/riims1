using RIIMS.Application.DTOs.LicensatDTOs;
using RIIMS.Application.DTOs.ProjektiDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Interfaces
{
    public interface IProjektiService
    {
        Task<List<ProjektiDto>> GetAllAsync(string userId);
        Task<ProjektiDto?> GetByIdAsync(Guid id);
        Task<ProjektiDto> CreateAsync(string userId, AddProjektiRequestDto addProjekti);
        Task<ProjektiDto?> UpdateAsync(Guid id, UpdateProjektiRequestDto updateProjekti);
        Task<ProjektiDto?> DeleteAsync(Guid id);
    }
}
