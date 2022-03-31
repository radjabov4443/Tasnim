using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Tasnim.Domain.Common;
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
        public async ValueTask<ActionResult<BaseResponse<User>>> Create([FromForm]UserForRegistrationDto userDto)
        {
            var result = await userService.CreateAsync(userDto);

            return StatusCode(result.Error == null ? 200 : 400, result);
        }

        [HttpGet]
        public async ValueTask<ActionResult<BaseResponse<IQueryable<User>>>> GetAll()
        {
            var result = await userService.GetAllAsync();

            return StatusCode(result.Error == null ? 200 : 204, result);
        }


        [HttpPut]
        public async ValueTask<ActionResult<BaseResponse<User>>> Put(long id, UserForRegistrationDto userDto)
        {
            var result = await userService.UpdateAsync(id, userDto);

            return StatusCode(result.Error == null ? 200 : 404, result);
        }

        [HttpGet("user")]
        public async ValueTask<ActionResult<BaseResponse<User>>> SignIn([FromQuery] UserForSignInDto user)
        {
            var result =
                await userService.GetAsync(p => p.Email == user.Email &&
                p.Password == HashPassword.Create(user.Password));

            return StatusCode(result.Error == null ? 200 : 400, result);
        }

        [HttpGet("{id}")]
        public async ValueTask<ActionResult<BaseResponse<User>>> Get(long id)
        {
            var result = await userService.GetAsync(p => p.Id == id);

            return StatusCode(result.Error == null ? 200 : 404, result);
        }


        [HttpDelete("{id}")]
        public async ValueTask<ActionResult<BaseResponse<User>>> Delete(long id)
        {
            var result = await userService.DeleteAsync(p => p.Id == id);

            return StatusCode(result.Error == null ? 200 : 404, result);
        }
    }
}
