using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.PublikimiDTOs;
using RIIMS.Application.Interfaces;
using System.Security.Claims;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublikimiController : ControllerBase
    {
        private readonly IPublikimiService _publikimiService;

        public PublikimiController(IPublikimiService publikimiService)
        {
            _publikimiService = publikimiService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in the token.");
            }

            var publikimiList = await _publikimiService.GetAllAsync(userId);
            return Ok(publikimiList);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var publikimiDTO = await _publikimiService.GetByIdAsync(id);
            if (publikimiDTO == null)
            {
                return NotFound();
            }
            return Ok(publikimiDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPublikimiRequestDTO addPublikimi)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in the token.");
            }

            var result = await _publikimiService.CreateAsync(userId, addPublikimi);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePublikimiRequestDTO updatePublikimi)
        {
            var updatedPublikimi = await _publikimiService.UpdateAsync(id, updatePublikimi);
            if (updatedPublikimi == null)
            {
                return NotFound();
            }
            return Ok(updatedPublikimi);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedPublikimi = await _publikimiService.DeleteAsync(id);
            if (deletedPublikimi == null)
            {
                return NotFound();
            }
            return Ok(deletedPublikimi);
        }
    }
}
