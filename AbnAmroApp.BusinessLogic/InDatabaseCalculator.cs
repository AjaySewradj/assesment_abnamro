using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace AbnAmroApp.BusinessLogic
{
    public class InDatabaseCalculator
    {
        private readonly string _connectionString;

        public InDatabaseCalculator()
        {
            // TODO: Should get connectionstring from appsettings
            _connectionString = "Data Source=DESKTOP-N5EE6BT\\SQLEXPRESS;Initial Catalog=AbnAmroDemoDb;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False";
        }

        public List<string> Calculate(string firstName, string lastName)
        {
            return CalculateOnDatabase(firstName, lastName);
        }

        private List<string> CalculateOnDatabase(string firstName, string lastName)
        {
            var result = new List<string>();

            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [dbo].fnCalculateAll(@FirstName, @LastName)", connection);
                sqlCommand.Parameters.AddWithValue("@FirstName", firstName);
                sqlCommand.Parameters.AddWithValue("@LastName", lastName);

                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(reader[0].ToString());
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return result;
        }
    }
}
