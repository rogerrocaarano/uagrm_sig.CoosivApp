using Microsoft.AspNetCore.Mvc;
using uagrm_sig.CoosivApp.Domain.Entities;
using uagrm_sig.CoosivApp.Domain.Services;

namespace uagrm_sig.CoosivApp.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpGet("login")]
    public async Task<IActionResult> Login()
    {
        try
        {
            var user = new User
            {
                Id = 1,
                Username = "admin",
                Password = "admin123"
            };

            return Ok(authService.CreateToken(user));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}