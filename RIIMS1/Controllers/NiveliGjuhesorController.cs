using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.NiveliAkademikDTOs;
using RIIMS.Application.DTOs.NiveliGjuhesorDTOs;
using RIIMS.Application.Interfaces;
using RIIMS.Application.Services;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NiveliGjuhesorController : ControllerBase
    {
        private readonly INiveliGjuhesorService _niveliGjuhesorService;

        public NiveliGjuhesorController(INiveliGjuhesorService niveliGjuhesorService)
        {
            _niveliGjuhesorService = niveliGjuhesorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var niveliList = await _niveliGjuhesorService.GetAllAsync();
            return Ok(niveliList);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var nivelDto = await _niveliGjuhesorService.GetByIdAsync(id);
            if (nivelDto == null)
            {
                return NotFound();
            }
            return Ok(nivelDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddNiveliGjuhesorRequestDTO add)
        {
            var result = await _niveliGjuhesorService.CreateAsync(add);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateNiveliGjuhesorRequestDto update)
        {
            var updatedNiveli = await _niveliGjuhesorService.UpdateAsync(id, update);
            if (updatedNiveli == null)
            {
                return NotFound();
            }
            return Ok(updatedNiveli);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedNiveli = await _niveliGjuhesorService.DeleteAsync(id);
            if (deletedNiveli == null)
            {
                return NotFound();
            }
            return Ok(deletedNiveli);
        }

    }
}
