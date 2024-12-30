using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.DepartamentiDTOs;
using RIIMS.Application.Interfaces;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentiController : ControllerBase
    {
        private readonly IDepartmentiService _departmentiService;

        public DepartmentiController(IDepartmentiService departmentiService)
        {
            _departmentiService = departmentiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departamentetList = await _departmentiService.GetAllAsync();
            return Ok(departamentetList);
        }

        // GET AFTESIA BY ID
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var departamentiDTO = await _departmentiService.GetByIdAsync(id);
            if (departamentiDTO == null)
            {
                return NotFound();
            }
            return Ok(departamentiDTO);
        }

        // CREATE AFTESIA
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddDepartamentiRequestDto addDepartamenti)
        {
            var result = await _departmentiService.CreateAsync(addDepartamenti);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // UPDATE AFTESIA BY ID
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateDepartamentiRequestDto updateDepartamenti)
        {
            var updatedDepartamenti = await _departmentiService.UpdateAsync(id, updateDepartamenti);
            if (updatedDepartamenti == null)
            {
                return NotFound();
            }
            return Ok(updatedDepartamenti);
        }

        // DELETE AFTESIA
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedDepartamenti = await _departmentiService.DeleteAsync(id);
            if (deletedDepartamenti == null)
            {
                return NotFound();
            }
            return Ok(deletedDepartamenti);
        }
    }
}
