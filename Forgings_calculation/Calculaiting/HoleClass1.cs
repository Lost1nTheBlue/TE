using Forgings_calculation.Models;
using MySql.Data.MySqlClient;

namespace Forgings_calculation.Calculaiting
{
    public class HoleClass1
    {
        public int Error_Size(DataModel Data)
        {
            DB db = new DB();

            db.openConnection();

            MySqlConnection connection = db.getConnection();

            string height = Data.Height.ToString();
            string diametr = Data.Hole_Diameter.ToString();

            int error;

            string sql = "SELECT `Errors` FROM `errors_and_limit_deviations` WHERE `Height bottom` < @UH AND `Height top` >= @UH AND `Diametr bottom` < @UD AND `Diametr top` >= @UD";

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.Add("@UH", MySqlDbType.VarChar).Value = height;
            command.Parameters.Add("@UD", MySqlDbType.VarChar).Value = diametr;

            MySqlDataReader reader1 = command.ExecuteReader();

            if (reader1.HasRows)
            {
                reader1.Read();
                error = reader1.GetInt32(0);
            }

            else
            {
                error = 0;
            }

            return error;

        }

    }
}
