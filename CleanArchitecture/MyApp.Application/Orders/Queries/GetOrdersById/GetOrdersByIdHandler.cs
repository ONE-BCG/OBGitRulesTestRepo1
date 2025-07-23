
using MediatR;
using MyApp.Domain.Models;
using MyApp.Infrastructure.DataAccess.OrderRepository;

namespace MyApp.Application.Orders.Queries.GetOrdersById
{
    public class GetOrdersByIdHandler :IRequestHandler<GetOrdersByIdRequestDto, GetOrdersByIdResponseDto>
    {
        private readonly IOrderRepository _orderRepository;

/*************  ✨ Windsurf Command ⭐  *************/
/// <summary>
/// Initializes a new instance of the <see cref="GetOrdersByIdHandler"/> class.
/// </summary>
/// <param name="orderRepository">The order repository to access order data.</param>
/// <exception cref="ArgumentNullException">Thrown when orderRepository is null.</exception>

/*******  a433af7a-5705-4c02-9389-725e6604e80e  *******/
        public GetOrdersByIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

        public async Task<GetOrdersByIdResponseDto> Handle(GetOrdersByIdRequestDto request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrderByIdAsync(request.Id);
            return new GetOrdersByIdResponseDto
            {
                Order = orders
            };
        }
    }
}