using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.EksperiencaDTOs;
using RIIMS.Application.Interfaces;
using System.Security.Claims;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EksperiencaController : ControllerBase
    {
        private readonly IEksperiencaService _eksperiencaService;

        public EksperiencaController(IEksperiencaService eksperiencaService)
        {
            _eksperiencaService = eksperiencaService;
        }

        // GET ALL EKSPERIENCAT
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in the token.");
            }

            var eksperiencatList = await _eksperiencaService.GetAllAsync(userId);
            return Ok(eksperiencatList);
        }

        // GET EKSPERIENCA BY ID
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var eksperiencaDTO = await _eksperiencaService.GetByIdAsync(id);
            if (eksperiencaDTO == null)
            {
                return NotFound();
            }
            return Ok(eksperiencaDTO);
        }

        // CREATE EKSPERIENCA
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddEksperiencaRequestDTO addEksperienca)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("User ID not found in the token.");
            }

            var result = await _eksperiencaService.CreateAsync(userId, addEksperienca);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // UPDATE EKSPERIENCA BY ID
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateEksperiencaRequestDTO updateEksperienca)
        {
            var updatedEksperienca = await _eksperiencaService.UpdateAsync(id, updateEksperienca);
            if (updatedEksperienca == null)
            {
                return NotFound();
            }
            return Ok(updatedEksperienca);
        }

        // DELETE EKSPERIENCA
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedEksperienca = await _eksperiencaService.DeleteAsync(id);
            if (deletedEksperienca == null)
            {
                return NotFound();
            }
            return Ok(deletedEksperienca);
        }
    }
}

