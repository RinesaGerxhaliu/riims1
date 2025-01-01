using RIIMS.Application.DTOs.EksperiencaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Interfaces
{
    public interface IEksperiencaService
    {
        Task<List<EksperiencaDTO>> GetAllAsync(string userId);

        Task<EksperiencaDTO?> GetByIdAsync(Guid id);

        Task<EksperiencaDTO> CreateAsync(string userId, AddEksperiencaRequestDTO eksperienca);

        Task<EksperiencaDTO?> UpdateAsync(Guid id, UpdateEksperiencaRequestDTO eksperienca);

        Task<EksperiencaDTO?> DeleteAsync(Guid id);
    }
}
