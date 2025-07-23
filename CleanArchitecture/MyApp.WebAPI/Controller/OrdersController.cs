using Microsoft.AspNetCore.Mvc;
using MediatR;
using MyApp.Application.Orders.Queries.GetAllOrders;
using System.Threading.Tasks;
using MyApp.Application.Orders.Queries.GetOrdersById;
using MyApp.Application.Orders.Commands.AddOI;
using Microsoft.AspNetCore.Authorization;

namespace MyApp.WebAPI.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] 
    public class OrdersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllOrdersRequestDto();
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("GetOrdersById")]
        public async Task<IActionResult> GetOrders(int id)
        {
            if (id <= 0) // check for valid id value
            {
                return BadRequest("Invalid ID provided.");
            }
            var request = new GetOrdersByIdRequestDto { Id = id };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("AddOrderInfo")]
        public async Task<IActionResult> AddOrderInfo([FromBody] AddOIRequestDto request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }


}
