using LevSundt.WebApp.UserContext;
//using LevSundt_Semesterprojekt.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt_Semesterprojekt.Pages.Coach
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _userDb;


        public IndexModel(ApplicationDbContext userDb)
        {
            _userDb = userDb;
        }

        public List<CoachIndexVeiwModel> Users { get; set; } = new();


        public void OnGet()
        {
            var users = from user in _userDb.Users
                join claims in _userDb.UserClaims
                    on user.Id equals claims.UserId
                    into userClaimsGroup
                from claim in userClaimsGroup.DefaultIfEmpty()
                where claim.ClaimValue == null || claim.ClaimType != "Coach"
                select new CoachIndexVeiwModel { UserId = user.UserName };

            Users.AddRange(users);
        }
    }
}
