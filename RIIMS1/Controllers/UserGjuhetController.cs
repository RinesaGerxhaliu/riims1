using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.UserGjuhetDTOs;
using RIIMS.Application.Interfaces;
using RIIMS.Application.Services;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGjuhetController : ControllerBase
    {
        private readonly IUserGjuhetService _userGjuhetService;

        public UserGjuhetController(IUserGjuhetService userGjuhetService)
        {
            _userGjuhetService = userGjuhetService;
        }

       /* [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //string userId = 1;

            var userGjuhetList = await _userGjuhetService.GetAllAsync(userId);
            return Ok(userGjuhetList);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var userGjuhetDTO = await _userGjuhetService.GetByIdAsync(id);
            if (userGjuhetDTO == null)
            {
                return NotFound();
            }
            return Ok(userGjuhetDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddUserGjuhetRequestDTO add)
        {
            //string userId = 1;

            var result = await _userGjuhetService.CreateAsync(userId, add);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserGjuhetRequestDTO update)
        {
            var updatedUserGjuhet = await _userGjuhetService.UpdateAsync(id, update);
            if (updatedUserGjuhet == null)
            {
                return NotFound();
            }
            return Ok(updatedUserGjuhet);
        }*/

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedUserGjuha = await _userGjuhetService.DeleteAsync(id);
            if (deletedUserGjuha == null)
            {
                return NotFound();
            }
            return Ok(deletedUserGjuha);
        }

    }
}
