using RIIMS.Application.DTOs.InstitucioniDTOs;
using RIIMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IInstitucioniService
    {
        Task<List<InstitucioniDTO>> GetAllAsync();
        Task<InstitucioniDTO?> GetByIdAsync(Guid id);
        Task<InstitucioniDTO> CreateAsync(AddInstitucioniRequestDTO addInstitucioni);
        Task<InstitucioniDTO?> UpdateAsync(Guid id, UpdateInstitucioniRequestDTO updateInstitucioni);
        Task<InstitucioniDTO?> DeleteAsync(Guid id);
        Task<InstitucioniDTO?> GetByNameAsync(string name);
    }
}
