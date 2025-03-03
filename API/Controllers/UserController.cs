using Application.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {

        public UserController(IMediator mediator):base(mediator)
        {
            
        }
        [HttpPost]
        public async Task<int> Create(CreateUserCommand user,CancellationToken cancellationToken)
        {
            
            var result=await Mediator.Send(user);
            return result;
        }

        [HttpGet]
        public async Task<List<Application.User.UserDto>> Get( CancellationToken cancellationToken)
        {
            var query = new GetUserListQuery();
            var result = await Mediator.Send(query);
            return result;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginModel query)
        {
            var result = await Mediator.Send(new LoginUserCommand
            {
                Username = query.Username,
                Password = query.Password
            });
            return Ok(new { Token = result });
        }
    }
}
