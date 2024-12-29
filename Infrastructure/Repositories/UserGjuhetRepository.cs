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
    public class UserGjuhetRepository : IUserGjuhetRepository
    {
        private readonly RiimsDbContext dbcontext;

        public UserGjuhetRepository(RiimsDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<UserGjuhet> CreateAsync(string userId, UserGjuhet userGjuhet)
        {
            userGjuhet.UserId = userId;
            await dbcontext.UserGjuhet.AddAsync(userGjuhet);
            await dbcontext.SaveChangesAsync();
            return userGjuhet;
        }

        public async Task<UserGjuhet?> DeleteAsync(Guid id)
        {
            var existingGjuha = await dbcontext.UserGjuhet
                .Include(x => x.NiveliGjuhesor)
                .Include(x => x.Gjuha)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (existingGjuha == null)
            {
                return null;
            }

            dbcontext.UserGjuhet.Remove(existingGjuha);
            await dbcontext.SaveChangesAsync();

            return existingGjuha;
        }

        public async Task<List<UserGjuhet>> GetAllAsync(string userId)
        {
            return await dbcontext.UserGjuhet
             .Include(x => x.NiveliGjuhesor)
             .Include(x => x.Gjuha)
             .Where(a => a.UserId == userId)
             .ToListAsync();
        }

        public async Task<UserGjuhet?> GetByIdAsync(Guid id)
        {
            return await dbcontext.UserGjuhet
             .Include(x => x.NiveliGjuhesor)
             .Include(x => x.Gjuha)
             .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<UserGjuhet?> UpdateAsync(Guid id, UserGjuhet userGjuhet)
        {
            var existingGjuha = await dbcontext.UserGjuhet.FirstOrDefaultAsync(x => x.Id == id);

            if (existingGjuha == null)
            {
                return null;
            }

            existingGjuha.GjuhaId = userGjuhet.GjuhaId;
            existingGjuha.NiveliGjuhesorId = userGjuhet.NiveliGjuhesorId;

            await dbcontext.SaveChangesAsync();
            return existingGjuha;
        }
    }
}
