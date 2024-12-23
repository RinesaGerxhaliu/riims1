using RIIMS.Application.DTOs.LicensatDTOs;
using RIIMS.Application.DTOs.SpecializimiDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Interfaces
{
    public interface ILicensaService
    {
        Task<List<LicensatDto>> GetAllAsync(int userId);
        Task<LicensatDto?> GetByIdAsync(Guid id);
        Task<LicensatDto> CreateAsync(int userId, AddLicensatRequestDto addLicensat);
        Task<LicensatDto?> UpdateAsync(Guid id, UpdateLicensatRequestDto updateLicensat);
        Task<LicensatDto?> DeleteAsync(Guid id);
    }
}
