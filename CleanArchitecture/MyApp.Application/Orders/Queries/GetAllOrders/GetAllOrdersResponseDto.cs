using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Domain.Models;

namespace MyApp.Application.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersResponseDto
    {
         public List<AllOrders> Orders { get; set; }

    }
}