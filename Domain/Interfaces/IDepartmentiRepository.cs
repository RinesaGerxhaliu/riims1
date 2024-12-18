using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Domain.Interfaces
{
    public interface IDepartmentiRepository
    {
        Task<List<Departamenti>> GetAllAsync();
        Task<Departamenti?> GetByIdAsync(Guid id);
        Task<Departamenti> CreateAsync(Departamenti departamenti);
        Task<Departamenti?> UpdateAsync(Guid id, Departamenti departamenti);
        Task<Departamenti?> DeleteAsync(Guid id);
        Task<Departamenti?> GetByNameAsync(string name);
    }
}
