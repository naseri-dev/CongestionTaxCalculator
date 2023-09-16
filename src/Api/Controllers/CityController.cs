using Application.Cities.Commands;
using Application.Cities.Queries;
using Domain.Entities.Cities.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCityCommand createCity)
        {
            var id = await _mediator.Send(createCity);
            return Ok(id);
        }
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] EditCityCommand editCity)
        {
            var id = await _mediator.Send(editCity);
            return Ok(id);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CityDto>> Get(Guid id)
        {
            var dto = await _mediator.Send(new GetCityByIdQuery(id));
            return Ok(dto);
        }

        [HttpGet()]
        public async Task<ActionResult<List<CityDto>>> Get()
        {
            var dto = await _mediator.Send(new GetCityQuery());
            return Ok(dto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CityDto>> Delete(Guid id)
        {
            var dto = await _mediator.Send(new DeleteCityCommand(id));
            return Ok(dto);
        }
    }
}
