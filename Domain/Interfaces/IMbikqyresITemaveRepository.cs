using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Domain.Interfaces
{
    public interface IMbikqyresITemaveRepository
    {
        Task<List<MbikqyresITemave>> GetAllAsync(string userId);
        Task<MbikqyresITemave?> GetByIdAsync(Guid id);
        Task<MbikqyresITemave> CreateAsync(string userId, MbikqyresITemave mbikqyres);
        Task<MbikqyresITemave?> UpdateAsync(Guid id, MbikqyresITemave mbikqyres);
        Task<MbikqyresITemave?> DeleteAsync(Guid id);
    }
}
