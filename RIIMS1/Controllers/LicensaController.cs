using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.LicensatDTOs;
using RIIMS.Application.DTOs.SpecializimiDTOs;
using RIIMS.Application.Interfaces;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicensaController : ControllerBase
    {
        private readonly ILicensaService _licensaService;

        public LicensaController(ILicensaService licensaService)
        {
            _licensaService = licensaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            int userId = 1;

            var licensatList = await _licensaService.GetAllAsync(userId);
            return Ok(licensatList);
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var licensatDTO = await _licensaService.GetByIdAsync(id);
            if (licensatDTO == null)
            {
                return NotFound();
            }
            return Ok(licensatDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddLicensatRequestDto addLicensa)
        {
            int userId = 1;

            var result = await _licensaService.CreateAsync(userId, addLicensa);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateLicensatRequestDto update)
        {
            var updatedLicensa= await _licensaService.UpdateAsync(id, update);
            if (updatedLicensa == null)
            {
                return NotFound();
            }
            return Ok(updatedLicensa);
        }

        // DELETE AFTESIA
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedLicensa = await _licensaService.DeleteAsync(id);
            if (deletedLicensa == null)
            {
                return NotFound();
            }
            return Ok(deletedLicensa);
        }
    }
}
