using Microsoft.AspNetCore.Mvc;
using uagrm_sig.CoosivApp.Application.Services;
using uagrm_sig.CoosivApp.Presentation.Api.DTOs.ServiceCut;

namespace uagrm_sig.CoosivApp.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceCutController(DataService dataService) : ControllerBase
{
    [HttpPost("cut-service")]
    public async Task<IActionResult> PostServiceCut([FromBody] GetServiceCut getServiceCut)
    {
        try
        {
            var serviceCut = await dataService.GetServiceCut(getServiceCut.RouteId, getServiceCut.AccountId);
            if (serviceCut == null)
            {
                return NotFound();
            }

            var result = await dataService.SaveCutToServer(serviceCut);
            return result == null
                ? StatusCode(500, new { error = "Error saving record to Soap Server" })
                : Ok("Corte guardado con éxito");
        }
        catch (Exception e)
        {
            return StatusCode(500, new { error = e.Message });
        }
    }
}