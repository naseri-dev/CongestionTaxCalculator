using Application.Countries.Commands;
using Application.Countries.Queries;
using Domain.Entities.Countries.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCountryCommand createCountry)
        {
            var id = await _mediator.Send(createCountry);
            return Ok(id);
        }
        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] EditCountryCommand editCountry)
        {
            var id = await _mediator.Send(editCountry);
            return Ok(id);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CountryDto>> Get(Guid id)
        {
            var dto = await _mediator.Send(new GetCountryByIdQuery(id));
            return Ok(dto);
        }

        [HttpGet()]
        public async Task<ActionResult<List<CountryDto>>> Get()
        {
            var dto = await _mediator.Send(new GetCountriesQuery());
            return Ok(dto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CountryDto>> Delete(Guid id)
        {
            var dto = await _mediator.Send(new DeleteCountryCommand(id));
            return Ok(dto);
        }
    }
}
