
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