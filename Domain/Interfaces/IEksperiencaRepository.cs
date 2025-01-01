using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Domain.Interfaces
{
    public interface IEksperiencaRepository
    {
        Task<List<Eksperienca>> GetAllAsync(string userId);

        Task<Eksperienca?> GetByIdAsync(Guid id);

        Task<Eksperienca> CreateAsync(string userId, Eksperienca eksperienca);

        Task<Eksperienca?> UpdateAsync(Guid id, Eksperienca eksperienca);

        Task<Eksperienca?> DeleteAsync(Guid id);
    }
}
