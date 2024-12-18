using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.PublikimiDTOs;
using RIIMS.Application.Interfaces;

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
            int userId = 3;

            var aftesiteList = await _publikimiService.GetAllAsync(userId);
            return Ok(aftesiteList);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var aftesiteDTO = await _publikimiService.GetByIdAsync(id);
            if (aftesiteDTO == null)
            {
                return NotFound();
            }
            return Ok(aftesiteDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPublikimiRequestDTO addPublikimi)
        {
            int userId = 3;

            var result = await _publikimiService.CreateAsync(userId, addPublikimi);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdatePublikimiRequestDTO updatePublikimi)
        {
            var updatedAftesia = await _publikimiService.UpdateAsync(id, updatePublikimi);
            if (updatedAftesia == null)
            {
                return NotFound();
            }
            return Ok(updatedAftesia);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedAftesia = await _publikimiService.DeleteAsync(id);
            if (deletedAftesia == null)
            {
                return NotFound();
            }
            return Ok(deletedAftesia);
        }
    }
}
