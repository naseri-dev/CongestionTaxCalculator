using Application.VehicleCategories.Queries;
using Domain.Entities.VehicleCategories.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VehicleCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<ActionResult<List<VehicleCategoryDto>>> Get()
        {
            var dto = await _mediator.Send(new GetVehicleCategoryQuery());
            return Ok(dto);
        }
    }
}
