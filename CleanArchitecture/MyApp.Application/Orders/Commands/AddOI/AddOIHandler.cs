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

/*************  ✨ Windsurf Command ⭐  *************/
        /// <summary>
        /// Constructor for AddOIHandler
        /// </summary>
        /// <param name="orderRepository">IOrderRepository instance</param>
/*******  4eb02db6-8be1-475c-a35b-9902631a91f7  *******/
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