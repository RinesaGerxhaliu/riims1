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
    public class EdukimiRepository : IEdukimiRepository
    {
        private readonly RiimsDbContext dbcontext;

        public EdukimiRepository(RiimsDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<List<Edukimi>> GetAllAsync(string userId)
        {
            return await dbcontext.Edukimi
             .Include(e => e.Institucioni)
             .Include(e => e.NiveliAkademik)
             .Where(e => e.UserId == userId)
             .ToListAsync();
        }

        public async Task<Edukimi?> GetByIdAsync(Guid id)
        {
            return await dbcontext.Edukimi
            .Include(e => e.Institucioni)
            .Include(e => e.NiveliAkademik)
            .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Edukimi> CreateAsync(string userId, Edukimi edukimi)
        {
            edukimi.UserId = userId;
            await dbcontext.Edukimi.AddAsync(edukimi);
            await dbcontext.SaveChangesAsync();
            return edukimi;
        }

        public async Task<Edukimi?> UpdateAsync(Guid id, Edukimi edukimi)
        {
            var existingEdukimi = await dbcontext.Edukimi.FirstOrDefaultAsync(x => x.Id == id);

            if (existingEdukimi == null)
            {
                return null;
            }

            existingEdukimi.FushaStudimit = edukimi.FushaStudimit;
            existingEdukimi.Lokacioni = edukimi.Lokacioni;
            existingEdukimi.DataFillimit = edukimi.DataFillimit;
            existingEdukimi.DataMbarimit = edukimi.DataMbarimit;
            existingEdukimi.Pershkrimi = edukimi.Pershkrimi;
            existingEdukimi.Institucioni = edukimi.Institucioni;
            existingEdukimi.NiveliAkademik = edukimi.NiveliAkademik;

            await dbcontext.SaveChangesAsync();
            return existingEdukimi;
        }

        public async Task<Edukimi?> DeleteAsync(Guid id)
        {
            var existingEdukimi = await dbcontext.Edukimi
                .Include(pv => pv.Institucioni)
                .Include(e => e.NiveliAkademik)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingEdukimi == null)
            {
                return null;
            }

            dbcontext.Edukimi.Remove(existingEdukimi);
            await dbcontext.SaveChangesAsync();

            return existingEdukimi;
        }
    }
}
