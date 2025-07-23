
using MediatR;
using MyApp.Domain.Models;
using MyApp.Infrastructure.DataAccess.OrderRepository;

namespace MyApp.Application.Orders.Queries.GetOrdersById
{
    public class GetOrdersByIdHandler :IRequestHandler<GetOrdersByIdRequestDto, GetOrdersByIdResponseDto>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersByIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }

/*************  ✨ Windsurf Command ⭐  *************/
/// <summary>
/// Handles the <see cref="GetOrdersByIdRequestDto"/> and returns <see cref="GetOrdersByIdResponseDto"/>.
/// </summary>
/// <param name="request">The request containing the order ID to retrieve.</param>
/// <param name="cancellationToken">The cancellation token.</param>
/// <returns>The <see cref="GetOrdersByIdResponseDto"/> containing the order details.</returns>

/*******  8327594c-92b6-4d89-b35f-efedf31c0036  *******/
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