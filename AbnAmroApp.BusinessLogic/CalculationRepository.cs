using System.Data;
using System.Data.SqlClient;

namespace AbnAmroApp.BusinessLogic
{
    public class CalculationRepository
    {
        public List<string> Calculate()
        {
            var result = new List<string>();

            try
            {
                string connectionString = "Data Source=DESKTOP-N5EE6BT\\SQLEXPRESS;Initial Catalog=AbnAmroDemoDb;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand
                    {
                        Connection = connection,
                        CommandType = CommandType.Text,
                        CommandText = "SELECT * FROM [dbo].fnCalculateAll('John', 'Doe')"
                    };

                    connection.Open();
                    SqlDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(reader[0].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
