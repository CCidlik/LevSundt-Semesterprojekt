
using LevSundt_Semesterprojekt.Infrastructure.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt_Semesterprojekt.Pages.Bmi;

public class IndexModel : PageModel
{
    private readonly ILevSundtService _LevSundtService;

    public IndexModel(ILevSundtService levSundtService)
    {

        _LevSundtService = levSundtService;
    }

    [BindProperty] public List<BmiIndexViewModel> IndexViewModel { get; set; } = new();

    public async Task OnGet()
    {
        var businessModel = await _LevSundtService.GetAll(User.Identity?.Name ?? String.Empty);
        
        //foreach (var dto in businessModel)
        //{
        //    IndexViewModel.Add(new BmiIndexViewModel { Bmi = dto.Bmi, Weight = dto.Weight, Height = dto.Height, Id = dto.Id });
        //}

        businessModel.ToList().ForEach(dto => IndexViewModel.Add(new BmiIndexViewModel { Date = dto.Date, Bmi = dto.Bmi, Weight = dto.Weight, Height = dto.Height, Id = dto.Id }));
    }
}