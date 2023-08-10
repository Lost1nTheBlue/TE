using Forgings_calculation.Models;

namespace Forgings_calculation.Calculaiting
{
    public class HeightClass
    {
        public int Height_Det(DataModel Data ) 
        {
            return Data.Height*Data.Amount_Det+Data.Amount_Slice*Data.Length_Slice;
        }
        public int Height_Det_Prob(DataModel Data) 
        {
            return Data.Height * Data.Amount_Det + Data.Amount_Slice * Data.Length_Slice + Data.Allowance_For_Content;
        }
    }
}
