using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Domain.Models;

namespace MyApp.Infrastructure.DataAccess.OrderRepository
{
    /// <summary>
    /// Repository interface for managing order data operations
    /// Provides methods for retrieving and creating order information
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Retrieves all orders from the data store asynchronously
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a list of all orders in the system.
        /// Returns an empty list if no orders are found.
        /// </returns>
        Task<List<AllOrders>> GetAllOrdersAsync();
        
        /// <summary>
        /// Retrieves a specific order by its unique identifier asynchronously
        /// </summary>
        /// <param name="orderId">The unique identifier of the order to retrieve</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the order details if found, or null if no order exists with the specified ID.
        /// </returns>
        Task<AllOrders> GetOrderByIdAsync(int orderId);
        
        /// <summary>
        /// Adds new order information to the data store asynchronously
        /// </summary>
        /// <param name="oimodel">The order information model containing the details to be added</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the unique identifier of the newly created order information record.
        /// </returns>
        Task<int> AddOrderInfoAsync(OIModel oimodel);
    }
}