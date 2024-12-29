using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Domain.Interfaces
{
    public interface ILicensaRepository
    {
        Task<List<Licensat>> GetAllAsync(string userId);
        Task<Licensat?> GetByIdAsync(Guid id);
        Task<Licensat> CreateAsync(string userId, Licensat licensat);
        Task<Licensat?> UpdateAsync(Guid id, Licensat licensat);
        Task<Licensat?> DeleteAsync(Guid id);
    }
}
