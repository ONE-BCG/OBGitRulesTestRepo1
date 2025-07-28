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
    /// Defines the interface for data access layer operations related to orders and order information
    /// Follows the Repository pattern for data abstraction
    /// </summary>
    /// <summary>
    /// Repository contract for order data operations
    /// /// This interface defines methods for retrieving and manipulating order data
    /// in the underlying data store, such as a SQL Server database.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Retrieves all orders from the database asynchronously
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains a list of all orders in the system.
        /// Returns an empty list if no orders are found.
        /// </returns>
        /// <returns>
        /// A task representing the asynchronous operation.
        /// The task result contains a list of all orders in the system.
        /// Returns an empty list if no orders exist.
        /// </returns>
        /// <remarks>
        /// This method calls the spGetAllOrders stored procedure to fetch all order records.
        /// Use this method when you need to display all orders or perform bulk operations.
        /// </remarks>
        /// <summary>
        /// Gets all orders from the database
        /// ///     This method retrieves a list of all orders using the stored procedure spGetAllOrders.
        /// </summary>
        Task<List<AllOrders>> GetAllOrdersAsync();
        
        /// <summary>
        /// Retrieves a specific order by its unique identifier asynchronously
        /// </summary>
        /// <param name="orderId">The unique identifier of the order to retrieve</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the order details if found, or null if no order exists with the specified ID.
        /// </returns>
        /// <param name="orderId">The unique identifier of the order to retrieve. Must be a valid positive integer.</param>
        /// <returns>
        /// A task representing the asynchronous operation.
        /// The task result contains the order details if found, or an empty AllOrders object if not found.
        /// </returns>
        /// <remarks>
        /// This method calls the spGetOrdersById stored procedure with the provided order ID.
        /// Ensure the orderId parameter is validated before calling this method.
        /// </remarks>
        /// <exception cref="ArgumentException">Thrown when orderId is less than or equal to zero</exception>
        
        /// <summary>
        /// Gets a specific order by its ID
        /// ///     This method retrieves a single order using the stored procedure spGetOrdersById.
        /// </summary>
        Task<AllOrders> GetOrderByIdAsync(int orderId);
        
        /// <summary>
        /// Adds new order information to the data store asynchronously
        /// </summary>
        /// <param name="oimodel">The order information model containing the details to be added</param>
        /// <returns>
        /// A task that represents the asynchronous operation.
        /// The task result contains the unique identifier of the newly created order information record.
        /// </returns>
        /// <param name="oimodel">
        /// The order information model containing all the details to be persisted.
        /// Must include valid OrderId and other required fields.
        /// </param>
        /// <returns>
        /// A task representing the asynchronous operation.
        /// The task result contains the unique identifier of the newly created order information record.
        /// Returns the generated ID from the database upon successful insertion.
        /// </returns>
        /// <remarks>
        /// This method calls the spAddOrderInfo stored procedure to insert the order information.
        /// All fields from the OIModel will be mapped to corresponding stored procedure parameters.
        /// The method handles null values appropriately by converting them to DBNull.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when oimodel is null</exception>
        /// <exception cref="InvalidOperationException">Thrown when database operation fails</exception>
        
        /// <summary>
        /// Adds new order information and returns the generated ID
        /// </summary>
        Task<int> AddOrderInfoAsync(OIModel oimodel);
    }
}