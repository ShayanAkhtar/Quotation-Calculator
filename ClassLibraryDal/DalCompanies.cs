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
    public class DalCompanies
    {
        public static List<CompanyDetails> GetAllCompaniesDetails()
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            List<CompanyDetails> data = new List<CompanyDetails>();
            SqlCommand cmd = new SqlCommand("GetAllCompanies", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CompanyDetails companyDetails = new CompanyDetails
                {
                    CompanyId = Convert.ToInt32(reader["CompanyId"]),
                    CompanyName = reader["CompanyName"].ToString()
                };
                data.Add(companyDetails);
            }
            conn.Close();
            return data;
        }


    }
}
