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
    public class DalSkyPenDetails
    {
        public static async Task<List<SkyPenDetails>> GetAllSkyPenDetails()
        {
            List<SkyPenDetails> profiles = new List<SkyPenDetails>();

            try
            {
                using (SqlConnection con = DbHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("GetAllSkyPenDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                SkyPenDetails profile = new SkyPenDetails
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    ProfileCode = Convert.ToSingle(reader["ProfileCode"]),
                                    ProfileFunction = reader["ProfileFunction"].ToString(),
                                    WhiteWithoutGasket = Convert.ToSingle(reader["WhiteWithoutGasket"]),
                                    WhiteWithCoexGasket = Convert.ToSingle(reader["WhiteWithCoexGasket"]),
                                    WhiteWithTPVGasket = Convert.ToSingle(reader["WhiteWithTPVGasket"]),
                                    TBAndTDOWithTPVGasket = Convert.ToSingle(reader["TBAndTDOWithTPVGasket"])
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
