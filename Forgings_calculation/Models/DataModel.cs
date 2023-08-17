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

        [Display(Name = "Введите количество деталей в поковке")]
        [Required(ErrorMessage = "Вам нужно ввести количество деталей в поковке")]
        public int Amount_Det { get; set; }

        [Display(Name = "Введите  длину реза")]
        [Required(ErrorMessage = "Вам нужно ввести длину реза")]
        public int Length_Slice { get; set; }

        [Display(Name = "Введите  количество резов")]
        [Required(ErrorMessage = "Вам нужно ввести количество резов")]
        public int Amount_Slice { get; set; }

        [Display(Name = "Введите напуск на пробу")]
        [Required(ErrorMessage = "Вам нужно ввести напуск на пробу")]
        public int Allowance_For_Content { get; set; }

        [Display(Name = "Введите напуск на размер высоты")]
        [Required(ErrorMessage = "Вам нужно ввести напуск на размер")]
        public int Allowance_For_SizeH { get; set; }

        [Display(Name = "Введите напуск на размер диаметра")]
        [Required(ErrorMessage = "Вам нужно ввести напуск на размер")]
        public int Allowance_For_SizeD { get; set; }

        [Display(Name = "Введите напуск на размер диаметра отверстия")]
        [Required(ErrorMessage = "Вам нужно ввести напуск на размер")]
        public int Allowance_For_SizeDh { get; set; }
    }
}
