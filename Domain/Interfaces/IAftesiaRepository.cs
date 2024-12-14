﻿using RIIMS1.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    internal interface IAftesiaRepository
    {
        Task<List<Aftesite>> GetAllAsync(string userId);
        Task<Aftesite?> GetByIdAsync(Guid id);
        Task<Aftesite> CreateAsync(string userId, Aftesite aftesite);
        Task<Aftesite?> UpdateAsync(Guid id, Aftesite aftesite);
        Task<Aftesite?> DeleteAsync(Guid id);
    }
}
