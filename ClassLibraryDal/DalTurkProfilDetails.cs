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
    public class DalTurkProfilDetails
    {
        public static async Task<List<TurkProfilDetails>> GetAllTurkProfilDetails()
        {
            List<TurkProfilDetails> profiles = new List<TurkProfilDetails>();

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
                                TurkProfilDetails profile = new TurkProfilDetails
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
