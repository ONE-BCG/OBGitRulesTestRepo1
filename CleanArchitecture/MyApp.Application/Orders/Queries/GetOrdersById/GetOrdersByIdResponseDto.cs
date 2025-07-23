using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Domain.Models;

namespace MyApp.Application.Orders.Queries.GetOrdersById
{
    public class GetOrdersByIdResponseDto
    {
         public AllOrders? Order { get; set; }
    }
}