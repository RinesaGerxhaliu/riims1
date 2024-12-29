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
    public class PublikimiRepository : IPublikimiRepository
    {
        private readonly RiimsDbContext dbcontext;

        public PublikimiRepository(RiimsDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public async Task<Publikimi> CreateAsync(string userId, Publikimi publikimi)
        {
            publikimi.UserId = userId;
            await dbcontext.Publikimi.AddAsync(publikimi);
            await dbcontext.SaveChangesAsync();
            return publikimi;
        }

        public async Task<Publikimi?> DeleteAsync(Guid id)
        {

            var existingAftesia = await dbcontext.Publikimi
                .Include(a => a.Departamenti)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingAftesia == null)
            {
                return null;
            }

            dbcontext.Publikimi.Remove(existingAftesia);
            await dbcontext.SaveChangesAsync();

            return existingAftesia;
        }

        public async Task<List<Publikimi>> GetAllAsync(string userId)
        {
            return await dbcontext.Publikimi
             .Include(a => a.Departamenti)
             .Where(a => a.UserId == userId)
             .ToListAsync();
        }

        public async Task<Publikimi?> GetByIdAsync(Guid id)
        {
            return await dbcontext.Publikimi
             .Include(a => a.Departamenti)
             .FirstOrDefaultAsync(a => a.Id == id);

        }

        public async Task<Publikimi?> UpdateAsync(Guid id, Publikimi publikimi)
        {
            var existingAftesia = await dbcontext.Publikimi.FirstOrDefaultAsync(x => x.Id == id);

            if (existingAftesia == null)
            {
                return null;
            }

            existingAftesia.Titulli = publikimi.Titulli;
            existingAftesia.LlojiPublikimit = publikimi.LlojiPublikimit;
            existingAftesia.LinkuPublikimit = publikimi.LinkuPublikimit;
            existingAftesia.AutoriKryesor = publikimi.AutoriKryesor;
            existingAftesia.DataPublikimi = publikimi.DataPublikimi;
            existingAftesia.DepartamentiId = publikimi.DepartamentiId;

            await dbcontext.SaveChangesAsync();
            return existingAftesia;
        }
    }
}
