using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MyApp.Infrastructure.DataAccess.OrderRepository;

namespace MyApp.Application.Orders.Commands.AddOI
{
    /// Handler for processing AddOIRequestDto.
    /// This class handles the command to add order information
    /// by calling the appropriate method in the order repository.
    public class AddOIHandler : IRequestHandler<AddOIRequestDto, AddOIResponseDto>
    {
        private readonly IOrderRepository _orderRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddOIHandler"/> class.
        /// Injects the order repository dependency.
        /// </summary>
        /// <param name="orderRepository">The repository used to manage order information.</param>
        public AddOIHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Handles the AddOIRequestDto by saving order information to the database.
        /// </summary>
        /// <param name="request">The request containing order information to be added.</param>
        /// <param name="cancellationToken">Token to cancel the operation.</param>
        /// <returns>Returns the response containing the newly created order info ID.</returns>

        public async Task<AddOIResponseDto> Handle(AddOIRequestDto request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.AddOrderInfoAsync(request.OrderInfo);

            return new AddOIResponseDto
            {
                OrderInformationId = order
            };
        }
    }
}