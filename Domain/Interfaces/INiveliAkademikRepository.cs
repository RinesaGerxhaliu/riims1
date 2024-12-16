using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Domain.Interfaces
{
    public interface INiveliAkademikRepository
    {
        Task<List<NiveliAkademik>> GetAllAsync();
        Task<NiveliAkademik?> GetByIdAsync(Guid id);
        Task<NiveliAkademik> CreateAsync(NiveliAkademik niveliAkademik);
        Task<NiveliAkademik?> UpdateAsync(Guid id, NiveliAkademik niveliAkademik);
        Task<NiveliAkademik?> DeleteAsync(Guid id);
        Task<NiveliAkademik?> GetByNameAsync(string lvl);
    }
}
