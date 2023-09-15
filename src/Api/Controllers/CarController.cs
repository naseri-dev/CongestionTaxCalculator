using Application.Cars.Queries;
using Application.Countries.Commands;
using Application.Countries.Queries;
using Domain.Entities.Countries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("get-congestion-tax")]
        public async Task<ActionResult<CongestionTaxResult>> GetTax([FromBody] GetCongestionTaxQuery query)
        {
            var dto = await _mediator.Send(query);
            return Ok(dto);
        }
    }
}
