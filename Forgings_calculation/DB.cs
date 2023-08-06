using MySql.Data.MySqlClient;

namespace Forgings_calculation
{
    public class DB
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;port=3306;uid=root;pwd=root;database=errors");

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }

        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
