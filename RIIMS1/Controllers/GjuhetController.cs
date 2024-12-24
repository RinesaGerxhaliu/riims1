using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.GjuhaDTOs;
using RIIMS.Application.DTOs.NiveliGjuhesorDTOs;
using RIIMS.Application.Interfaces;
using RIIMS.Application.Services;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GjuhetController : ControllerBase
    {
        private readonly IGjuhetService _gjuhetService;

        public GjuhetController(IGjuhetService gjuhetService)
        {
            _gjuhetService = gjuhetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var gjuhetList = await _gjuhetService.GetAllAsync();
            return Ok(gjuhetList);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var gjuhetDto = await _gjuhetService.GetByIdAsync(id);
            if (gjuhetDto == null)
            {
                return NotFound();
            }
            return Ok(gjuhetDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddGjuhetDto add)
        {
            var result = await _gjuhetService.CreateAsync(add);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateGjuhetDto update)
        {
            var updatedGjuha = await _gjuhetService.UpdateAsync(id, update);
            if (updatedGjuha == null)
            {
                return NotFound();
            }
            return Ok(updatedGjuha);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedGjuha = await _gjuhetService.DeleteAsync(id);
            if (deletedGjuha == null)
            {
                return NotFound();
            }
            return Ok(deletedGjuha);
        }
    }
}
