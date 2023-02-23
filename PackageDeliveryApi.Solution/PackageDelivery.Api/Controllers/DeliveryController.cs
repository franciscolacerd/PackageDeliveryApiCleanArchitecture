using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PackageDelivery.Api.Models;
using PackageDelivery.Application.Features.Delivery.Requests.Commands;
using PackageDelivery.Application.Responses;
using System.Net;

namespace PackageDelivery.Api.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[Produces("application/json")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(void))]
[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400))]
[Route("api/[controller]")]
[ApiController]
public class DeliveryController : ControllerBase
{
    private readonly IMediator _mediator;

    public DeliveryController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpPost]
    [EnableCors(Policies.CorsPolicy)]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateDeliveryResponse))]
    public async Task<ActionResult> PostAsync([FromBody] CreateDeliveryCommand delivery)
    {
        try
        {
            delivery.Username = this.HttpContext?.User?.Identity?.Name ?? "system";

            return Ok(await this._mediator.Send(delivery));
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
        }
    }
}