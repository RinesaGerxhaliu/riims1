using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.SpecializimiDTOs;
using RIIMS.Application.Interfaces;
using System.Security.Claims;

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
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in the token.");
            }

            var specializimetList = await _specializimiService.GetAllAsync(userId);
            return Ok(specializimetList);
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var specializimiDTO = await _specializimiService.GetByIdAsync(id);
            if (specializimiDTO == null)
            {
                return NotFound();
            }
            return Ok(specializimiDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddSpecializimetRequestDTO addSpecializimet)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in the token.");
            }

            var result = await _specializimiService.CreateAsync(userId, addSpecializimet);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSpecializimetRequestDTO updateSpecializimet)
        {
            var updatedSpecializimi = await _specializimiService.UpdateAsync(id, updateSpecializimet);
            if (updatedSpecializimi == null)
            {
                return NotFound();
            }
            return Ok(updatedSpecializimi);
        }

        // DELETE AFTESIA
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedSpecializimi = await _specializimiService.DeleteAsync(id);
            if (deletedSpecializimi == null)
            {
                return NotFound();
            }
            return Ok(deletedSpecializimi);
        }
    }
}
