using Microsoft.EntityFrameworkCore;
using RIIMS.Domain.Entities;
using RIIMS.Domain.Interfaces;
using RIIMS.Infrastructure;

namespace RIIMS.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RiimsDbContext dbcontext;

        public UserRepository(RiimsDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<User> CreateAsync(User user)
        {
            await dbcontext.User.AddAsync(user);
            await dbcontext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteAsync(string id)  
        {
            var existingUser = await dbcontext.User.FirstOrDefaultAsync(x => x.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            dbcontext.User.Remove(existingUser);
            await dbcontext.SaveChangesAsync();

            return existingUser;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbcontext.User
                .Include(a => a.NiveliAkademik)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(string id)  
        {
            return await dbcontext.User
                .Include(a => a.NiveliAkademik)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<User?> UpdateAsync(string id, User user)  
        {
            var existingUser = await dbcontext.User.FirstOrDefaultAsync(a => a.Id == id);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.emri = user.emri;
            existingUser.mbiemri = user.mbiemri;
            existingUser.Adresa = user.Adresa;
            existingUser.gjinia = user.gjinia;
            existingUser.dataELindjes = user.dataELindjes;
            existingUser.numriTelefonit = user.numriTelefonit;
            existingUser.Image = user.Image;
            existingUser.NiveliAkademikId = user.NiveliAkademikId;

            await dbcontext.SaveChangesAsync();
            return existingUser;
        }
    }
}
