using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMSAPI.Domain.Interfaces
{
    public interface IAftesiaRepository
    {
        Task<List<Aftesite>> GetAllAsync(int userId);
        Task<Aftesite?> GetByIdAsync(Guid id);
        Task<Aftesite> CreateAsync(int userId, Aftesite aftesite);
        Task<Aftesite?> UpdateAsync(Guid id, Aftesite aftesite);
        Task<Aftesite?> DeleteAsync(Guid id);
    }
}
