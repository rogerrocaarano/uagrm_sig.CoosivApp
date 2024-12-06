using Microsoft.AspNetCore.Mvc;
using uagrm_sig.CoosivApp.Application.Services;

namespace uagrm_sig.CoosivApp.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoutesController(RouteService routeService) : ControllerBase
{
    [HttpGet("get-routes")]
    public async Task<IActionResult> GetRoutes()
    {
        try
        {
            var routes = await routeService.GetRoutes();
            return Ok(routes);
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
            var route = await routeService.GetRouteWithDetails(id);
            return Ok(route);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { error = e.Message });
        }
    }
    
    [HttpGet("get-routes-ids")]
    public async Task<IActionResult> GetRoutesIds()
    {
        try
        {
            var routesIds = await routeService.GetRoutesIds();
            return Ok(routesIds);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { error = e.Message });
        }
    }
}