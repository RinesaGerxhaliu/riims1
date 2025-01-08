using Microsoft.EntityFrameworkCore;
using RIIMS.Domain.Entities;
using RIIMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Infrastructure.Repositories
{
    public class HonorsAndAwardsRepository : IHonorsAndAwardsRepository
    {
        private readonly RiimsDbContext dbContext;
        public HonorsAndAwardsRepository(RiimsDbContext dbContext) => this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        //public RiimsDbContext DbContext { get; }

        public async Task<HonorsAndAwards> CreateAsync(string userId, HonorsAndAwards honorsandawards)
        {
            honorsandawards.UserId = userId;

            await dbContext.HonorsAndAwards.AddAsync(honorsandawards);

            await dbContext.SaveChangesAsync();

            return honorsandawards;
        }

        public async Task<HonorsAndAwards?> DeleteAsync(Guid id)
        {
            var existingHonorsAndAwards = await dbContext.HonorsAndAwards
                 .Include(h => h.Institucioni)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingHonorsAndAwards == null)
            {
                return null;
            }

            dbContext.HonorsAndAwards.Remove(existingHonorsAndAwards);
            await dbContext.SaveChangesAsync();
            return existingHonorsAndAwards;
        }

        public async Task<List<HonorsAndAwards>> GetAllAsync(string userId)
        {
            return await dbContext.HonorsAndAwards
              .Include(x => x.Institucioni)
              .Where(x => x.UserId == userId)
              .ToListAsync();
        }

        public async Task<HonorsAndAwards?> GetByIdAsync(Guid id)
        {
            return await dbContext.HonorsAndAwards
             .Include(x => x.Institucioni) 
             .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<HonorsAndAwards?> UpdateAsync(Guid id, HonorsAndAwards honorsandawards)
        {
            var existingHonorsAndAwards = await dbContext.HonorsAndAwards.FirstOrDefaultAsync(x => x.Id == id);

            if (existingHonorsAndAwards == null)
            {
                return null;
            }

            existingHonorsAndAwards.titulli = honorsandawards.titulli;
            existingHonorsAndAwards.issuer = honorsandawards.issuer;
            existingHonorsAndAwards.dataEleshimit = honorsandawards.dataEleshimit;
            existingHonorsAndAwards.pershkrimi = honorsandawards.pershkrimi;
            existingHonorsAndAwards.Institucioni = honorsandawards.Institucioni;


            await dbContext.SaveChangesAsync();
            return existingHonorsAndAwards;
        }
    }
}
