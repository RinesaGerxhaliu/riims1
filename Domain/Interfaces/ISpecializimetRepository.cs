using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Domain.Interfaces
{
    public interface ISpecializimetRepository
    {
        Task<List<Specializimet>> GetAllAsync(string userId);
        Task<Specializimet?> GetByIdAsync(Guid id);
        Task<Specializimet> CreateAsync(string userId, Specializimet specializimet);
        Task<Specializimet?> UpdateAsync(Guid id, Specializimet specializimet);
        Task<Specializimet?> DeleteAsync(Guid id);
    }
}
