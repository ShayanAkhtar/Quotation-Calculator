using Microsoft.Data.SqlClient;
using System.Data;
using ClassLibraryModel;

namespace ClassLibraryDal
{
    public class DalUserDetails
    {
        public static void Signup_User(UserDetails model)
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("Signup_User", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FullName", model.FullName);
            cmd.Parameters.AddWithValue("@EmailAddress", model.EmailAddress);
            cmd.Parameters.AddWithValue("@Pass", model.Pass);
            cmd.Parameters.AddWithValue("@Role", model.Role);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static UserDetails Login_User(string emailAddress, string pass)
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("Login_User",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmailAddress", emailAddress);
            cmd.Parameters.AddWithValue("@Pass", pass);
            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                UserDetails user = new UserDetails
                {
                    FullName = reader["Fullname"].ToString(),
                    EmailAddress = reader["EmailAddress"].ToString(),
                    Role = reader["Role"].ToString()
                };
                conn.Close();
                return user;
            }
            else
            {
                conn.Close ();  
                return null;
            } 
        }

    }
}
