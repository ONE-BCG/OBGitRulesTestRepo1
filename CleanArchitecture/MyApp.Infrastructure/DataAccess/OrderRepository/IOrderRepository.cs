using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Domain.Models;

namespace MyApp.Infrastructure.DataAccess.OrderRepository
{
    public interface IOrderRepository
    {
        //This is the interface for order repository
        //It defines the methods for data access operations related to orders
        Task<List<AllOrders>> GetAllOrdersAsync();
        // Retrieves all orders from the database
        Task<AllOrders> GetOrderByIdAsync(int orderId);
        // Retrieves a specific order by its ID
        // Adds new order information to the database
        Task<int> AddOrderInfoAsync(OIModel oimodel);
    }
}