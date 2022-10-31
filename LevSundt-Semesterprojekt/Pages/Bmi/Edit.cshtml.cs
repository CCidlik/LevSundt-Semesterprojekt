
using LevSundt_Semesterprojekt.Infrastructure.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BmiEditRequestDto = LevSundt_Semesterprojekt.Infrastructure.Contact.Dto.BmiEditRequestDto;

namespace LevSundt_Semesterprojekt.Pages.Bmi
{
    public class EditModel : PageModel
    {
        private readonly ILevSundtService _LevSundtService;

        public EditModel(ILevSundtService levSundtService)
        {

            _LevSundtService = levSundtService;
        }
        
        [BindProperty]
        public BmiEditViewModel BmiModel { get; set; }
        
        public async Task<IActionResult> OnGet(int? id )
        {
            if (id == null) return NotFound();
            var dto = await _LevSundtService.Get(id.Value, User.Identity?.Name ?? String.Empty);

            BmiModel = new BmiEditViewModel { Height = dto.Height, Weight = dto.Weight, Id = dto.Id, RowVersion = dto.RowVersion };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

           await _LevSundtService.Edit(new BmiEditRequestDto { Height = BmiModel.Height, Weight = BmiModel.Weight, Id = BmiModel.Id, RowVersion = BmiModel.RowVersion, UserId = User.Identity?.Name ?? String.Empty});

            return RedirectToPage("./Index");
        }
    }
}
