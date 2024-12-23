using Microsoft.EntityFrameworkCore;
using RIIMS.Domain.Entities;
using RIIMS.Domain.Interfaces;
using RIIMSAPI.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Infrastructure.Repositories
{
    public class ProjektiRepository : IProjektiRepository
    {
        private readonly RiimsDbContext dbcontext;

        public ProjektiRepository(RiimsDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<Projekti> CreateAsync(int userId, Projekti projekti)
        {
            projekti.UserId = userId;
            await dbcontext.Projekti.AddAsync(projekti);
            await dbcontext.SaveChangesAsync();
            return projekti;
        }

        public async Task<Projekti?> DeleteAsync(Guid id)
        {
            var existingProjekti = await dbcontext.Projekti
                .Include(a => a.Institucioni)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingProjekti == null)
            {
                return null;
            }

            dbcontext.Projekti.Remove(existingProjekti);
            await dbcontext.SaveChangesAsync();

            return existingProjekti;
        }

        public async Task<List<Projekti>> GetAllAsync(int userId)
        {
            return await dbcontext.Projekti
             .Include(a => a.Institucioni)
             .Where(a => a.UserId == userId)
             .ToListAsync();
        }

        public async Task<Projekti?> GetByIdAsync(Guid id)
        {
            return await dbcontext.Projekti
             .Include(a => a.Institucioni)
             .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Projekti?> UpdateAsync(Guid id, Projekti projekti)
        {
            var existingProjekti = await dbcontext.Projekti.FirstOrDefaultAsync(x => x.Id == id);

            if (existingProjekti == null)
            {
                return null;
            }
            existingProjekti.emriProjektit = projekti.emriProjektit;
            existingProjekti.startDate = projekti.startDate;
            existingProjekti.endDate = projekti.endDate;
            existingProjekti.collaborators = projekti.collaborators;
            existingProjekti.description = projekti.description;
            existingProjekti.InstitucioniId = projekti.InstitucioniId;

            await dbcontext.SaveChangesAsync();
            return existingProjekti;
        }
    }
}
