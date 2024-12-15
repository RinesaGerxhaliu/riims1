﻿using RIIMS.Application.DTOs.AftesiteDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAftesiaService
    {
        Task<List<AftesiaDTO>> GetAllAsync(int userId);
        Task<AftesiaDTO?> GetByIdAsync(Guid id);
        Task<AftesiaDTO> CreateAsync(int userId, AddAftesiaRequestDTO addAftesia);
        Task<AftesiaDTO?> UpdateAsync(Guid id, UpdateAftesiaRequestDTO updateAftesiaRequest);
        Task<AftesiaDTO?> DeleteAsync(Guid id);
    }
}