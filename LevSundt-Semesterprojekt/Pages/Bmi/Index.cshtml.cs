using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt_Semesterprojekt.Pages.Bmi
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public BmiViewModel BmiModel { get; set; } = new();

      
        public void OnGet()
        {
        }  
        
        public void OnPost()
        {
        BmiModel.Bmi = BmiModel.Wight / (BmiModel.Hight * BmiModel.Hight)*10000;
            if (BmiModel.Bmi >= 35) { BmiModel.BmiCategori = "Du er Fedmeklasse 2"; BmiModel.BmiAlert = "alert alert-danger alert-dismissible"; BmiModel.BmiAlertMessege = "Pas på din vægt";
                BmiModel.DismissAlertBtn = "btn-close"; BmiModel.DismissAlertBtnText = "alert"; BmiModel.DangerTextBtn = "Danger!";
            }
            if (BmiModel.Bmi >= 30 && BmiModel.Bmi < 35) { BmiModel.BmiCategori = "Du er Fedmeklasse 1"; }
            if (BmiModel.Bmi >= 25 && BmiModel.Bmi < 30 ) { BmiModel.BmiCategori = "Du er Overvægtigt"; }
            if (BmiModel.Bmi >= 18.5 && BmiModel.Bmi < 25) { BmiModel.BmiCategori = "Du er Normalvægtig"; }
            if (BmiModel.Bmi < 18.5 ) { BmiModel.BmiCategori = "Du er Undervægtig"; }

            
        }
    }
}
