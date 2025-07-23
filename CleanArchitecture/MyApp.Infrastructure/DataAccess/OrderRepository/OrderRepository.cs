using MyApp.Domain.Models;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;


namespace MyApp.Infrastructure.DataAccess.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionString;

        public OrderRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new ArgumentNullException("DefaultConnection", "Connection string not found in configuration.");
        }
        public async Task<List<AllOrders>> GetAllOrdersAsync()
        {
            var orders = new List<AllOrders>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetAllOrders", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
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

        public async Task<AllOrders> GetOrderByIdAsync(int orderId)
        {
            var order = new AllOrders();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetOrdersById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OrderId", orderId);

                    await conn.OpenAsync();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (await reader.ReadAsync())
                        {
                            order.IOrderID = reader.GetInt32(reader.GetOrdinal("iOrderID"));
                            order.IPatientID = reader.GetInt32(reader.GetOrdinal("iPatientID"));
                            order.IDMEID = reader.GetInt32(reader.GetOrdinal("iDMEID"));
                            order.DtDateStamp = reader.IsDBNull(reader.GetOrdinal("dtDateStamp")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("dtDateStamp"));
                        }
                    }
                }
            }
            return order;   // != null ? Task.FromResult(order) : Task.FromResult<AllOrders>(null);                               

        }

        public async Task<int> AddOrderInfoAsync(OIModel oimodel)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spAddOrderInfo", conn))
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@onMyWay", oimodel.IsOnMyWay);
                    cmd.Parameters.AddWithValue("@myWayTime", oimodel.OnMyWayTime??(object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@orderId", oimodel.OrderId);
                    cmd.Parameters.AddWithValue("@backDatedOrder", oimodel.IsBackDatedOrder);
                    cmd.Parameters.AddWithValue("@completedFrom", oimodel.CompletedFrom);
                    cmd.Parameters.AddWithValue("@originallyMixed", oimodel.IsOriginallyMixed);

                    conn.Open();
                    var result = await cmd.ExecuteScalarAsync();
                    return Convert.ToInt32(result);
                }
            }
        }


    }

}