using LevSundt.Bmi.Application.Queries;
using Microsoft.AspNetCore.Mvc;


namespace LevSundt.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {
        private readonly IBmiGetAllQuery _bmiGetAllQuery;

        public CoachController(IBmiGetAllQuery bmiGetAllQuery)
        {
            _bmiGetAllQuery = bmiGetAllQuery;
        }

        [HttpGet("User/{UserId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<BmiQueryResultDto>> Get(string UserId)
        {
            var result = _bmiGetAllQuery.GetAll(UserId).ToList();
            if (!result.Any())
                return NotFound();

            return result.ToList();
        }
    }
}
