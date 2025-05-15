using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotCurier.DBContext
{
    public class UserDBContext
    {

        public int FindUserByPhone(string phone)
        {
             int result = 0;
            string connectionString = "Server=DESKTOP-T5ODPOF;Database=Marcket ;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("check_phone_exists", conn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlParameter PhoneP = new SqlParameter
                    {
                        ParameterName = "@phone_number",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Size = 20,
                        Value = phone,
                        Direction = System.Data.ParameterDirection.Input,

                    };
                    
                    cmd.Parameters.Add(PhoneP);


                    SqlParameter ResultP = new SqlParameter
                    {
                        ParameterName = "@result",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Value = result,
                        Direction = System.Data.ParameterDirection.Output,

                    };
                    cmd.Parameters.Add(ResultP);
                    cmd.ExecuteNonQuery();

                    result = (int)cmd.Parameters["@result"].Value;
                    return result;
                }
            }
        }

    }
}
