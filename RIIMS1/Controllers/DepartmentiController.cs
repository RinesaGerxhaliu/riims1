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
            int userId = 1;

            var aftesiteList = await _departmentiService.GetAllAsync();
            return Ok(aftesiteList);
        }

        // GET AFTESIA BY ID
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var aftesiteDTO = await _departmentiService.GetByIdAsync(id);
            if (aftesiteDTO == null)
            {
                return NotFound();
            }
            return Ok(aftesiteDTO);
        }

        // CREATE AFTESIA
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddDepartamentiRequestDto addDepartamenti)
        {
            int userId = 1;

            var result = await _departmentiService.CreateAsync(addDepartamenti);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // UPDATE AFTESIA BY ID
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateDepartamentiRequestDto updateDepartamenti)
        {
            var updatedAftesia = await _departmentiService.UpdateAsync(id, updateDepartamenti);
            if (updatedAftesia == null)
            {
                return NotFound();
            }
            return Ok(updatedAftesia);
        }

        // DELETE AFTESIA
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedAftesia = await _departmentiService.DeleteAsync(id);
            if (deletedAftesia == null)
            {
                return NotFound();
            }
            return Ok(deletedAftesia);
        }
    }
}
