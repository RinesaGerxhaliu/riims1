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
           
            var usersList = await _userService.GetAllAsync();
            return Ok(usersList);
        }

       /* [HttpGet("{id:string}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var userDTO = await _userService.GetByIdAsync(id);
            if (userDTO == null)
            {
                return NotFound();
            }
            return Ok(userDTO);
        }

        [HttpPut("{id:string}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateUserRequestDTO updateUser)
        {
            var updatedUser = await _userService.UpdateAsync(id, updateUser);
            if (updatedUser == null)
            {
                return NotFound();
            }
            return Ok(updatedUser);
        }

        [HttpDelete("{id:string}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var deletedUser = await _userService.DeleteAsync(id);
            if (deletedUser == null)
            {
                return NotFound();
            }
            return Ok(deletedUser);
        }
       */
    }
}
