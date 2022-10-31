using LevSundt.Bmi.Application.Commands;
using LevSundt.Bmi.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace levsundt.api.Controllers
{
   

    [Route("api/[controller]")]
    [ApiController]
    public class Bmi : ControllerBase
    {
        private readonly IBmiGetAllQuery _bmiGetAllQuery;
        private readonly ICreateBmiCommand _createBmiCommand;
        private readonly IEditBmiCommand _editBmicommand;

        // constructor
        public Bmi(IBmiGetAllQuery bmiGetAllQuery, ICreateBmiCommand createBmiCommand, IEditBmiCommand editBmicommand)
        {
            _bmiGetAllQuery = bmiGetAllQuery;
            _createBmiCommand = createBmiCommand;
            _editBmicommand = editBmicommand;
        }
        // GET: api/<Bmi>
        [HttpGet("{UserId}")]
        public IEnumerable<BmiQueryResultDto> Get(string UserId)
        {
            return _bmiGetAllQuery.GetAll(UserId);
        }


        // POST api/<Bmi>
        [HttpPost]
        public void Post([FromBody] BmiCreateRequestDto request)
        {
            _createBmiCommand.Create(request);
        }

        // PUT api/<Bmi>/5
        [HttpPut("{UserId}")]
        public void Put([FromBody] BmiEditRequestDto request)
        {

            _editBmicommand.Edit(request);

        }

        // DELETE api/<Bmi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
