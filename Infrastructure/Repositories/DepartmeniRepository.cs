using Microsoft.EntityFrameworkCore;
using RIIMS.Domain.Entities;
using RIIMS.Domain.Interfaces;
using RIIMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Infrastructure.Repositories
{
    public class DepartmeniRepository : IDepartmentiRepository
    {
        private readonly RiimsDbContext dbcontext;

        public DepartmeniRepository(RiimsDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<List<Departamenti>> GetAllAsync()
        {
            return await dbcontext.Departamenti
             .Include(a => a.Institucioni)
             .ToListAsync();
        }

        public async Task<Departamenti?> GetByIdAsync(Guid id)
        {
            return await dbcontext.Departamenti
             .Include(a => a.Institucioni)
             .FirstOrDefaultAsync(a => a.Id == id);

        }

        public async Task<Departamenti> CreateAsync(Departamenti departamenti)
        {
            await dbcontext.Departamenti.AddAsync(departamenti);
            await dbcontext.SaveChangesAsync();
            return departamenti;
        }

        public async Task<Departamenti?> UpdateAsync(Guid id, Departamenti departamenti)
        {
            var existingAftesia = await dbcontext.Departamenti.FirstOrDefaultAsync(x => x.Id == id);

            if (existingAftesia == null)
            {
                return null;
            }

            existingAftesia.Emri = departamenti.Emri;
            existingAftesia.InstitucioniId = departamenti.InstitucioniId;

            await dbcontext.SaveChangesAsync();
            return existingAftesia;
        }

        public async Task<Departamenti?> DeleteAsync(Guid id)
        {

            var existingAftesia = await dbcontext.Departamenti
                .Include(a => a.Institucioni)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingAftesia == null)
            {
                return null;
            }

            dbcontext.Departamenti.Remove(existingAftesia);
            await dbcontext.SaveChangesAsync();

            return existingAftesia;
        }

        public async Task<Departamenti?> GetByNameAsync(string name)
        {
            return await dbcontext.Departamenti
                .FirstOrDefaultAsync(i => i.Emri == name);
        }

    }
}
