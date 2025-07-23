using MediatR;

namespace MyApp.Application.Orders.Queries.GetOrdersById
{
    public class GetOrdersByIdRequestDto: IRequest<GetOrdersByIdResponseDto>
    {
        public int Id { get; set; }
    }
}