using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_2024_25.API.Data;
using RS1_2024_25.API.Data.Models;
using RS1_2024_25.API.Data.Models.Auth;
using RS1_2024_25.API.Helper;
using RS1_2024_25.API.Helper.Api;
using RS1_2024_25.API.Services;
using System.Threading;
using System.Threading.Tasks;
using static RS1_2024_25.API.Endpoints.Auth.AuthLoginEndpoint;

namespace RS1_2024_25.API.Endpoints.Auth
{
    [Route("auth")]
    public class AuthLoginEndpoint(ApplicationDbContext db, MyAuthService authService) : MyEndpointBaseAsync
        .WithRequest<LoginRequest>
        .WithActionResult<LoginResponse>
    {
        [HttpPost("login")]
        public override async Task<ActionResult<LoginResponse>> HandleAsync(LoginRequest request, CancellationToken cancellationToken = default)
        {
            var loggedInUser = await db.MyAppUsers
         .FirstOrDefaultAsync(u => u.Email == request.Email && u.Password == request.Password, cancellationToken);

            if (loggedInUser == null)
            {
                return Unauthorized(new { Message = "Incorrect email or password" });
            }

            var newAuthToken = await authService.GenerateAuthToken(loggedInUser, cancellationToken);
            var authInfo = authService.GetAuthInfo(newAuthToken);

            return new LoginResponse
            {
                Token = newAuthToken.Value,
                MyAuthInfo = authInfo
            };

        }

        public class LoginRequest
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
        }

        public class LoginResponse
        {
            public required MyAuthInfo? MyAuthInfo { get; set; }
            public string Token { get; internal set; }
        }

    }
}
