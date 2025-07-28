using MyApp.Domain.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace MyApp.Infrastructure.DataAccess.OrderRepository
{
    /// <summary>
    /// Repository implementation for order data access operations using SQL Server
    /// </summary>
    /// <summary>
    /// SQL Server implementation of order repository
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionString;

        /// <summary>
        /// Initializes repository with database connection string from configuration
        /// </summary>
        /// <summary>
        /// Constructor - initializes with database connection string
        /// </summary>
        public OrderRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("DefaultConnection", "Connection string not found in configuration.");
        }
        /// <summary>
        /// Retrieves all orders from database using stored procedure
        /// </summary>
        /// <summary>
        /// Gets all orders using spGetAllOrders stored procedure
        /// </summary>
        public async Task<List<AllOrders>> GetAllOrdersAsync()
        {
            var orders = new List<AllOrders>();
            
            // Create database connection and command
            
            // Setup database connection and command
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetAllOrders", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    // Execute query and read results
                    // Read data and map to objects
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            // Map database columns to order object
                            // Map database row to AllOrders object
                            var order = new AllOrders
                            {
                                IOrderID = reader.GetInt32(reader.GetOrdinal("iOrderID")),
                                IPatientID = reader.GetInt32(reader.GetOrdinal("iPatientID")),
                                IDMEID = reader.GetInt32(reader.GetOrdinal("iDMEID")),
                                DtDateStamp = reader.IsDBNull(reader.GetOrdinal("dtDateStamp")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("dtDateStamp"))
                            };
                            orders.Add(order);
                        }
                    }
                }
            }

            return orders;
        }

        /// <summary>
        /// Gets specific order by ID using spGetOrdersById stored procedure
        /// </summary>
        public async Task<AllOrders> GetOrderByIdAsync(int orderId)
        {
            var order = new AllOrders();
            
            // Setup connection and command with parameter
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetOrdersById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderId", orderId);

                    await conn.OpenAsync();

                    // Execute and read single result
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (await reader.ReadAsync())
                        {
                            // Map database row to order object
                            order.IOrderID = reader.GetInt32(reader.GetOrdinal("iOrderID"));
                            order.IPatientID = reader.GetInt32(reader.GetOrdinal("iPatientID"));
                            order.IDMEID = reader.GetInt32(reader.GetOrdinal("iDMEID"));
                            order.DtDateStamp = reader.IsDBNull(reader.GetOrdinal("dtDateStamp")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("dtDateStamp"));
                        }
                    }
                }
            }
            return order;                               

        }

        /// <summary>
        /// Adds order information using spAddOrderInfo stored procedure
        /// </summary>
        public async Task<int> AddOrderInfoAsync(OIModel oimodel)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spAddOrderInfo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    // Add all required parameters from OIModel
                    cmd.Parameters.AddWithValue("@onMyWay", oimodel.IsOnMyWay);
                    cmd.Parameters.AddWithValue("@myWayTime", oimodel.OnMyWayTime??(object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@orderId", oimodel.OrderId);
                    cmd.Parameters.AddWithValue("@backDatedOrder", oimodel.IsBackDatedOrder);
                    cmd.Parameters.AddWithValue("@completedFrom", oimodel.CompletedFrom);
                    cmd.Parameters.AddWithValue("@originallyMixed", oimodel.IsOriginallyMixed);

                    conn.Open();
                    
                    // Execute and return generated ID
                    var result = await cmd.ExecuteScalarAsync();
                    return Convert.ToInt32(result);
                }
            }
        }


    }

}