using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Domain.Interfaces
{
    public interface IEdukimiRepository
    {
        Task<List<Edukimi>> GetAllAsync(string userId);
        Task<Edukimi?> GetByIdAsync(Guid id);
        Task<Edukimi> CreateAsync(string userId, Edukimi edukimi);
        Task<Edukimi?> UpdateAsync(Guid id, Edukimi edukimi);
        Task<Edukimi?> DeleteAsync(Guid id);
    }
}
