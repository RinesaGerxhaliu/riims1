using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.PunaVullnetareDTOs;
using RIIMS.Application.Interfaces;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PunaVullnetareController : ControllerBase
    {
        private readonly IPunaVullnetareService _punaVullnetareService;

        public PunaVullnetareController(IPunaVullnetareService punaVullnetareService)
        {
            _punaVullnetareService = punaVullnetareService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            int userId = 3;

            var aftesiteList = await _punaVullnetareService.GetAllAsync(userId);
            return Ok(aftesiteList);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var aftesiteDTO = await _punaVullnetareService.GetByIdAsync(id);
            if (aftesiteDTO == null)
            {
                return NotFound();
            }
            return Ok(aftesiteDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPunaVullnetareRequestDTO addpunaVullnetareRequestDTO)
        {
            int userId = 3;

            var result = await _punaVullnetareService.CreateAsync(userId, addpunaVullnetareRequestDTO);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePunaVullnetareRequestDTO updatePunaVullnetare)
        {
            var updatedAftesia = await _punaVullnetareService.UpdateAsync(id, updatePunaVullnetare);
            if (updatedAftesia == null)
            {
                return NotFound();
            }
            return Ok(updatedAftesia);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedAftesia = await _punaVullnetareService.DeleteAsync(id);
            if (deletedAftesia == null)
            {
                return NotFound();
            }
            return Ok(deletedAftesia);
        }
    }
}
