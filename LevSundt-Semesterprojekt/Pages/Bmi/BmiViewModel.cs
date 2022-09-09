namespace LevSundt_Semesterprojekt.Pages.Bmi
{
    public class BmiViewModel
    {
        public double? Hight { get; set; }
        public double? Wight { get; set; }
        public double? Bmi { get; set; }
        public string? BmiCategori { get; set; }
        public string? BmiAlert { get; set; }
        public string? BmiAlertMessege { get; set; }

        public string? DismissAlertBtn { get; set; }
        public string? DismissAlertBtnText { get; set; }
        public string? DangerTextBtn { get; set; }
    }
}
