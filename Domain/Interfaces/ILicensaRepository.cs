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
        Task<List<Licensat>> GetAllAsync(int userId);
        Task<Licensat?> GetByIdAsync(Guid id);
        Task<Licensat> CreateAsync(int userId, Licensat licensat);
        Task<Licensat?> UpdateAsync(Guid id, Licensat licensat);
        Task<Licensat?> DeleteAsync(Guid id);
    }
}
