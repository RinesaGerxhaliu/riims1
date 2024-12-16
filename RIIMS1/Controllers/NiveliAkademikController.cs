using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.InstitucioniDTOs;
using RIIMS.Application.DTOs.NiveliAkademikDTOs;
using RIIMS.Application.Interfaces;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NiveliAkademikController : ControllerBase
    {
        private readonly INiveliAkademikService _niveliAkademikService;

        public NiveliAkademikController(INiveliAkademikService niveliAkademikService)
        {
            _niveliAkademikService = niveliAkademikService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var institucioniList = await _niveliAkademikService.GetAllAsync();
            return Ok(institucioniList);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var institucioniDTO = await _niveliAkademikService.GetByIdAsync(id);
            if (institucioniDTO == null)
            {
                return NotFound();
            }
            return Ok(institucioniDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddNiveliAkademikRequestDto addNiveliAkademik)
        {
            var result = await _niveliAkademikService.CreateAsync(addNiveliAkademik);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateNiveliAkademikRequestDto updateNiveliAkademik)
        {
            var updatedInstitucioni = await _niveliAkademikService.UpdateAsync(id, updateNiveliAkademik);
            if (updatedInstitucioni == null)
            {
                return NotFound();
            }
            return Ok(updatedInstitucioni);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedInstitucioni = await _niveliAkademikService.DeleteAsync(id);
            if (deletedInstitucioni == null)
            {
                return NotFound();
            }
            return Ok(deletedInstitucioni);
        }
    }
}
