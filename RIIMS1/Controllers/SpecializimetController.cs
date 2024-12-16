using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.SpecializimiDTOs;
using RIIMS.Application.Interfaces;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecializimetController : ControllerBase
    {
        private readonly ISpecializimiService _specializimiService;

        public SpecializimetController(ISpecializimiService specializimiService)
        {
            _specializimiService = specializimiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            int userId = 3;

            var aftesiteList = await _specializimiService.GetAllAsync(userId);
            return Ok(aftesiteList);
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var aftesiteDTO = await _specializimiService.GetByIdAsync(id);
            if (aftesiteDTO == null)
            {
                return NotFound();
            }
            return Ok(aftesiteDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddSpecializimetRequestDTO addSpecializimet)
        {
            int userId = 3;

            var result = await _specializimiService.CreateAsync(userId, addSpecializimet);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSpecializimetRequestDTO updateSpecializimet)
        {
            var updatedAftesia = await _specializimiService.UpdateAsync(id, updateSpecializimet);
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
            var deletedAftesia = await _specializimiService.DeleteAsync(id);
            if (deletedAftesia == null)
            {
                return NotFound();
            }
            return Ok(deletedAftesia);
        }
    }
}
