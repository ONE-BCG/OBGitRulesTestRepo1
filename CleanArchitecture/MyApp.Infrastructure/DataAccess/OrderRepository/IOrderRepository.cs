using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Domain.Models;

namespace MyApp.Infrastructure.DataAccess.OrderRepository
{
    public interface IOrderRepository
    {
        Task<List<AllOrders>> GetAllOrdersAsync();
        Task<AllOrders> GetOrderByIdAsync(int orderId);
        Task<int> AddOrderInfoAsync(OIModel oimodel);
    }
}