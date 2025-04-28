using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManager.Model;

namespace WarehouseManager.DBContext
{
    public class ProductDBContext
    {
        private string ConnectionString;
       public ProductDBContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public ObservableCollection<Product> GetProduct()
        {
            var CollectionProduct = new  ObservableCollection<Product>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            { conn.Open();
                using (SqlCommand cmd = new SqlCommand("select * from   products ", conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                        {
                            CollectionProduct.Add(new Product
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetDecimal(2),
                                image = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Description = reader.IsDBNull(4) ? null : reader.GetString(4),
                                StockQuantity = reader.GetInt32(5),
                                CategoryId = reader.GetInt32(6),
                                Weight = reader.GetDecimal(7),
                                EmployeeId = reader.IsDBNull(8) ? 0 : reader.GetInt32(8),
                                isFamilyFriendly = reader.IsDBNull(9) ? false : reader.GetBoolean(9),
                                gtin8 = reader.IsDBNull(10) ? 0 : Convert.ToInt64(reader.GetValue(10)),
                                manufactur = reader.IsDBNull(11) ? null : reader.GetString(11),

                                reviewID = reader.IsDBNull(12) ? 0 : reader.GetInt32(12)
                            });
                        }
                    
                }
                return CollectionProduct;
            }
        } 
      
    }
}
