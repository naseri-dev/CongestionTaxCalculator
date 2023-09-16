using Application.Cars.Queries;
using Domain.Entities.Cars.Dtos;
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

        [HttpGet()]
        public async Task<ActionResult<List<CarDto>>> Get()
        {
            var dto = await _mediator.Send(new GetCarQuery());
            return Ok(dto);
        }

        [HttpPost("get-congestion-tax")]
        public async Task<ActionResult<CongestionTaxResult>> GetTax([FromBody] GetCongestionTaxQuery query)
        {
            var dto = await _mediator.Send(query);
            return Ok(dto);
        }
    }
}
