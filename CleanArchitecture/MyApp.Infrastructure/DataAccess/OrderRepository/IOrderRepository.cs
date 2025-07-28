using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Domain.Models;

namespace MyApp.Infrastructure.DataAccess.OrderRepository
{
    /// <summary>
    /// Repository contract for order data operations
    /// /// This interface defines methods for retrieving and manipulating order data
    /// in the underlying data store, such as a SQL Server database.
    /// /// THis is test code for the OrderRepository class.
    /// /// New line for clarity
    /// /// This interface is used by the OrderRepository class to implement the actual data access logic.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Gets all orders from the database
        /// /// This method retrieves a list of all orders using the stored procedure spGetAllOrders.
        /// /// This is test code for the OrderRepository class.
        /// /// New line for clarity
        /// /// This method returns a list of AllOrders objects.
        /// </summary>
        Task<List<AllOrders>> GetAllOrdersAsync();
        
        /// <summary>
        /// Gets a specific order by its ID
        /// /// This method retrieves a single order using the stored procedure spGetOrdersById.
        /// /// This is test code for the OrderRepository class.
        /// /// New line for clarity
        /// /// This method returns an AllOrders object for the specified order ID.
        /// </summary>
        Task<AllOrders> GetOrderByIdAsync(int orderId);
        
        /// <summary>
        /// Adds new order information and returns the generated ID
        /// /// This method inserts a new order using the stored procedure spAddOrderInfo.
        /// /// It takes an OIModel object containing order details and returns the new order ID
        /// </summary>
        Task<int> AddOrderInfoAsync(OIModel oimodel);
    }
}