using RIIMS.Application.DTOs.GjuhaDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Interfaces
{
    public interface IGjuhetService
    {
        Task<List<GjuhetDto>> GetAllAsync();
        Task<GjuhetDto?> GetByIdAsync(Guid id);
        Task<GjuhetDto> CreateAsync(AddGjuhetDto add);
        Task<GjuhetDto?> UpdateAsync(Guid id, UpdateGjuhetDto update);
        Task<GjuhetDto?> DeleteAsync(Guid id);
        Task<GjuhetDto?> GetByNameAsync(string name);
    }
}
