using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RIIMS.Application.DTOs.AftesiteDTOs;
using RIIMS.Application.DTOs.UserDTOs;
using RIIMS.Application.Interfaces;

namespace RIIMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           
            var aftesiteList = await _userService.GetAllAsync();
            return Ok(aftesiteList);
        }

        [HttpGet("{id:string}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var aftesiteDTO = await _userService.GetByIdAsync(id);
            if (aftesiteDTO == null)
            {
                return NotFound();
            }
            return Ok(aftesiteDTO);
        }

        [HttpPut("{id:string}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateUserRequestDTO updateUser)
        {
            var updatedAftesia = await _userService.UpdateAsync(id, updateUser);
            if (updatedAftesia == null)
            {
                return NotFound();
            }
            return Ok(updatedAftesia);
        }

        [HttpDelete("{id:string}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var deletedAftesia = await _userService.DeleteAsync(id);
            if (deletedAftesia == null)
            {
                return NotFound();
            }
            return Ok(deletedAftesia);
        }
    }
}
