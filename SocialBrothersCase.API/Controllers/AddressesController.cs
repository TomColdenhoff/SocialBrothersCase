using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using SocialBrothersCase.AddressDomain;
using SocialBrothersCase.API.Commands;
using SocialBrothersCase.API.Queries;

namespace SocialBrothersCase.API.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public AddressesController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filter, [FromQuery] string? orderBy, [FromQuery] bool descending)
        {
            var query = new GetAllAddressesQuery(filter, orderBy, descending);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{addressId:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid addressId)
        {
            var query = new GetAddressByIdQuery(addressId);
            var result = await _mediator.Send(query);

            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] Address address)
        {
            var command = new CreateAddressCommand(address);
            var result = await _mediator.Send(command);
            
            return CreatedAtAction(nameof(GetById), new {addressId = result.Id}, result);
        }

        [HttpPut("{addressId:guid}")]
        public async Task<IActionResult> EditAddress([FromRoute] Guid addressId, [FromBody] Address address)
        {
            var command = new UpdateAddressCommand(addressId, address);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{addressId:guid}")]
        public async Task<IActionResult> DeleteAddress([FromRoute] Guid addressId)
        {
            var command = new DeleteAddressCommand(addressId);
            var deleted = await _mediator.Send(command);

            return deleted ? NoContent() : NotFound();
        }
    }
}
