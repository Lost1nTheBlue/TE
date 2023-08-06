using Forgings_calculation.Calculaiting;
using Forgings_calculation.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Forgings_calculation.Controllers
{
    public class ResultController : Controller
    {

        public ViewResult Index(DataModel Data)
        {
            Conditions conditions = new Conditions();
            int False_condition = conditions.Conditions_Complite(Data);

            if (False_condition==0) 
            {
                DiametrClass1 heightClass1 = new DiametrClass1();
                HoleClass1 holeClass1 = new HoleClass1();
                WeightClass1 weightClass1 = new WeightClass1();
                
                int height1 = Data.Height + heightClass1.Error_Size(Data);
                int height2 = height1 + heightClass1.Limit_Size(Data);
                
                int diametr1 = Data.Diameter + heightClass1.Error_Size(Data);
                int diametr2 = diametr1 + heightClass1.Limit_Size(Data);

                double weight1;
                double weight2;
                double weight_wh1;
                double weight_wh2;
                double weight_disc1;
                double weight_disc2;

                int hole_diametr1 = 0;
                int hole_diametr2 = 0;
                
                if (Data.Hole_Diameter != 0)
                {
                    hole_diametr1 = Data.Hole_Diameter - heightClass1.Error_Size(Data);
                    hole_diametr2 = hole_diametr1 - heightClass1.Error_Size(Data) / 3;
                    weight1 = weightClass1.Weight(height1, diametr1, hole_diametr1);
                    weight2 = weightClass1.Weight(height2, diametr2, hole_diametr2);
                    weight_wh1 = weightClass1.Weight_Disc(height1, diametr1);
                    weight_wh2 = weightClass1.Weight_Disc(height2, diametr2);
                    weight_disc1 = weightClass1.Weight_Disc_Hole(height1, diametr1, hole_diametr1);
                    weight_disc2 = weightClass1.Weight_Disc_Hole(height2, diametr2, hole_diametr2);
                }
                else
                {
                    weight1 = weightClass1.Weight_Disc(height1, diametr1);
                    weight2 = weightClass1.Weight_Disc(height2, diametr2);
                    weight_wh1 = weight1;
                    weight_wh2 = weight2;
                    weight_disc1 = weight1;
                    weight_disc2 = weight2;
                }

                ViewData["Height1"] = height1;
                ViewData["Height2"] = height2;
                ViewData["Diametr1"] = diametr1;
                ViewData["Diametr2"] = diametr2;
                ViewData["Weight1"] = weight1;
                ViewData["Weight2"] = weight2;
                ViewData["Weight_wh1"] = weight_wh1;
                ViewData["Weight_wh2"] = weight_wh2;
                ViewData["Weight_Disc1"] = weight_disc1;
                ViewData["Weight_Disc2"] = weight_disc2;
                ViewData["DiametrHole1"] = hole_diametr1;
                ViewData["DiametrHole2"] = hole_diametr2;
            }

            else
            {
                DiametrClass1 heightClass1 = new DiametrClass1();
                HoleClass1 holeClass1 = new HoleClass1();
                WeightClass1 weightClass1 = new WeightClass1();

                int height1 = Data.Height + heightClass1.Error_Size(Data);
                int height2 = height1 + heightClass1.Limit_Size(Data);

                int diametr1 = Data.Diameter + heightClass1.Error_Size(Data);
                int diametr2 = diametr1 + heightClass1.Limit_Size(Data);

                double weight1;
                double weight2;
                double weight_wh1;
                double weight_wh2;
                double weight_disc1;
                double weight_disc2;

                int hole_diametr1 = 0;
                double hole_diametr2 = 0;

                if (Data.Hole_Diameter != 0)
                {
                    DiametrHoleClass2 diametrHoleClass2 = new DiametrHoleClass2();
                    hole_diametr1 = diametrHoleClass2.Hole_Diametr(Data);
                    hole_diametr2 = hole_diametr1 - diametrHoleClass2.Dopusk(diametrHoleClass2.Pripusk(hole_diametr1, Data.Hole_Diameter));
                    weight1 = weightClass1.Weight(height1, diametr1, hole_diametr1);
                    weight2 = weightClass1.Weight(height2, diametr2, hole_diametr2);
                    weight_wh1 = weightClass1.Weight_Disc(height1, diametr1);
                    weight_wh2 = weightClass1.Weight_Disc(height2, diametr2);
                    weight_disc1 = weightClass1.Weight_Disc_Hole(height1, diametr1, hole_diametr1);
                    weight_disc2 = weightClass1.Weight_Disc_Hole(height2, diametr2, hole_diametr2);
                }
                else
                {
                    weight1 = weightClass1.Weight_Disc(height1, diametr1);
                    weight2 = weightClass1.Weight_Disc(height2, diametr2);
                    weight_wh1 = weight1;
                    weight_wh2 = weight2;
                    weight_disc1 = weight1;
                    weight_disc2 = weight2;
                }

                ViewData["Height1"] = height1;
                ViewData["Height2"] = height2;
                ViewData["Diametr1"] = diametr1;
                ViewData["Diametr2"] = diametr2;
                ViewData["Weight1"] = weight1;
                ViewData["Weight2"] = weight2;
                ViewData["Weight_wh1"] = weight_wh1;
                ViewData["Weight_wh2"] = weight_wh2;
                ViewData["Weight_Disc1"] = weight_disc1;
                ViewData["Weight_Disc2"] = weight_disc2;
                ViewData["DiametrHole1"] = hole_diametr1;
                ViewData["DiametrHole2"] = hole_diametr2;

            }

            return View();
        }

    }
}
