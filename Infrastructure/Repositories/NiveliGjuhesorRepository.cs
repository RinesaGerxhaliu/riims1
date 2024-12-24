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
    public class NiveliGjuhesorRepository : INiveliGjuhesorRepository
    {
        private readonly RiimsDbContext dbcontext;

        public NiveliGjuhesorRepository(RiimsDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<NiveliGjuhesor> CreateAsync(NiveliGjuhesor niveliGjuhesor)
        {
            await dbcontext.NiveliGjuhesor.AddAsync(niveliGjuhesor);
            await dbcontext.SaveChangesAsync();
            return niveliGjuhesor;
        }

        public async Task<NiveliGjuhesor?> DeleteAsync(Guid id)
        {
            var existingNiveli = await dbcontext.NiveliGjuhesor.FirstOrDefaultAsync(x => x.Id == id);

            if (existingNiveli == null)
            {
                return null;
            }

            dbcontext.NiveliGjuhesor.Remove(existingNiveli);
            await dbcontext.SaveChangesAsync();

            return existingNiveli;
        }

        public async Task<List<NiveliGjuhesor>> GetAllAsync()
        {
            return await dbcontext.NiveliGjuhesor.ToListAsync();
        }

        public async Task<NiveliGjuhesor?> GetByIdAsync(Guid id)
        {
            return await dbcontext.NiveliGjuhesor.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<NiveliGjuhesor?> GetByNameAsync(string lvl)
        {
            return await dbcontext.NiveliGjuhesor
               .FirstOrDefaultAsync(i => i.Niveli == lvl);
        }

        public async Task<NiveliGjuhesor?> UpdateAsync(Guid id, NiveliGjuhesor niveliGjuhesor)
        {
            var existingNiveli = await dbcontext.NiveliGjuhesor.FirstOrDefaultAsync(x => x.Id == id);

            if (existingNiveli == null)
            {
                return null;
            }

            existingNiveli.Niveli = niveliGjuhesor.Niveli;

            await dbcontext.SaveChangesAsync();
            return existingNiveli;
        }
    }
}
