using Microsoft.EntityFrameworkCore;
using RIIMS.Domain.Entities;
using RIIMSAPI.Domain.Interfaces;
using RIIMS.Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class InstitucioniRepository : IInstitucioniRepository
    {
        private readonly RiimsDbContext dbcontext;

        public InstitucioniRepository(RiimsDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<List<Institucioni>> GetAllAsync()
        {
            return await dbcontext.Institucioni.ToListAsync();
        }

        public async Task<Institucioni?> GetByIdAsync(Guid id)
        {
            return await dbcontext.Institucioni.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Institucioni> CreateAsync(Institucioni institucioni)
        {
            await dbcontext.Institucioni.AddAsync(institucioni);
            await dbcontext.SaveChangesAsync();
            return institucioni;
        }

        public async Task<Institucioni?> UpdateAsync(Guid id, Institucioni institucioni)
        {
            var existingInstitucioni = await dbcontext.Institucioni.FirstOrDefaultAsync(x => x.Id == id);

            if (existingInstitucioni == null)
            {
                return null;
            }

            existingInstitucioni.Emri = institucioni.Emri;

            await dbcontext.SaveChangesAsync();
            return existingInstitucioni;
        }

        public async Task<Institucioni?> DeleteAsync(Guid id)
        {
            var existingInstitucioni = await dbcontext.Institucioni.FirstOrDefaultAsync(x => x.Id == id);

            if (existingInstitucioni == null)
            {
                return null;
            }

            dbcontext.Institucioni.Remove(existingInstitucioni);
            await dbcontext.SaveChangesAsync();

            return existingInstitucioni;
        }

        public async Task<Institucioni?> GetByNameAsync(string name)
        {
            return await dbcontext.Institucioni
                .FirstOrDefaultAsync(i => i.Emri == name);
        }
    }
}
