using MySql.Data.MySqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Forgings_calculation.Calculaiting
{
    public class WeightClass1
    {
        public double Volume(int Height, double Diametr)
        {
            double radius = Diametr / 2;
            return 3.14 * (radius * radius) * Height;
        }

        public double Weight_Disc(int Height, double Diametr)
        {
            double volume = Volume(Height, Diametr);
            return (volume * 0.78) / 100000000;
        }

        public double Weight_Disc_Hole(int Height, int Diametr, double Hole_Diametr)
        {
            return Weight_Disc(Height, Diametr) - Weight_Disc(Height, Hole_Diametr);
        }

        public double Weight(int Height, int Diametr, double Hole_Diametr) 
        {
            double ratio1 = 0;

            if ((Diametr / Height >= 4) || (Diametr > 1200) || (Weight_Disc_Hole(Height, Diametr, Hole_Diametr)>4000))
            {
                DB db = new DB();
                db.openConnection();

                MySqlConnection connection = db.getConnection();

                string ratio = (Diametr / Height).ToString();

                string sql = "SELECT Weight FROM `sphericity` WHERE Ratio_bottom <= @UH AND Ratio_top > @UH";

                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.Add("@UH", MySqlDbType.VarChar).Value = ratio;

                MySqlDataReader reader1 = command.ExecuteReader();

                if (reader1.HasRows)
                {
                    reader1.Read();
                    string str = reader1.GetString(0);
                    ratio1 = Convert.ToDouble(str);
                }
            }
            return Weight_Disc_Hole(Height, Diametr, Hole_Diametr) * (1+ratio1);
        }

    }
}
