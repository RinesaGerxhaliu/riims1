using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Domain.Interfaces
{
    public interface IGjuhetRepository
    {
        Task<List<Gjuhet>> GetAllAsync();
        Task<Gjuhet?> GetByIdAsync(Guid id);
        Task<Gjuhet> CreateAsync(Gjuhet gjuhet);
        Task<Gjuhet?> UpdateAsync(Guid id, Gjuhet gjuhet);
        Task<Gjuhet?> DeleteAsync(Guid id);
        Task<Gjuhet?> GetByNameAsync(string name);
    }
}
