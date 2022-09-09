using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using bmi_razor.Pages.bmi;
namespace LevSundt_Semesterprojekt.Pages.Bmi
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public BmiViewModel BmiModel { get; set; } = new();
        public buttonobjecct Buttonalert { get; set; } = new();

        public void OnGet()
        {
        }  
        
        public void OnPost()
        {
        BmiModel.Bmi = BmiModel.Wight / (BmiModel.Hight * BmiModel.Hight)*10000;
            if (BmiModel.Bmi >= 35) { BmiModel.BmiCategori = "Du er Fedmeklasse 2";
                Buttonalert.AlertButtonhidden = "";

                Buttonalert.AlertArticalCss = "alert alert-danger alert-dismissible";
                Buttonalert.AlertButtonCss = "btn-close";
                Buttonalert.AlertPText = "du burde kontakte lægen";
                Buttonalert.AlertStrongText = "Du er fedme klasse 2 ";
            }
            if (BmiModel.Bmi >= 30 && BmiModel.Bmi < 35) { BmiModel.BmiCategori = "Du er Fedmeklasse 1";
                Buttonalert.AlertArticalCss = "alert alert-danger alert-dismissible";
                Buttonalert.AlertButtonCss = "btn-close";
                Buttonalert.AlertPText = "du burde kontakte lægen";
                Buttonalert.AlertStrongText = "Du er fedme klasse 1 ";
            }
            if (BmiModel.Bmi >= 25 && BmiModel.Bmi < 30 ) { BmiModel.BmiCategori = "Du er Overvægtigt";
                Buttonalert.AlertArticalCss = "alert alert-warning alert-dismissible";
                Buttonalert.AlertButtonCss = "btn-close";
                Buttonalert.AlertPText = "du burde overveje og tabe dig lidt";
                Buttonalert.AlertStrongText = "Du er fedme lidt tyk ";
            }
            if (BmiModel.Bmi >= 18.5 && BmiModel.Bmi < 25) { 
                BmiModel.BmiCategori = "Du er Normalvægtig";
                Buttonalert.AlertArticalCss = "alert alert-success alert-dismissible";
                Buttonalert.AlertButtonCss = "btn-close";
                Buttonalert.AlertPText = "tilykke du har fundet balance i livet";
                Buttonalert.AlertStrongText = "du er normalvægtigt ";
            }
            if (BmiModel.Bmi < 18.5 ) { BmiModel.BmiCategori = "Du er Undervægtig";
                Buttonalert.AlertArticalCss = "alert alert-danger alert-dismissible";
                Buttonalert.AlertButtonCss = "btn-close";
                Buttonalert.AlertPText = "du burde overveje og æde noget mad";
                Buttonalert.AlertStrongText = "du er undervægtigt ";
            }

            
        }
    }
}
