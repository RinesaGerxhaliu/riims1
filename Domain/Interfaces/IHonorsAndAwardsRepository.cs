using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Domain.Interfaces
{
    public interface IHonorsAndAwardsRepository
    {
        Task<List<HonorsAndAwards>> GetAllAsync(string userId);

        Task<HonorsAndAwards?> GetByIdAsync(Guid id);

        Task<HonorsAndAwards> CreateAsync(string userId, HonorsAndAwards honorsandawards);

        Task<HonorsAndAwards?> UpdateAsync(Guid id, HonorsAndAwards honorsandawards);

        Task<HonorsAndAwards?> DeleteAsync(Guid id);
    }
}
