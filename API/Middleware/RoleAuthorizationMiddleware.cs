namespace API.Middleware
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Primitives;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Threading.Tasks;

    public class RoleAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public RoleAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token == null)
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Authorization token is missing");
                return;
            }

            try
            {
                // Decode and validate the JWT token
                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);

                // Get roles from token claims (assuming role is stored in claim)
                var roles = jwtToken?.Claims
                                    .FirstOrDefault(c => c.Type == "role")?.Value;

                // Check role (for example, check if the user is an Admin)
                if (roles != null && roles.Contains("Admin"))
                {
                    // Continue processing if role is authorized
                    await _next(context);
                }
                else
                {
                    // If role is not authorized, deny access
                    context.Response.StatusCode = 403; // Forbidden
                    await context.Response.WriteAsync("Forbidden: Insufficient role");
                }
            }
            catch
            {
                context.Response.StatusCode = 401; // Unauthorized
                await context.Response.WriteAsync("Invalid token");
            }
        }
    }
}
