using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
      

       [HttpPost]
        public async Task<int> Create(Application.User.CreateUserCommand user,CancellationToken cancellationToken)
        {
            var result=await Mediator.Send(user);
            return result;
        }


    }
}
