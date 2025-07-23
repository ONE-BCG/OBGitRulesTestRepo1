using MediatR;
using MyApp.Domain.Models;

namespace MyApp.Application.Orders.Commands.AddOI
{
    public class AddOIRequestDto : IRequest<AddOIResponseDto>
    {
        public OIModel OrderInfo { get; set; }
              
    }
}