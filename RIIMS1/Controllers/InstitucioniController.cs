using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.Services;
using RIIMS.Application.DTOs.InstitucioniDTOs;
using Application.Interfaces;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstitucioniController : ControllerBase
    {
        private readonly IInstitucioniService _institucioniService;

        public InstitucioniController(IInstitucioniService institucioniService)
        {
            _institucioniService = institucioniService;
        }

        // GET ALL INSTITUCIONET
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var institucioniList = await _institucioniService.GetAllAsync();
            return Ok(institucioniList);
        }

        // GET INSTITUCIONI BY ID
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var institucioniDTO = await _institucioniService.GetByIdAsync(id);
            if (institucioniDTO == null)
            {
                return NotFound();
            }
            return Ok(institucioniDTO);
        }

        // CREATE INSTITUCIONI
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddInstitucioniRequestDTO addInstitucioni)
        {
            var result = await _institucioniService.CreateAsync(addInstitucioni);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // UPDATE INSTITUCIONI
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateInstitucioniRequestDTO updateInstitucioni)
        {
            var updatedInstitucioni = await _institucioniService.UpdateAsync(id, updateInstitucioni);
            if (updatedInstitucioni == null)
            {
                return NotFound();
            }
            return Ok(updatedInstitucioni);
        }

        // DELETE INSTITUCIONI
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedInstitucioni = await _institucioniService.DeleteAsync(id);
            if (deletedInstitucioni == null)
            {
                return NotFound();
            }
            return Ok(deletedInstitucioni);
        }
    }
}
