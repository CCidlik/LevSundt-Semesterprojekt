
using LevSundt_Semesterprojekt.Infrastructure.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BmiCreateRequestDto = LevSundt_Semesterprojekt.Infrastructure.Contact.Dto.BmiCreateRequestDto;

namespace LevSundt_Semesterprojekt.Pages.Bmi
{
    public class CreateModel : PageModel
    {
        private readonly ILevSundtService _LevSundtService;
        public CreateModel(ILevSundtService levSundtService)
        {

            _LevSundtService = levSundtService;
        }

        [BindProperty]
        public BmiCreateViewModel BmiModel { get; set; } = new();

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var dto = new BmiCreateRequestDto { Height = BmiModel.Height.Value, Weight = BmiModel.Weight.Value,UserId  = User.Identity?.Name ?? String.Empty };
            await _LevSundtService.Create(dto);


            return new RedirectToPageResult("/Bmi/Index");
        }
    }
}
