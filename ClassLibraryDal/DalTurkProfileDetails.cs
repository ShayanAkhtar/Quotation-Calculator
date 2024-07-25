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
    public class DalTurkProfileDetails
    {
        public static async Task<string> AddTurkprofil(TurkProfileDetails model)
        {
            string message;
            using (SqlConnection con = DbHelper.GetConnection())
            {
                await con.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("AddTurkprofil", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProfileCode", model.ProfileCode);
                    cmd.Parameters.AddWithValue("@ProfileFunction", model.ProfileFunction);
                    cmd.Parameters.AddWithValue("@WhiteWithoutGasket", model.WhiteWithoutGasket);
                    cmd.Parameters.AddWithValue("@WhiteWithGasket", model.WhiteWithGasket);
                    cmd.Parameters.AddWithValue("@BlackSolidColor", model.BlackSolidColor);

                    SqlParameter outputParam = new SqlParameter("@Message", SqlDbType.NVarChar, 100)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    await cmd.ExecuteNonQueryAsync();

                    message = outputParam.Value.ToString();
                }
            }
            return message;
        }
        public static async Task<List<TurkProfileDetails>> GetAllTurkProfilDetails()
        {
            List<TurkProfileDetails> profiles = new List<TurkProfileDetails>();

            try
            {
                using (SqlConnection con = DbHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("GetAllTurkProfilDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                TurkProfileDetails profile = new TurkProfileDetails
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    ProfileCode = Convert.ToSingle(reader["ProfileCode"]),
                                    ProfileFunction = reader["ProfileFunction"].ToString(),
                                    WhiteWithoutGasket = Convert.ToSingle(reader["WhiteWithoutGasket"]),
                                    WhiteWithGasket = Convert.ToSingle(reader["WhiteWithGasket"]),
                                    BlackSolidColor = Convert.ToSingle(reader["BlackSolidColor"])
                                };
                                profiles.Add(profile);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }

            return profiles;
        }
    }
    

}
