using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using WarehouseManager.Model;

namespace WarehouseManager.DBContext
{
    public class FinanceDBContext
    {
      private   string ConnectionSting;
        public FinanceDBContext(string connectionString)
        {
            ConnectionSting = connectionString;
        }

        public ObservableCollection<ProductDeliveryHistory> GetProductPurchaseHistory()
        {
            var Collecction = new ObservableCollection<ProductDeliveryHistory>();
            using (SqlConnection conn = new SqlConnection(ConnectionSting))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Collecction.Add(new ProductDeliveryHistory
                            {
                                Id = reader.GetInt32(0),
                                OrderId = reader.GetInt32(1),
                                EventTimestamp = reader.GetDateTime(2),
                                EventType = reader.GetString(3),
                                Description = reader.GetString(4),
                                OrderStatus = reader.GetString(5),
                                Location = reader.GetString(6),
                                EmployyeesID = reader.GetString(7),
                                AdditionalData = reader.IsDBNull(8) ? null : reader.GetString(8),
                                ShippingCost = reader.IsDBNull(9) ? 0 : reader.GetDecimal(9),
                                OrderTotal = reader.IsDBNull(10) ? 0 : reader.GetDecimal(10),

                            });
                        }

                    }
                }
                return Collecction;
            }

        }

       public string GetRevenue()
        {
            string revenue = string.Empty;  ; 
            using (SqlConnection conn = new SqlConnection(ConnectionSting))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            revenue = reader.GetString(0);

                        }
                    }
                  
                }
                return revenue;
            }
        }
        public string GetTodaysDeliveryCount()
        {
            string DeliveryCoun = string.Empty; ;
            using (SqlConnection conn = new SqlConnection(ConnectionSting))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DeliveryCoun = reader.GetString(0);

                        }
                    }

                }
                return DeliveryCoun;
            }
        }
    }
}
