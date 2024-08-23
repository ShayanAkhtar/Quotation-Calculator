using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;

namespace ClassLibraryDal
{
    public class DalCrud
    {
        public static async Task Manipulate(string ProcedureName, SqlParameter[] sqlParameters)
        {
            try
            {
                using (SqlConnection con = DbHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(ProcedureName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(sqlParameters);
                        await cmd.ExecuteNonQueryAsync();
                        await con.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
        }
        public static void DeleteData(string ProcedureName, string idParameterName, int id)
        {
            using (SqlConnection con = DbHelper.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(ProcedureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue(idParameterName, id);
                    cmd.ExecuteNonQuery();
                    con.CloseAsync();
                }
            }
        }
        public static async Task<DataTable> ReadSpecificDataTable(string procedureName, SqlParameter[] sqlParameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        await conn.OpenAsync();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(sqlParameters);

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }

                        await conn.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex.Message}");
            }

            return dt;
        }
        public static async Task<DataTable> GetAllRecords(string ProcedureName)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection con = DbHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(ProcedureName, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            sda.Fill(dt);
                        }

                        await con.CloseAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }

            return dt;
        }
        public static List<T> GetData<T>(string procedureName) where T : class, new()
        {
            List<T> data = new List<T>();
            SqlConnection con = DbHelper.GetConnection();
            con.Open();
            SqlCommand cmd = new SqlCommand(procedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            Type tp = typeof(T);
            PropertyInfo[] properties = tp.GetProperties();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                T obj = new T();
                foreach (var property in properties)
                {
                    var name = property.Name;
                    property.SetValue(obj, Convert.ChangeType(reader[$"{name}"], property.PropertyType));
                }
                data.Add(obj);
            }
            con.Close();
            return data;
        }
    }
}