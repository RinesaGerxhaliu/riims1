using Microsoft.EntityFrameworkCore;
using RIIMS.Domain.Entities;
using RIIMS.Domain.Interfaces;
using RIIMSAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Infrastructure.Repositories
{
    public class NiveliAkademikRepository : INiveliAkademikRepository
    {
        private readonly RiimsDbContext dbcontext;

        public NiveliAkademikRepository(RiimsDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<NiveliAkademik> CreateAsync(NiveliAkademik niveliAkademik)
        {
            await dbcontext.NiveliAkademik.AddAsync(niveliAkademik);
            await dbcontext.SaveChangesAsync();
            return niveliAkademik;
        }

        public async Task<NiveliAkademik?> DeleteAsync(Guid id)
        {
            var existingInstitucioni = await dbcontext.NiveliAkademik.FirstOrDefaultAsync(x => x.Id == id);

            if (existingInstitucioni == null)
            {
                return null;
            }

            dbcontext.NiveliAkademik.Remove(existingInstitucioni);
            await dbcontext.SaveChangesAsync();

            return existingInstitucioni;
        }

        public async Task<List<NiveliAkademik>> GetAllAsync()
        {
            return await dbcontext.NiveliAkademik.ToListAsync();
        }

        public async Task<NiveliAkademik?> GetByIdAsync(Guid id)
        {
            return await dbcontext.NiveliAkademik.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<NiveliAkademik?> UpdateAsync(Guid id, NiveliAkademik niveliAkademik)
        {
            var existingInstitucioni = await dbcontext.NiveliAkademik.FirstOrDefaultAsync(x => x.Id == id);

            if (existingInstitucioni == null)
            {
                return null;
            }

            existingInstitucioni.lvl = niveliAkademik.lvl;

            await dbcontext.SaveChangesAsync();
            return existingInstitucioni;
        }

        public async Task<NiveliAkademik?> GetByNameAsync(string lvl)
        {
            return await dbcontext.NiveliAkademik
                .FirstOrDefaultAsync(i => i.lvl == lvl);
        }
    }
}
