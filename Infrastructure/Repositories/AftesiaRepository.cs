using Microsoft.EntityFrameworkCore;
using RIIMS.Domain.Entities;
using RIIMSAPI.Domain.Interfaces;
using RIIMS.Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class AftesiaRepository : IAftesiaRepository
    {
        private readonly RiimsDbContext dbcontext;

        public AftesiaRepository(RiimsDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<List<Aftesite>> GetAllAsync(string userId)
        {
            return await dbcontext.Aftesite
             .Include(a => a.Institucioni)
             .Where(a => a.UserId == userId)
             .ToListAsync();
        }

        public async Task<Aftesite?> GetByIdAsync(Guid id)
        {
            return await dbcontext.Aftesite
             .Include(a => a.Institucioni)
             .FirstOrDefaultAsync(a => a.Id == id);

        }
        public async Task<Aftesite> CreateAsync(string userId, Aftesite aftesite)
        {
            aftesite.UserId = userId;
            await dbcontext.Aftesite.AddAsync(aftesite);
            await dbcontext.SaveChangesAsync();
            return aftesite;
        }

        public async Task<Aftesite?> UpdateAsync(Guid id, Aftesite aftesite)
        {
            var existingAftesia = await dbcontext.Aftesite.FirstOrDefaultAsync(x => x.Id == id);

            if (existingAftesia == null)
            {
                return null;
            }

            existingAftesia.Emri = aftesite.Emri;
            existingAftesia.InstitucioniId = aftesite.InstitucioniId;

            await dbcontext.SaveChangesAsync();
            return existingAftesia;
        }

        public async Task<Aftesite?> DeleteAsync(Guid id)
        {

            var existingAftesia = await dbcontext.Aftesite
                .Include(a => a.Institucioni)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingAftesia == null)
            {
                return null;
            }

            dbcontext.Aftesite.Remove(existingAftesia);
            await dbcontext.SaveChangesAsync();

            return existingAftesia;
        }
    }
}
