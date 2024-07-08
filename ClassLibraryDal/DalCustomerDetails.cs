using ClassLibraryModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDal
{
    public class DalCustomerDetails
    {
        public static List<CustomerDetails> GetAllCustomerDetails()
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            List<CustomerDetails> data = new List<CustomerDetails>();
            SqlCommand cmd = new SqlCommand("GetAllCustomerDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CustomerDetails customerDetails = new CustomerDetails
                {
                    CustomerName = reader["CustomerName"].ToString(),
                    Address = reader["Address"].ToString(),
                    MobileNumber = Convert.ToInt64(reader["MobileNumber"])
                };
                data.Add(customerDetails);
            }

            conn.Close(); 
            return data;
        }

    }
}
