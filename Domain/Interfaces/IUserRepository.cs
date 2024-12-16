using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Domain.Interfaces
{
        public interface IUserRepository
        {
            Task<User> CreateAsync(User user);
            Task<User?> DeleteAsync(int id);
            Task<List<User>> GetAllAsync();
            Task<User?> GetByIdAsync(int id);
            Task<User?> UpdateAsync(int id, User user);
        }

    }
