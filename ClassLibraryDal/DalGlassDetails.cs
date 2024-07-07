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
    public class DalGlassDetails
    {
        public static void AddGlassDetails(GlassDetails model)
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("AddGlassDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GColor", model.GColor);
            cmd.Parameters.AddWithValue("@Rate", model.Rate);
            cmd.Parameters.AddWithValue("@Thickness", model.Thickness);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public static List<GlassDetails> GetAllGlassDetails()
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            List<GlassDetails> data = new List<GlassDetails>();
            SqlCommand cmd = new SqlCommand("GetAllGlassDetails", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                GlassDetails glassDetails = new GlassDetails
                {
                    GId = Convert.ToInt32(reader["GId"]),
                    GColor = reader["GColor"].ToString(),
                    Rate = Convert.ToSingle(reader["Rate"]),
                    Thickness = Convert.ToSingle(reader["Thickness"])
                };
                data.Add(glassDetails);
            }
            return data;
        }
        public static void DeleteGlassDetails(GlassDetails model)
        {
            SqlConnection conn = DbHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DeleteGlassDetails", conn);
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@GId", model.GId);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    
    }
}
