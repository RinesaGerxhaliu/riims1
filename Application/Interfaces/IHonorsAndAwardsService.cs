using RIIMS.Application.DTOs.HonorsAndAwardsDTOs;
using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Interfaces
{
    public interface IHonorsAndAwardsService
    {
        Task<List<HonorsAndAwardsDTO>> GetAllAsync(string userId);

        Task<HonorsAndAwardsDTO?> GetByIdAsync(Guid id);

        Task<HonorsAndAwardsDTO> CreateAsync(string userId, AddHonorsAndAwardsRequestDTO honorsandawards);

        Task<HonorsAndAwardsDTO?> UpdateAsync(Guid id, UpdateHonorsAndAwardsRequestDTO honorsandawards);

        Task<HonorsAndAwardsDTO?> DeleteAsync(Guid id);
    }
}
