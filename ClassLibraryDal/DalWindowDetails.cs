using ClassLibraryModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDal
{
    public class DalWindowDetails
    {
        public static void AddWindowDetails(WindowDetails model)
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("AddWindowDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Type", model.Type);
            cmd.Parameters.AddWithValue("@Rate", model.Rate);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public static List<WindowDetails> GetAllWindowDetails()
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            List<WindowDetails> data = new List<WindowDetails>();
            SqlCommand cmd = new SqlCommand("GetAllWindowDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                WindowDetails windowDetails = new WindowDetails
                {
                    WindowsId = Convert.ToInt32(reader["WindowsId"]),
                    Type = reader["Type"].ToString(),
                    Rate = Convert.ToSingle(reader["Rate"]),
                };
                data.Add(windowDetails);
            }
            return data;
        }
        public static void DeleteWindowDetail(WindowDetails model)
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DeleteWindowDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@WindowsId", model.WindowsId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
