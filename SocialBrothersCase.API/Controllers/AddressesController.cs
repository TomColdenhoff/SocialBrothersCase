using MediatR;
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
        
        /// <summary>
        /// Returns all addresses
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="descending"></param>
        /// <returns>List of addresses</returns>
        /// <response code="200">Returns array of addresses</response>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filter, [FromQuery] string? orderBy, [FromQuery] bool descending)
        {
            var query = new GetAllAddressesQuery(filter, orderBy, descending);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Returns address with the given Id
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns>Address</returns>
        /// <response code="200">Returns address when found</response>
        /// <response code="404">Returns 404 not found when address not found</response>
        [HttpGet("{addressId:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid addressId)
        {
            var query = new GetAddressByIdQuery(addressId);
            var result = await _mediator.Send(query);

            return result != null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Inserts an address
        /// </summary>
        /// <param name="address"></param>
        /// <returns>Newly created address</returns>
        /// <response code="201">Returns address when created</response>
        /// <response code="400">Bad request if given address model is not valid</response>
        [HttpPost]
        public async Task<IActionResult> CreateAddress([FromBody] Address address)
        {
            var command = new CreateAddressCommand(address);
            var result = await _mediator.Send(command);
            
            return CreatedAtAction(nameof(GetById), new {addressId = result.Id}, result);
        }

        /// <summary>
        /// Updates an address
        /// </summary>
        /// <param name="addressId"></param>
        /// <param name="address"></param>
        /// <returns>Updated address</returns>
        /// <response code="200">When update successful</response>
        /// <response code="400">Bad request if given address model is not valid</response>
        [HttpPut("{addressId:guid}")]
        public async Task<IActionResult> EditAddress([FromRoute] Guid addressId, [FromBody] Address address)
        {
            var command = new UpdateAddressCommand(addressId, address);
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Deletes an address
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        /// <response code="204">When deletion successful</response>
        /// <response code="404">When given id doesn't exist</response>
        [HttpDelete("{addressId:guid}")]
        public async Task<IActionResult> DeleteAddress([FromRoute] Guid addressId)
        {
            var command = new DeleteAddressCommand(addressId);
            var deleted = await _mediator.Send(command);

            return deleted ? NoContent() : NotFound();
        }

        /// <summary>
        /// Calculates the distance in KM's between two given addresses (id's)
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns>Distance in KM's</returns>
        /// <response code="200">When distance calculated</response>
        /// <response code="404">When given ids don't exist</response>
        [HttpGet("distance")]
        public async Task<IActionResult> GetDistanceBetweenAddresses([FromQuery] Guid from, [FromQuery] Guid to)
        {
            var query = new GetDistanceQuery(from, to);
            var distanceKm = await _mediator.Send(query);

            return distanceKm == null ? NotFound() : Ok(new {DistanceKm = distanceKm});
        }
    }
}
