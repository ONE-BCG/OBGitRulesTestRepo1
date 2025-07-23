
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
        /// <summary>
        /// Handles the <see cref="GetAllOrdersRequestDto"/> and returns <see cref="GetAllOrdersResponseDto"/>.
        /// </summary>
        /// <param name="request">The request to handle.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The <see cref="GetAllOrdersResponseDto"/>.</returns>
/*******  ece5bc1e-99e3-416f-8a35-4baafee5a8ec  *******/
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