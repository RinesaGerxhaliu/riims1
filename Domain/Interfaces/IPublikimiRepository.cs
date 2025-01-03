﻿using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Domain.Interfaces
{
    public interface IPublikimiRepository
    {
        Task<List<Publikimi>> GetAllAsync(string userId);
        Task<Publikimi?> GetByIdAsync(Guid id);
        Task<Publikimi> CreateAsync(string userId, Publikimi publikimi);
        Task<Publikimi?> UpdateAsync(Guid id, Publikimi publikimi);
        Task<Publikimi?> DeleteAsync(Guid id);
    }
}
