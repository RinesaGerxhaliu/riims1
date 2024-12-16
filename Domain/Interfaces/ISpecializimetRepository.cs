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
        Task<List<Specializimet>> GetAllAsync(int userId);
        Task<Specializimet?> GetByIdAsync(Guid id);
        Task<Specializimet> CreateAsync(int userId, Specializimet specializimet);
        Task<Specializimet?> UpdateAsync(Guid id, Specializimet specializimet);
        Task<Specializimet?> DeleteAsync(Guid id);
    }
}
