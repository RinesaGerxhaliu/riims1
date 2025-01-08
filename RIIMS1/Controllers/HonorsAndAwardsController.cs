using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.HonorsAndAwardsDTOs;
using RIIMS.Application.Interfaces;
using System.Security.Claims;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HonorsAndAwardsController : ControllerBase
    {
        private readonly IHonorsAndAwardsService _honorsAndAwardsService;

        public HonorsAndAwardsController(IHonorsAndAwardsService honorsAndAwardsService)
        {
            _honorsAndAwardsService = honorsAndAwardsService;
        }

        // GET ALL HONORS&AWARDS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in the token.");
            }

            var honorsAndAwardsList = await _honorsAndAwardsService.GetAllAsync(userId);
            return Ok(honorsAndAwardsList);
        }

        // GET HONORS&AWARDS BY ID
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var honorsAndAwardsDTO = await _honorsAndAwardsService.GetByIdAsync(id);
            if (honorsAndAwardsDTO == null)
            {
                return NotFound();
            }
            return Ok(honorsAndAwardsDTO);
        }

        // CREATE HONORS&AWARDS
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddHonorsAndAwardsRequestDTO addHonorsAndAwards)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in the token.");
            }

            var result = await _honorsAndAwardsService.CreateAsync(userId, addHonorsAndAwards);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // UPDATE HONORS&AWARDS BY ID
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateHonorsAndAwardsRequestDTO updateHonors)
        {
            var updatedHonors = await _honorsAndAwardsService.UpdateAsync(id, updateHonors);
            if (updatedHonors == null)
            {
                return NotFound();
            }
            return Ok(updatedHonors);
        }

        // DELETE HONORS&AWARDS
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedHonorsAndAwards = await _honorsAndAwardsService.DeleteAsync(id);
            if (deletedHonorsAndAwards == null)
            {
                return NotFound();
            }
            return Ok(deletedHonorsAndAwards);
        }
    }
}
