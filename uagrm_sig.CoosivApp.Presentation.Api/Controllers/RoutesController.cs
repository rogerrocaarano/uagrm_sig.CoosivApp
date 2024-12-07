using Microsoft.AspNetCore.Mvc;
using uagrm_sig.CoosivApp.Application.Services;
using uagrm_sig.CoosivApp.Presentation.Api.DTOs.Routes;

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
            var route = await routeService.GetRouteWithDetails(id);
            return Ok(route);
        }
        catch (Exception e)
        {
            return StatusCode(500, new { error = e.Message });
        }
    }
}