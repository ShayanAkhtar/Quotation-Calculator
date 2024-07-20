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
    public class DalQuotationsDetails
    {
        public static async Task<List<QuotationDetails>> GetAllQuotations()
        {
            List<QuotationDetails> data = new List<QuotationDetails>();

            try
            {
                using (SqlConnection conn = DbHelper.GetConnection())
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("GetAllQuotations", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader reader = await cmd.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            QuotationDetails quotation = new QuotationDetails
                            {
                                QuotationId = reader["QuotationId"].ToString(),
                                CustomerMobile = Convert.ToInt64(reader["CustomerMobile"]),
                                Date = Convert.ToDateTime(reader["Date"]),
                                Remarks = reader["Remarks"].ToString()
                            };
                            data.Add(quotation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
            return data;
        }
        public static async Task<QuotationDetails> GetQuotationById(string quotationId)
        {
            QuotationDetails quotation = null;

            try
            {
                using (SqlConnection con = DbHelper.GetConnection())
                {
                    await con.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("GetQuotationById", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@QuotationId", quotationId));

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                quotation = new QuotationDetails
                                {
                                    QuotationId = reader["QuotationId"].ToString(),
                                    CustomerMobile = Convert.ToInt64(reader["CustomerMobile"]),
                                    Date = Convert.ToDateTime(reader["Date"]),
                                    Remarks = reader["Remarks"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }

            return quotation;
        }

    }
}
