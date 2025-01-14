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
    public class SpecializimetRepository : ISpecializimetRepository
    {
        private readonly RiimsDbContext dbcontext;

        public SpecializimetRepository(RiimsDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<List<Specializimet>> GetAllAsync(string userId)
        {
            return await dbcontext.Specializimet
             .Include(a => a.Institucioni)
             .Where(a => a.UserId == userId)
             .ToListAsync();
        }

        public async Task<Specializimet?> GetByIdAsync(Guid id)
        {
            return await dbcontext.Specializimet
             .Include(a => a.Institucioni)
             .FirstOrDefaultAsync(a => a.Id == id);

        }

        public async Task<Specializimet> CreateAsync(string userId, Specializimet specializimet)
        {
            specializimet.UserId = userId;
            await dbcontext.Specializimet.AddAsync(specializimet);
            await dbcontext.SaveChangesAsync();
            return specializimet;
        }

        public async Task<Specializimet?> UpdateAsync(Guid id, Specializimet specializimet)
        {
            var existingAftesia = await dbcontext.Specializimet.FirstOrDefaultAsync(x => x.Id == id);

            if (existingAftesia == null)
            {
                return null;
            }

            existingAftesia.llojiIspecializimit = specializimet.llojiIspecializimit;
            existingAftesia.lokacionit = specializimet.lokacionit;
            existingAftesia.dataEFillimit = specializimet.dataEFillimit;
            existingAftesia.dataEMbarimit = specializimet.dataEMbarimit;
            existingAftesia.aftesiteEfituara = specializimet.aftesiteEfituara;
            existingAftesia.pershkrimi = specializimet.pershkrimi;
            existingAftesia.nrKredive = specializimet.nrKredive;
            existingAftesia.InstitucioniId = specializimet.InstitucioniId;
            await dbcontext.SaveChangesAsync();
            return existingAftesia;
        }

        public async Task<Specializimet?> DeleteAsync(Guid id)
        {

            var existingAftesia = await dbcontext.Specializimet
                .Include(a => a.Institucioni)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingAftesia == null)
            {
                return null;
            }

            dbcontext.Specializimet.Remove(existingAftesia);
            await dbcontext.SaveChangesAsync();

            return existingAftesia;
        }
    }
}
