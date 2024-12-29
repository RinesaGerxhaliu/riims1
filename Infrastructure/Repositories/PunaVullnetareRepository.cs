using Microsoft.EntityFrameworkCore;
using RIIMS.Domain.Entities;
using RIIMS.Domain.Interfaces;
using RIIMSAPI.Domain.Interfaces;
using RIIMSAPI.Infrastructure;


namespace RIIMS.Infrastructure.Repositories
{
    public class PunaVullnetareRepository : IPunaVullnetareRepository
    {
        private readonly RiimsDbContext _dbContext;

        public PunaVullnetareRepository(RiimsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PunaVullnetare> CreateAsync(string userId, PunaVullnetare punaVullnetare)
        {
            punaVullnetare.UserId = userId;
            await _dbContext.PunaVullnetare.AddAsync(punaVullnetare);
            await _dbContext.SaveChangesAsync();
            return punaVullnetare;
        }

        public async Task<PunaVullnetare?> DeleteAsync(Guid id)
        {
            var existingPuna = await _dbContext.PunaVullnetare
                .Include(p => p.Institucioni)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existingPuna == null)
            {
                return null;
            }

            _dbContext.PunaVullnetare.Remove(existingPuna);
            await _dbContext.SaveChangesAsync();
            return existingPuna;
        }

        public async Task<List<PunaVullnetare>> GetAllAsync(string userId)
        {
            return await _dbContext.PunaVullnetare
                .Include(p => p.Institucioni)
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task<PunaVullnetare?> GetByIdAsync(Guid id)
        {
            return await _dbContext.PunaVullnetare
                .Include(p => p.Institucioni)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PunaVullnetare?> UpdateAsync(Guid id, PunaVullnetare updatedPunaVullnetare)
        {
            var existingPuna = await _dbContext.PunaVullnetare.FirstOrDefaultAsync(p => p.Id == id);

            if (existingPuna == null)
            {
                return null;
            }

            existingPuna.Roli = updatedPunaVullnetare.Roli;
            existingPuna.DataFillimit = updatedPunaVullnetare.DataFillimit;
            existingPuna.DataMbarimit = updatedPunaVullnetare.DataMbarimit;
            existingPuna.Pershkrimi = updatedPunaVullnetare.Pershkrimi;
            existingPuna.InstitucioniId = updatedPunaVullnetare.InstitucioniId;

            await _dbContext.SaveChangesAsync();
            return existingPuna;
        }
    }
}
