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
            var niveliList = await _niveliAkademikService.GetAllAsync();
            return Ok(niveliList);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var niveliDTO = await _niveliAkademikService.GetByIdAsync(id);
            if (niveliDTO == null)
            {
                return NotFound();
            }
            return Ok(niveliDTO);
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
            var updatedNiveli = await _niveliAkademikService.UpdateAsync(id, updateNiveliAkademik);
            if (updatedNiveli == null)
            {
                return NotFound();
            }
            return Ok(updatedNiveli);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedNiveli = await _niveliAkademikService.DeleteAsync(id);
            if (deletedNiveli == null)
            {
                return NotFound();
            }
            return Ok(deletedNiveli);
        }
    }
}
