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
    public class GjuhetRepository : IGjuhetRepository
    {
        private readonly RiimsDbContext dbcontext;

        public GjuhetRepository(RiimsDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<Gjuhet> CreateAsync(Gjuhet gjuhet)
        {
            await dbcontext.Gjuhet.AddAsync(gjuhet);
            await dbcontext.SaveChangesAsync();
            return gjuhet;
        }

        public async Task<Gjuhet?> DeleteAsync(Guid id)
        {
            var existingGjuha = await dbcontext.Gjuhet.FirstOrDefaultAsync(x => x.Id == id);

            if (existingGjuha == null)
            {
                return null;
            }

            dbcontext.Gjuhet.Remove(existingGjuha);
            await dbcontext.SaveChangesAsync();

            return existingGjuha;
        }

        public async Task<List<Gjuhet>> GetAllAsync()
        {
            return await dbcontext.Gjuhet.ToListAsync();
        }

        public async Task<Gjuhet?> GetByIdAsync(Guid id)
        {
            return await dbcontext.Gjuhet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Gjuhet?> GetByNameAsync(string name)
        {
            return await dbcontext.Gjuhet
               .FirstOrDefaultAsync(i => i.EmriGjuhes == name);
        }

        public async Task<Gjuhet?> UpdateAsync(Guid id, Gjuhet gjuhet)
        {
            var existingGjuha = await dbcontext.Gjuhet.FirstOrDefaultAsync(x => x.Id == id);

            if (existingGjuha == null)
            {
                return null;
            }

            existingGjuha.EmriGjuhes = gjuhet.EmriGjuhes;

            await dbcontext.SaveChangesAsync();
            return existingGjuha;
        }
    }
}
