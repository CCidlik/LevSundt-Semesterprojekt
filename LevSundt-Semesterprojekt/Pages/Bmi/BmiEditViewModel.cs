using System.ComponentModel.DataAnnotations;

namespace LevSundt_Semesterprojekt.Pages.Bmi
{
    public class BmiEditViewModel
    {
        //[Required(ErrorMessage = "Felt er tomt")]
        [Range(100, 250, ErrorMessage = "Indtast højde mellem 100 og 250 centimeter")]
        public double Height { get; set; }

        //[Required(ErrorMessage = "Felt er tomt")]
        [Range(40.000, 250.000, ErrorMessage = "Indtast vægt mellem 40 og 250 kg")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Felt er tomt")]
        public int Id { get; set; }
    }
}
