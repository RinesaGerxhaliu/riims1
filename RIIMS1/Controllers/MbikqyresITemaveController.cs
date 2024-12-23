using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.MbikqyresITemaveDTOs;
using RIIMS.Application.DTOs.PublikimiDTOs;
using RIIMS.Application.Interfaces;
using RIIMS.Application.Services;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MbikqyresITemaveController : ControllerBase
    {
        private readonly IMbikqyresITemaveService _mbikqyresService;

        public MbikqyresITemaveController(IMbikqyresITemaveService mbikqyresService)
        {
            _mbikqyresService = mbikqyresService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            int userId = 1;

            var mbikqyresList = await _mbikqyresService.GetAllAsync(userId);
            return Ok(mbikqyresList);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var mbikqyresDTO = await _mbikqyresService.GetByIdAsync(id);
            if (mbikqyresDTO == null)
            {
                return NotFound();
            }
            return Ok(mbikqyresDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddMbikqyresRequestDTO add)
        {
            int userId = 1;

            var result = await _mbikqyresService.CreateAsync(userId, add);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMbikqyresRequestDTO update)
        {
            var updatedMbikqyres = await _mbikqyresService.UpdateAsync(id, update);
            if (updatedMbikqyres == null)
            {
                return NotFound();
            }
            return Ok(updatedMbikqyres);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedMbikqyres = await _mbikqyresService.DeleteAsync(id);
            if (deletedMbikqyres == null)
            {
                return NotFound();
            }
            return Ok(deletedMbikqyres);
        }
    }
}
