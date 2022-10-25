using LevSundt.Bmi.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt_Semesterprojekt.Pages.Coach
{
    public class DetailsModel : PageModel
    
    {
        private readonly IBmiGetAllQuery _query;
        public DetailsModel(IBmiGetAllQuery query)
        {
            _query = query;
        }

        [BindProperty] public List<CoachDetailsViewModel> DetailsViewModel { get; set; } = new();
        [BindProperty] public string UserName { get; set; } = String.Empty;
        public IActionResult OnGet(string? userId)
        {
            if (string.IsNullOrWhiteSpace(userId)) return NotFound();

            var buissnessModel = _query.GetAll(userId);

            buissnessModel.OrderBy(a => a.Date).ToList().ForEach(dto => DetailsViewModel.Add(new CoachDetailsViewModel()
                {Bmi = dto.Bmi, Weight = dto.Weight, Height = dto.Height, Id = dto.Id, Date = dto.Date }));

            UserName = userId;
            return Page();
        }
    }
}
