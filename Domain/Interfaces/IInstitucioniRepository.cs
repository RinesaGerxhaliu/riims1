using RIIMS1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    internal interface IInstitucioniRepository
    {
        Task<List<Institucioni>> GetAllAsync();
        Task<Institucioni?> GetByIdAsync(Guid id);
        Task<Institucioni> CreateAsync(Institucioni institucioni);
        Task<Institucioni?> UpdateAsync(Guid id, Institucioni institucioni);
        Task<Institucioni?> DeleteAsync(Guid id);
        Task<Institucioni?> GetByNameAsync(string name);
    }
}
