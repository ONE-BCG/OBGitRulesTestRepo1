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
    /// <summary>
    /// API Controller for managing orders and order information
    /// Provides endpoints for retrieving and creating order data
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    // [Authorize] 
    public class OrdersController : ControllerBase
    {

        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the OrdersController class
        /// </summary>
        /// <param name="mediator">The mediator instance for handling CQRS operations</param>
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// Retrieves all orders from the system
        /// </summary>
        /// <returns>
        /// An ActionResult containing a list of all orders
        /// Returns 200 OK with the orders data on success
        /// </returns>
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
                return StatusCode(500, new { Message = "An error occurred while retrieving orders", Error = ex.Message });
            }
        }

        /// <summary>
        /// Retrieves a specific order by its unique identifier
        /// </summary>
        /// <param name="id">The unique identifier of the order to retrieve. Must be greater than 0</param>
        /// <returns>
        /// An ActionResult containing the order details if found
        /// Returns 200 OK with order data on success
        /// Returns 400 Bad Request if the ID is invalid (less than or equal to 0)
        /// </returns>
        [HttpGet("GetOrdersById")]
        public async Task<IActionResult> GetOrders(int id)
        {
            if (id <= 0) // check for valid id value
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

        /// <summary>
        /// Creates new order information in the system
        /// </summary>
        /// <param name="request">The order information request containing the details to be added</param>
        /// <returns>
        /// An ActionResult containing the result of the order creation
        /// Returns 200 OK with the created order information ID on success
        /// </returns>
        [HttpPost("AddOrderInfo")]
        public async Task<IActionResult> AddOrderInfo([FromBody] AddOIRequestDto request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }


}
