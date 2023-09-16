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

        [HttpGet()]
        public async Task<ActionResult<List<CityDto>>> Get()
        {
            var dto = await _mediator.Send(new GetCityQuery());
            return Ok(dto);
        }
    }
}
