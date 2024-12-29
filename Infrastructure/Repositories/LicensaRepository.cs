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
    public class LicensaRepository : ILicensaRepository
    {
        private readonly RiimsDbContext dbcontext;

        public LicensaRepository(RiimsDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<Licensat> CreateAsync(string userId, Licensat licensat)
        {
            licensat.UserId = userId;
            await dbcontext.Licensat.AddAsync(licensat);
            await dbcontext.SaveChangesAsync();
            return licensat;
        }

        public async Task<Licensat?> DeleteAsync(Guid id)
        {
            var existingLicensa = await dbcontext.Licensat
               .Include(a => a.Institucioni)
               .FirstOrDefaultAsync(x => x.Id == id);

            if (existingLicensa == null)
            {
                return null;
            }

            dbcontext.Licensat.Remove(existingLicensa);
            await dbcontext.SaveChangesAsync();

            return existingLicensa;
        }

        public async Task<List<Licensat>> GetAllAsync(string userId)
        {
            return await dbcontext.Licensat
             .Include(a => a.Institucioni)
             .Where(a => a.UserId == userId)
             .ToListAsync();
        }

        public async Task<Licensat?> GetByIdAsync(Guid id)
        {
            return await dbcontext.Licensat
             .Include(a => a.Institucioni)
             .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Licensat?> UpdateAsync(Guid id, Licensat licensat)
        {
            var existingLicensa = await dbcontext.Licensat.FirstOrDefaultAsync(x => x.Id == id);

            if (existingLicensa == null)
            {
                return null;
            }
            existingLicensa.Emri = licensat.Emri;
            existingLicensa.DataLeshimit = licensat.DataLeshimit;
            existingLicensa.DataSkadimit = licensat.DataSkadimit;
            existingLicensa.CredentialUrl = licensat.CredentialUrl;
            existingLicensa.CredentialId = licensat.CredentialId;
            existingLicensa.InstitucioniId = licensat.InstitucioniId;
            
            await dbcontext.SaveChangesAsync();
            return existingLicensa;
        }
    }
}
