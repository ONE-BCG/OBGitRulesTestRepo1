using Microsoft.AspNetCore.Mvc;
using MediatR;
using MyApp.Application.Orders.Queries.GetAllOrders;
using System.Threading.Tasks;
using MyApp.Application.Orders.Queries.GetOrdersById;
using MyApp.Application.Orders.Commands.AddOI;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

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
            try
            {
                var request = new GetAllOrdersRequestDto();
                var response = await _mediator.Send(request);
                
                if (response?.Orders == null || !response.Orders.Any())
                {
                    return Ok(new { Message = "No orders found", Data = new List<object>() });
                }
                
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving orders.");
                return StatusCode(500, new { Message = "An error occurred while retrieving orders" });
            }
        }

        [HttpGet("GetOrdersById")]
        public async Task<IActionResult> GetOrders(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new { Message = "Invalid ID provided. ID must be greater than 0." });
            }

            try
            {
                var request = new GetOrdersByIdRequestDto { Id = id };
                var response = await _mediator.Send(request);
                
                if (response?.Order == null)
                {
                    return NotFound(new { Message = $"Order with ID {id} not found." });
                }
                
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving the order", Error = ex.Message });
            }
        }

        [HttpPost("AddOrderInfo")]
        public async Task<IActionResult> AddOrderInfo([FromBody] AddOIRequestDto request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }


}
