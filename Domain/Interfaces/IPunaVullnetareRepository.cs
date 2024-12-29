using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RIIMS.Domain.Interfaces
{
    public interface IPunaVullnetareRepository
    {
        Task<List<PunaVullnetare>> GetAllAsync(string userId);
        Task<PunaVullnetare?> GetByIdAsync(Guid id);
        Task<PunaVullnetare> CreateAsync(string userId, PunaVullnetare punaVullnetare);
        Task<PunaVullnetare?> UpdateAsync(Guid id, PunaVullnetare punaVullnetare);
        Task<PunaVullnetare?> DeleteAsync(Guid id);
    }
}
