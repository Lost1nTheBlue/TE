using Forgings_calculation.Models;
using MySql.Data.MySqlClient;

namespace Forgings_calculation.Calculaiting
{
    public class DiametrHoleClass2
    {
        public int Hole_Diametr(DataModel Data)
        {
            DB db = new DB();

            db.openConnection();

            MySqlConnection connection = db.getConnection();

            string diametr = Data.Hole_Diameter.ToString();

            int diametr_por;

            string sql = "SELECT Diametr FROM `hole_diametr` WHERE Diametr_min < @UH AND Diametr_max >= @UH";

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.Add("@UH", MySqlDbType.VarChar).Value = diametr;

            MySqlDataReader reader1 = command.ExecuteReader();

            if (reader1.HasRows)
            {
                reader1.Read();
                diametr_por = reader1.GetInt32(0);
            }

            else
            {
                diametr_por = 0;
            }

            return diametr_por;
        }

        public int Pripusk(int diametr_por, int diametr)
        {
            return diametr - diametr_por;
        }

        public double Dopusk(int pripusk)
        {
            return pripusk * 0.6 / 2;
        }
    }
}
