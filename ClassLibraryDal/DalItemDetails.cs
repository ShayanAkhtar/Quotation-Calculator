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
    public class DalItemDetails
    {
        public static async Task<List<ItemDetails>> GetItemDetailsByQuotationId(string quotationId)
        {
            List<ItemDetails> items = new List<ItemDetails>();

            try
            {
                using (SqlConnection con = DbHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("GetItemDetailsByQuotationId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@QuotationId", quotationId));

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (reader.Read())
                            {
                                ItemDetails item = new ItemDetails
                                {
                                    ItemId = Convert.ToInt32(reader["ItemId"]),
                                    GId = Convert.ToInt32(reader["GId"]),
                                    QuotationId = reader["QuotationId"].ToString(),
                                    WindowsId = Convert.ToInt32(reader["WindowsId"]),
                                    Width = Convert.ToSingle(reader["Width"]),
                                    Height = Convert.ToSingle(reader["Height"]),
                                    WindowsRate = Convert.ToSingle(reader["WindowsRate"]),
                                    GlassRate = Convert.ToSingle(reader["GlassRate"])
                                };
                                items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }

            return items;
        }

    }
}
