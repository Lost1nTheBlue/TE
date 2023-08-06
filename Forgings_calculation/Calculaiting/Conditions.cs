using Forgings_calculation.Models;

namespace Forgings_calculation.Calculaiting
{
    public class Conditions
    {
        public int Conditions_Complite(DataModel Data)
        {
            int False_condition=0;
            int diametr = Data.Diameter;
            int height = Data.Height;
            int hole_diametr = Data.Hole_Diameter;

            if (0.2*diametr > height)
            {
                False_condition++;
            }

            if (1.2 * diametr <= height)
            {
                False_condition++;
            }

            if (0.5* diametr <= hole_diametr)
            {
                False_condition++;
            }

            return False_condition;
        }
    }
}
