using LevSundt.Bmi.Application.Commands;
using LevSundt.Bmi.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt_Semesterprojekt.Pages.Bmi
{
    public class EditModel : PageModel
    {
        private readonly IEditBmiCommand _command;
        private readonly IBmiGetQuery _query;

        public EditModel(IEditBmiCommand command, IBmiGetQuery query)
        {
            _command = command;
            _query = query;
        }
        
        [BindProperty]
        public BmiEditViewModel BmiModel { get; set; }
        
        public IActionResult OnGet(int? id , string? userID)
        {
            if (id == null) return NotFound();
            var dto = _query.Get(id.Value, userID);

            BmiModel = new BmiEditViewModel { Height = dto.Height, Weight = dto.Weight, Id = dto.Id, RowVersion = dto.RowVersion };

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) return Page();

            _command.Edit(new BmiEditRequestDto { Height = BmiModel.Height, Weight = BmiModel.Weight, Id = BmiModel.Id, RowVersion = BmiModel.RowVersion });

            return RedirectToPage("./Index");
        }
    }
}
