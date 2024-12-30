using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.Services;
using RIIMS.Application.DTOs.AftesiteDTOs;
using System.Security.Claims;
using Application.Interfaces;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AftesiteController : ControllerBase
    {
        private readonly IAftesiaService _aftesiaService;

        public AftesiteController(IAftesiaService aftesiaService)
        {
            _aftesiaService = aftesiaService;
        }

        // GET ALL AFTESITE 
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in the token.");
            }

            var aftesiteList = await _aftesiaService.GetAllAsync(userId);
            return Ok(aftesiteList);
        }

        // GET AFTESIA BY ID
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var aftesiteDTO = await _aftesiaService.GetByIdAsync(id);
            if (aftesiteDTO == null)
            {
                return NotFound();
            }
            return Ok(aftesiteDTO);
        }

        // CREATE AFTESIA
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddAftesiaRequestDTO addAftesite)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in the token.");
            }

            var result = await _aftesiaService.CreateAsync(userId, addAftesite);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // UPDATE AFTESIA BY ID
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateAftesiaRequestDTO updateAftesite)
        {
            var updatedAftesia = await _aftesiaService.UpdateAsync(id, updateAftesite);
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
            var deletedAftesia = await _aftesiaService.DeleteAsync(id);
            if (deletedAftesia == null)
            {
                return NotFound();
            }
            return Ok(deletedAftesia);
        }
    }
}

