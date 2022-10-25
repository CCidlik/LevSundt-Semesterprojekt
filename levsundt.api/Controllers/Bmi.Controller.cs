using LevSundt.Bmi.Application.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace levsundt.api.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class Bmi : ControllerBase
    {
        private readonly IBmiGetAllQuery _bmiGetAllQuery;

        public Bmi(IBmiGetAllQuery bmiGetAllQuery)
        {
            _bmiGetAllQuery = bmiGetAllQuery;
        }
        // GET: api/<Bmi>
        [HttpGet]
        public IEnumerable<BmiQueryResultDto> Get()
        {
            var businessModel = _bmiGetAllQuery.GetAll(User.Identity?.Name ?? String.Empty);
            return businessModel;
        }

        // GET api/<Bmi>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Bmi>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Bmi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Bmi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
