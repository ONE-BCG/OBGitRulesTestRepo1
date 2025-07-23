using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MyApp.Infrastructure.DataAccess.OrderRepository;

namespace MyApp.Application.Orders.Commands.AddOI
{
    public class AddOIHandler: IRequestHandler<AddOIRequestDto, AddOIResponseDto>
    {
        private readonly IOrderRepository _orderRepository;

        public AddOIHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<AddOIResponseDto> Handle(AddOIRequestDto request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.AddOrderInfoAsync( request.OrderInfo);

            return new AddOIResponseDto
            {
                OrderInformationId = order               
            };
        }
    }
}