using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uagrm_sig.CoosivApp.Application.Services;
using uagrm_sig.CoosivApp.Presentation.Api.DTOs.Routes;

namespace uagrm_sig.CoosivApp.Presentation.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class RoutesController(DataService dataService) : ControllerBase
{
    [HttpGet("get-routes")]
    public async Task<IActionResult> GetRoutes()
    {
        try
        {
            var routes = await dataService.GetRoutes();
            var response = routes.Select(route => new GetRoutesItem
            {
                Id = route.Id, 
                Name = route.Name
            }).ToList();
            return Ok(response);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { error = e.Message });
        }
    }

    [HttpGet("get-route/{id}")]
    public async Task<IActionResult> GetRoute(int id)
    {
        try
        {
            var route = await dataService.GetRouteWithDetails(id);
            return Ok(route);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { error = e.Message });
        }
    }
}