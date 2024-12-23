﻿using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Domain.Interfaces
{
    public interface IProjektiRepository
    {
        Task<List<Projekti>> GetAllAsync(int userId);
        Task<Projekti?> GetByIdAsync(Guid id);
        Task<Projekti> CreateAsync(int userId, Projekti projekti);
        Task<Projekti?> UpdateAsync(Guid id, Projekti projekti);
        Task<Projekti?> DeleteAsync(Guid id);
    }
}
