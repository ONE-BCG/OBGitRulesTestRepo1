using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MediatR;

namespace MyApp.Application.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersRequestDto:IRequest<GetAllOrdersResponseDto>
    {
     
    }
 
}