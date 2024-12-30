using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.PunaVullnetareDTOs;
using RIIMS.Application.Interfaces;
using System.Security.Claims;

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
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in the token.");
            }

            var punetList = await _punaVullnetareService.GetAllAsync(userId);
            return Ok(punetList);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var punaDTO = await _punaVullnetareService.GetByIdAsync(id);
            if (punaDTO == null)
            {
                return NotFound();
            }
            return Ok(punaDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPunaVullnetareRequestDTO addpunaVullnetareRequestDTO)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in the token.");
            }

            var result = await _punaVullnetareService.CreateAsync(userId, addpunaVullnetareRequestDTO);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePunaVullnetareRequestDTO updatePunaVullnetare)
        {
            var updatedPuna = await _punaVullnetareService.UpdateAsync(id, updatePunaVullnetare);
            if (updatedPuna == null)
            {
                return NotFound();
            }
            return Ok(updatedPuna);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedPuna = await _punaVullnetareService.DeleteAsync(id);
            if (deletedPuna == null)
            {
                return NotFound();
            }
            return Ok(deletedPuna);
        }
    }
}
