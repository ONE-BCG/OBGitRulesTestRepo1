using MediatR;
using MyApp.Domain.Models;

namespace MyApp.Application.Orders.Commands.AddOI
{
    /// <summary>
    /// Request DTO for adding order information.
    /// Implements MediatR's IRequest interface to return an AddOIResponseDto.
    /// </summary>
    public class AddOIRequestDto : IRequest<AddOIResponseDto>
    {
        /// <summary>
        /// The order information to be added.
        /// This model contains the details needed to create a new order info entry.
        /// </summary>
        public OIModel OrderInfo { get; set; }

    }
}