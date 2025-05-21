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
                using (SqlCommand cmd = new SqlCommand("select [dbo].[Products].[Id],[dbo].[Products].[Name],[dbo].[Products].[Price],[dbo].[Products].[Image],[Description],[StockQuantity], c.Name,[Weight],[EmployeeId],[IsFamilyFriendly],[Gtin8],[Manufactur],[ReviewId],[ShelfLifeDate]  from [dbo].[Products], [dbo].[Categories] c where [CategoryId] = c.[Id]", conn))
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
                                CategoryId = reader.GetString(6),
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
        public ObservableCollection<CategoryProduct> GetСategory()
        {
            var CollectionCategory = new ObservableCollection<CategoryProduct>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new  SqlCommand("SELECT * FROM Categories", conn)) 
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CollectionCategory.Add(new CategoryProduct
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                            });
                        }
                    }
                } 
                return CollectionCategory;
            }
        }

        public ObservableCollection<Employees> GetEmployees()
        {
            var CollectionEmployees = new ObservableCollection<Employees>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Select * from Employees ", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CollectionEmployees.Add(new Employees
                            {
                                id = reader.GetInt32(0),
                                FirstName = reader.GetString(1),
                                Name = reader.GetString(2),
                                LastName = reader.GetString(3),
                                Email = reader.GetString(4),
                                PhoneNumber = reader.GetString(5),
                                PositionId = reader.GetInt32(6),
                                HireDate = reader.GetDateTime(7),
                                Salary = reader.GetDecimal(8),
                                IsActive = reader.GetBoolean(9),
                                IsCourier = reader.GetBoolean(10),

                            });
                        }
                    }
                }
                return CollectionEmployees;
            }
        }
        public ObservableCollection<Manufactur> GetManufactur()
        {
                var ListManufactur = new ObservableCollection<Manufactur>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("select Manufactur from Products group by Manufactur ", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ListManufactur.Add(new Manufactur
                            {

                                name_manufactur = reader.GetString(0),
                            });
                        }
                    }
                }
                return ListManufactur;
                
            }
        }

        public void Delete(string id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("usp_DeleteProduct", conn))
                {
                    SqlParameter IdParam = new SqlParameter("PId", System.Data.SqlDbType.Int);
                    IdParam.Value = id;
                    cmd.Parameters.Add(IdParam);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //public ObservableCollection<Product> FilterProduct(string category, string manufactur, string CategoryId)
        //{
        //    //using (SqlConnection conn = new SqlConnection(ConnectionString))
        //    //{
        //    //    conn.Open();
        //    //    using (SqlCommand cmd = new SqlCommand("",conn))
        //    //    {
        //    //        cmd.CommandType = System.Data.CommandType.Text;

        //    //    }
        //    //}
        //}
    }
}
