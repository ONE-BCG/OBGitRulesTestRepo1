using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Domain.Models;

namespace MyApp.Infrastructure.DataAccess.OrderRepository
{
    /// <summary>
    /// Repository contract for order data operations
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Gets all orders from the database
        /// </summary>
        Task<List<AllOrders>> GetAllOrdersAsync();
        
        /// <summary>
        /// Gets a specific order by its ID
        /// </summary>
        Task<AllOrders> GetOrderByIdAsync(int orderId);
        
        /// <summary>
        /// Adds new order information and returns the generated ID
        /// </summary>
        Task<int> AddOrderInfoAsync(OIModel oimodel);
    }
}