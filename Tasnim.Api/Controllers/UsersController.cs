using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tasnim.Domain.Entities.Users;
using Tasnim.Service.Configurations;
using Tasnim.Service.DTOs;
using Tasnim.Service.Interfaces;

namespace Tasnim.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<User>> Create(UserForRegistrationDto userDto)
        {
            var result = await userService.CreateAsync(userDto);

            return result == null ? BadRequest(result) : Ok(result);
        }

        [HttpGet]
        public async ValueTask<ActionResult<User>> SignIn([FromQuery] UserForSignInDto user)
        {
            var result =
                await userService.GetAsync(p => p.Email == user.Email &&
                p.Password == HashPassword.Create(user.Password));

            return result == null ? NotFound(result) : Ok(result);
        }

        [HttpGet]
        public async ValueTask<ActionResult<IQueryable<User>>> GetAll()
        {
            var result = await userService.GetAllAsync();

            return result == null ? NoContent() : Ok(result);
        }

        [HttpGet("{id}")]
        public async ValueTask<ActionResult<User>> Get(long id)
        {
            var result = await userService.GetAsync(p => p.Id == id);

            return result == null ? NotFound(result) : Ok(result);
        }

        [HttpPut]
        public async ValueTask<ActionResult<User>> Put([FromBody]long id, UserForRegistrationDto userDto)
        {
            var result = await userService.UpdateAsync(id, userDto);

            return result == null ? NotFound(result) : Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async ValueTask<ActionResult<User>> Delete(long id)
        {
            var result = await userService.DeleteAsync(p => p.Id == id);

            return result == null ? NotFound(result) : Ok(result);
        }
    }
}
