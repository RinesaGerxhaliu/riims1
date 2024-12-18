using RIIMS.Application.DTOs.DepartamentiDTOs;
using RIIMS.Application.DTOs.InstitucioniDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Interfaces
{
    public interface IDepartmentiService
    {
        Task<List<DepartamentiDto>> GetAllAsync();
        Task<DepartamentiDto?> GetByIdAsync(Guid id);
        Task<DepartamentiDto> CreateAsync(AddDepartamentiRequestDto addDepartamenti);
        Task<DepartamentiDto?> UpdateAsync(Guid id, UpdateDepartamentiRequestDto updateDepartamenti);
        Task<DepartamentiDto?> DeleteAsync(Guid id);
        Task<DepartamentiDto?> GetByNameAsync(string name);
    }
}
