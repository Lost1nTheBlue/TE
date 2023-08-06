using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Forgings_calculation.Models
{
    public class DataModel
    {
        [Display(Name = "Введите диаметр детали")]
        [Required(ErrorMessage = "Вам нужно ввести диаметр детали")]
        public int Diameter { get; set; }

        [Display(Name = "Введите диаметр отверстия")]
        [Required(ErrorMessage = "Вам нужно ввести диаметр отверстия")]
        public int Hole_Diameter { get; set; }

        [Display(Name = "Введите высоту детали")]
        [Required(ErrorMessage = "Вам нужно ввести высоту детали")]
        public int Height { get; set; }
    }
}
