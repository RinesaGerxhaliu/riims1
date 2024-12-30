using Microsoft.EntityFrameworkCore;
using RIIMS.Domain.Entities;
using RIIMS.Domain.Interfaces;
using RIIMS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Infrastructure.Repositories
{
    public class MbikqyresITemaveRepository : IMbikqyresITemaveRepository
    {
        private readonly RiimsDbContext dbcontext;

        public MbikqyresITemaveRepository(RiimsDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<MbikqyresITemave> CreateAsync(string userId, MbikqyresITemave mbikqyres)
        {
            mbikqyres.UserId = userId;
            await dbcontext.MbikqyresITemave.AddAsync(mbikqyres);
            await dbcontext.SaveChangesAsync();
            return mbikqyres;
        }

        public async Task<MbikqyresITemave?> DeleteAsync(Guid id)
        {
            var existingMbikqyres = await dbcontext.MbikqyresITemave
               .Include(a => a.Departamenti)
               .FirstOrDefaultAsync(x => x.Id == id);

            if (existingMbikqyres == null)
            {
                return null;
            }

            dbcontext.MbikqyresITemave.Remove(existingMbikqyres);
            await dbcontext.SaveChangesAsync();

            return existingMbikqyres;
        }

        public async Task<List<MbikqyresITemave>> GetAllAsync(string userId)
        {
            return await dbcontext.MbikqyresITemave
             .Include(a => a.Departamenti)
             .Where(a => a.UserId == userId)
             .ToListAsync();
        }

        public async Task<MbikqyresITemave?> GetByIdAsync(Guid id)
        {
            return await dbcontext.MbikqyresITemave
            .Include(a => a.Departamenti)
            .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<MbikqyresITemave?> UpdateAsync(Guid id, MbikqyresITemave mbikqyres)
        {
            var existingMbikqyres = await dbcontext.MbikqyresITemave.FirstOrDefaultAsync(x => x.Id == id);

            if (existingMbikqyres == null)
            {
                return null;
            }

            existingMbikqyres.titulliTemes = mbikqyres.titulliTemes;
            existingMbikqyres.studenti = mbikqyres.studenti;
            existingMbikqyres.data = mbikqyres.data;
            existingMbikqyres.DepartamentiId = mbikqyres.DepartamentiId;

            await dbcontext.SaveChangesAsync();
            return existingMbikqyres;
        }
    }
}
