using LevSundt.Bmi.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt_Semesterprojekt.Pages.Bmi;

public class IndexModel : PageModel
{
    private readonly IBmiGetAllQuery _bmiGetAllQuery;

    public IndexModel(IBmiGetAllQuery bmiGetAllQuery)
    {
        _bmiGetAllQuery = bmiGetAllQuery;
    }

    [BindProperty] public List<BmiIndexViewModel> IndexViewModel { get; set; } = new();

    public void OnGet(string userId)
    {
        var businessModel = _bmiGetAllQuery.GetAll(userId);
        
        //foreach (var dto in businessModel)
        //{
        //    IndexViewModel.Add(new BmiIndexViewModel { Bmi = dto.Bmi, Weight = dto.Weight, Height = dto.Height, Id = dto.Id });
        //}

        businessModel.ToList().ForEach(dto => IndexViewModel.Add(new BmiIndexViewModel { Date = dto.Date, Bmi = dto.Bmi, Weight = dto.Weight, Height = dto.Height, Id = dto.Id }));
    }
}