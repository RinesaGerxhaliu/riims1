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
        Task<List<MbikqyresITemave>> GetAllAsync(int userId);
        Task<MbikqyresITemave?> GetByIdAsync(Guid id);
        Task<MbikqyresITemave> CreateAsync(int userId, MbikqyresITemave mbikqyres);
        Task<MbikqyresITemave?> UpdateAsync(Guid id, MbikqyresITemave mbikqyres);
        Task<MbikqyresITemave?> DeleteAsync(Guid id);
    }
}
