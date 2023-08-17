using Forgings_calculation.Calculaiting;
using Forgings_calculation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Forgings_calculation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Result(DataModel Data)
        {
            if (ModelState.IsValid)
            {
                Conditions conditions = new Conditions();
                int False_condition = conditions.Conditions_Complite(Data);

                if (False_condition == 0)
                {
                    DiametrClass1 diametrClass1 = new DiametrClass1();
                    HoleClass1 holeClass1 = new HoleClass1();
                    WeightClass1 weightClass1 = new WeightClass1();
                    HeightClass heightClass = new HeightClass();

                    int height1 = heightClass.Height_Det(Data) + diametrClass1.Error_Size(Data, heightClass.Height_Det(Data)) + Data.Allowance_For_SizeH;
                    int height1AFC = heightClass.Height_Det_Prob(Data) + diametrClass1.Error_Size(Data, heightClass.Height_Det_Prob(Data)) + Data.Allowance_For_SizeH;
                    int height2 = height1 + diametrClass1.Limit_Size(Data, heightClass.Height_Det(Data));
                    int height2AFC = height1AFC + diametrClass1.Limit_Size(Data, heightClass.Height_Det_Prob(Data));

                    int diametr1 = Data.Diameter + diametrClass1.Error_Size(Data, heightClass.Height_Det(Data)) + Data.Allowance_For_SizeD;
                    int diametr2 = Data.Diameter + diametrClass1.Error_Size(Data, heightClass.Height_Det_Prob(Data)) + diametrClass1.Limit_Size(Data, heightClass.Height_Det_Prob(Data)) + Data.Allowance_For_SizeD;

                    double weight1;
                    double weight2;
                    double weight1AFC;
                    double weight2AFC;

                    int hole_diametr1 = 0;
                    int hole_diametr2 = 0;

                    if (Data.Hole_Diameter != 0)
                    {
                        hole_diametr1 = Data.Hole_Diameter - holeClass1.Error_Size(Data, heightClass.Height_Det(Data)) + Data.Allowance_For_SizeDh;
                        hole_diametr2 = Data.Hole_Diameter - holeClass1.Error_Size(Data, heightClass.Height_Det_Prob(Data)) - holeClass1.Error_Size(Data, heightClass.Height_Det_Prob(Data)) / 3 + Data.Allowance_For_SizeDh;
                        weight1 = weightClass1.Weight(height1, diametr1, hole_diametr1);
                        weight2 = weightClass1.Weight(height2, diametr2, hole_diametr2);
                        weight1AFC = weightClass1.Weight(height1AFC, diametr1, hole_diametr1);
                        weight2AFC = weightClass1.Weight(height2AFC, diametr2, hole_diametr2);

                    }
                    else
                    {
                        weight1 = weightClass1.Weight_Disc(height1, diametr1);
                        weight2 = weightClass1.Weight_Disc(height2, diametr2);
                        weight1AFC = weightClass1.Weight_Disc(height1AFC, diametr1);
                        weight2AFC = weightClass1.Weight_Disc(height2AFC, diametr2);

                    }

                    ViewData["Height1"] = height1;
                    ViewData["Height1_LS"] = diametrClass1.Limit_Size(Data, heightClass.Height_Det(Data));
                    ViewData["Height1AFC"] = height1AFC;
                    ViewData["Height1AFC_LS"] = diametrClass1.Limit_Size(Data, heightClass.Height_Det_Prob(Data));
                    ViewData["Height2AFC"] = height2AFC;
                    ViewData["Diametr1"] = diametr1;
                    ViewData["Diametr1_LS"] = diametrClass1.Limit_Size(Data, heightClass.Height_Det(Data));
                    ViewData["Diametr2"] = diametr2;
                    ViewData["Weight1"] = Math.Round(weight1, 2, MidpointRounding.AwayFromZero);
                    ViewData["Weight2"] = Math.Round(weight2, 2, MidpointRounding.AwayFromZero);
                    ViewData["Weight1AFC"] = Math.Round(weight1AFC, 2, MidpointRounding.AwayFromZero);
                    ViewData["Weight2AFC"] = Math.Round(weight2AFC, 2, MidpointRounding.AwayFromZero);
                    ViewData["DiametrHole1"] = hole_diametr1;
                    ViewData["DiametrHole1_LS"] = holeClass1.Error_Size(Data, heightClass.Height_Det(Data)) / 3;
                    ViewData["DiametrHole2"] = hole_diametr2;
                }

                else
                {
                    DiametrClass1 diametrClass1 = new DiametrClass1();
                    HoleClass1 holeClass1 = new HoleClass1();
                    WeightClass1 weightClass1 = new WeightClass1();
                    HeightClass heightClass = new HeightClass();
                    DiametrHoleClass2 diametrHoleClass2 = new DiametrHoleClass2();

                    int height1 = heightClass.Height_Det(Data) + diametrClass1.Error_Size(Data, heightClass.Height_Det(Data)) + Data.Allowance_For_SizeH;
                    int height1AFC = heightClass.Height_Det_Prob(Data) + diametrClass1.Error_Size(Data, heightClass.Height_Det_Prob(Data)) + Data.Allowance_For_SizeH;
                    int height2 = height1 + diametrClass1.Limit_Size(Data, heightClass.Height_Det(Data));
                    int height2AFC = height1AFC + diametrClass1.Limit_Size(Data, heightClass.Height_Det_Prob(Data));

                    int diametr1 = Data.Diameter + diametrClass1.Error_Size(Data, heightClass.Height_Det(Data)) + Data.Allowance_For_SizeD;
                    int diametr2 = Data.Diameter + diametrClass1.Error_Size(Data, heightClass.Height_Det_Prob(Data)) + diametrClass1.Limit_Size(Data, heightClass.Height_Det_Prob(Data)) + Data.Allowance_For_SizeD;

                    double weight1;
                    double weight2;
                    double weight1AFC;
                    double weight2AFC;


                    int hole_diametr1 = 0;
                    double hole_diametr2 = 0;

                    if (Data.Hole_Diameter != 0)
                    {
                        hole_diametr1 = diametrHoleClass2.Hole_Diametr(Data) + Data.Allowance_For_SizeDh;
                        hole_diametr2 = hole_diametr1 - diametrHoleClass2.Dopusk(diametrHoleClass2.Pripusk(hole_diametr1, Data.Hole_Diameter)) + Data.Allowance_For_SizeDh;
                        weight1 = weightClass1.Weight(height1, diametr1, hole_diametr1);
                        weight2 = weightClass1.Weight(height2, diametr2, hole_diametr2);
                        weight1AFC = weightClass1.Weight(height1AFC, diametr1, hole_diametr1);
                        weight2AFC = weightClass1.Weight(height2AFC, diametr2, hole_diametr2);
                    }
                    else
                    {
                        weight1 = weightClass1.Weight_Disc(height1, diametr1);
                        weight2 = weightClass1.Weight_Disc(height2, diametr2);
                        weight1AFC = weightClass1.Weight_Disc(height1AFC, diametr1);
                        weight2AFC = weightClass1.Weight_Disc(height2AFC, diametr2);
                    }

                    ViewData["Height1"] = height1;
                    ViewData["Height1_LS"] = diametrClass1.Limit_Size(Data, heightClass.Height_Det(Data));
                    ViewData["Height2AFC"] = height2AFC;
                    ViewData["Height1AFC"] = height1AFC;
                    ViewData["Height1AFC_LS"] = diametrClass1.Limit_Size(Data, heightClass.Height_Det_Prob(Data));
                    ViewData["Diametr1_LS"] = diametrClass1.Limit_Size(Data, heightClass.Height_Det(Data));
                    ViewData["Diametr1"] = diametr1;
                    ViewData["Diametr2"] = diametr2;
                    ViewData["Weight1"] = Math.Round(weight1, 2, MidpointRounding.AwayFromZero);
                    ViewData["Weight2"] = Math.Round(weight2, 2, MidpointRounding.AwayFromZero);
                    ViewData["Weight1AFC"] = Math.Round(weight1AFC, 2, MidpointRounding.AwayFromZero);
                    ViewData["Weight2AFC"] = Math.Round(weight2AFC, 2, MidpointRounding.AwayFromZero);
                    ViewData["DiametrHole1"] = hole_diametr1;
                    ViewData["DiametrHole1_LS"] = diametrHoleClass2.Pripusk(hole_diametr1, Data.Hole_Diameter);
                    ViewData["DiametrHole2"] = hole_diametr2;

                }

                if (Data.Hole_Diameter != 0)
                    return View();
                else return View("Result_No_Hole");
            }

            return View("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}