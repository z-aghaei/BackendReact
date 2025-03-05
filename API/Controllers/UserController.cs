using Application.DTO;
using Application.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        //[AllowAnonymous]
        [Authorize(Policy ="AdminPolicy")]
        public async Task<IActionResult> Create(CreateUserCommand user,CancellationToken cancellationToken)
        {
            
            var result=await Mediator.Send(user);
            return Ok(new { result });
        }

        [HttpGet]
        // [Authorize(Policy = "AdminPolicy")]
        // [AllowAnonymous]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
            var query = new GetUserListQuery();
            
            var result = await Mediator.Send(query);
            return Ok(result );
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

        [Authorize(Policy ="AdminPolicy")]
        [HttpPut]
        //[AllowAnonymous]
        public async Task<IActionResult> Update(UpdateUserCommand user, CancellationToken cancellationToken)
        {

            await Mediator.Send(user);
            return Ok();
        }

        [HttpDelete]
        [Authorize(Policy = "AdminPolicy")]
        //[AllowAnonymous]
        public async Task<IActionResult> Delete(DeleteUserCommand user, CancellationToken cancellationToken)
        {

            await Mediator.Send(user);
            return Ok();
        }
    }
}
