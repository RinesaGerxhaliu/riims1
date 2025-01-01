using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.EdukimiDTOs;
using RIIMS.Application.Interfaces;
using System.Security.Claims;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EdukimiController : ControllerBase
    {
        private readonly IEdukimiService _edukimiService;

        public EdukimiController(IEdukimiService edukimiService)
        {
            _edukimiService = edukimiService;
        }

        // GET ALL EDUKIMET
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in the token.");
            }

            var edukimetList = await _edukimiService.GetAllAsync(userId);
            return Ok(edukimetList);
        }

        // GET EDUKIMI BY ID
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var edukimiDTO = await _edukimiService.GetByIdAsync(id);
            if (edukimiDTO == null)
            {
                return NotFound();
            }
            return Ok(edukimiDTO);
        }

        // CREATE EDUKIMI
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddEdukimiRequestDTO addEdukimi)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in the token.");
            }

            var result = await _edukimiService.CreateAsync(userId, addEdukimi);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // UPDATE EDUKIMI BY ID
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEdukimiRequestDTO updateEdukimi)
        {
            var updatedEdukimi = await _edukimiService.UpdateAsync(id, updateEdukimi);
            if (updatedEdukimi == null)
            {
                return NotFound();
            }
            return Ok(updatedEdukimi);
        }

        // DELETE EDUKIMI
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedEdukimi = await _edukimiService.DeleteAsync(id);
            if (deletedEdukimi == null)
            {
                return NotFound();
            }
            return Ok(deletedEdukimi);
        }
    }
}
