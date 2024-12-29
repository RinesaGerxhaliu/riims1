using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.LicensatDTOs;
using RIIMS.Application.DTOs.ProjektiDTOs;
using RIIMS.Application.Interfaces;
using RIIMS.Application.Services;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjektiController : ControllerBase
    {
        private readonly IProjektiService _projektiService;

        public ProjektiController(IProjektiService projektiService)
        {
            _projektiService = projektiService;
        }

        /*[HttpGet]
        public async Task<IActionResult> GetAll()
        {
            int userId = 1;

            var projektiList = await _projektiService.GetAllAsync(userId);
            return Ok(projektiList);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var projektiDTO = await _projektiService.GetByIdAsync(id);
            if (projektiDTO == null)
            {
                return NotFound();
            }
            return Ok(projektiDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddProjektiRequestDto add)
        {
            int userId = 1;

            var result = await _projektiService.CreateAsync(userId, add);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }*/

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateProjektiRequestDto update)
        {
            var updatedProjekti = await _projektiService.UpdateAsync(id, update);
            if (updatedProjekti == null)
            {
                return NotFound();
            }
            return Ok(updatedProjekti);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedProjekti = await _projektiService.DeleteAsync(id);
            if (deletedProjekti == null)
            {
                return NotFound();
            }
            return Ok(deletedProjekti);
        }
    }
}
