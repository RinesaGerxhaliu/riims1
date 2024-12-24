using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Domain.Interfaces
{
    public interface INiveliGjuhesorRepository
    {
        Task<List<NiveliGjuhesor>> GetAllAsync();
        Task<NiveliGjuhesor?> GetByIdAsync(Guid id);
        Task<NiveliGjuhesor> CreateAsync(NiveliGjuhesor niveliGjuhesor);
        Task<NiveliGjuhesor?> UpdateAsync(Guid id, NiveliGjuhesor niveliGjuhesor);
        Task<NiveliGjuhesor?> DeleteAsync(Guid id);
        Task<NiveliGjuhesor?> GetByNameAsync(string lvl);
    }
}
