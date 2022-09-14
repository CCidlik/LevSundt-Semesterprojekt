using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LevSundt_Semesterprojekt.Pages.Bmi
{
    public class BmiViewModel
    {
        [Required (ErrorMessage = "Felt er tomt")]
        [Range (1.00, 2.50, ErrorMessage = "Indtast højde mellem 1,00 og 2,50 meter")]
        public double? Hight { get; set; }

        [Required (ErrorMessage = "Felt er tomt")]
        [Range (40.000, 250.000, ErrorMessage = "Indtast vægt mellem 40 og 250 kg")]
        public double? Wight { get; set; }
        public double? Bmi { get; set; }
        public string? BmiCategori { get; set; }
        
    }
}
