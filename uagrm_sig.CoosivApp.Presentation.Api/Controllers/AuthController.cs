using Microsoft.AspNetCore.Mvc;
using uagrm_sig.CoosivApp.Application.Services;
using uagrm_sig.CoosivApp.Presentation.Api.DTOs.Auth;

namespace uagrm_sig.CoosivApp.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(AuthenticationService authenticationService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] PostLogin postLogin)
    {
        try
        {
            var user = authenticationService.ValidateUser(postLogin.ToUser());
            if (user == null)
            {
                return Unauthorized();
            }
            
            user = authenticationService.SetAuthToken(user);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { error = e.Message });
        }
    }
}