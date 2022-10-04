using LevSundt.Bmi.Application.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt_Semesterprojekt.Pages.Bmi
{
    public class CreateModel : PageModel
    {
        private readonly ICreateBmiCommand _createBmiCommand;
        public CreateModel(ICreateBmiCommand createBmiCommand)
        {
            _createBmiCommand = createBmiCommand;
        }

        [BindProperty]
        public BmiCreateViewModel BmiModel { get; set; } = new();

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var dto = new BmiCreateRequestDto { Height = BmiModel.Height.Value, Weight = BmiModel.Weight.Value };
            _createBmiCommand.Create(dto);


            return new RedirectToPageResult("/Bmi/Index");
        }
    }
}
