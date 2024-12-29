using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Domain.Interfaces
{
    public interface IUserGjuhetRepository
    {
        Task<List<UserGjuhet>> GetAllAsync(string userId);
        Task<UserGjuhet?> GetByIdAsync(Guid id);
        Task<UserGjuhet> CreateAsync(string userId, UserGjuhet userGjuhet);
        Task<UserGjuhet?> UpdateAsync(Guid id, UserGjuhet userGjuhet);
        Task<UserGjuhet?> DeleteAsync(Guid id);
    }
}
