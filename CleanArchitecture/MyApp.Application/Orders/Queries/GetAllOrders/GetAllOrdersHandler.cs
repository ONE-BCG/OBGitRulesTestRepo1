
using MediatR;
using MyApp.Infrastructure.DataAccess.OrderRepository;

namespace MyApp.Application.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersRequestDto, GetAllOrdersResponseDto>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }
        public async Task<GetAllOrdersResponseDto> Handle(GetAllOrdersRequestDto request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return new GetAllOrdersResponseDto
            {
                Orders = orders
            };
        }

    }
}