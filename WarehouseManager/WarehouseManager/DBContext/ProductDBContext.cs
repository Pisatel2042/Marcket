using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            using (NpgsqlConnection conn = new NpgsqlConnection(ConnectionString))
            {
                using (NpgsqlCommand cmd = new NpgsqlCommand("", conn))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CollectionProduct.Add(new Product
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetDecimal(2),
                                image = reader.GetString(3),
                                Description = reader.GetString(4),
                                StockQuantity = reader.GetInt32(5),
                                CategoryId = reader.GetInt32(6),
                                Weight = reader.GetDecimal(7),
                                EmployeeId = reader.GetInt32(8),
                            });
                        }
                    }
                }
                return CollectionProduct;
            }
        } 
      
    }
}
