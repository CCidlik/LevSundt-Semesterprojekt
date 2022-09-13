using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LevSundt_Semesterprojekt.Pages.Bmi
{
    public class BmiViewModel
    {
        [Range(1.00, 2.50)]
        //[DataType(DataType.Custom)]
        public double? Hight { get; set; }

        [Range(40.00, 250.00)]
        //[DataType(DataType.Custom)]
        public double? Wight { get; set; }

        public double? Bmi { get; set; }
        public string? BmiCategori { get; set; }
        
    }
}
