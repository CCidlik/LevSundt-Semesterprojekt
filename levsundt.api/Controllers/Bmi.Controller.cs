using System.Net.Mime;
using LevSundt.Bmi.Application.Commands;
using LevSundt.Bmi.Application.Queries;
using LevSundt.Bmi.Application.Queries.Implementation;
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
        private readonly IBmiGetQuery _bmiGetQuery;

        // constructor
        public Bmi(IBmiGetAllQuery bmiGetAllQuery, ICreateBmiCommand createBmiCommand, IEditBmiCommand editBmicommand, IBmiGetQuery bmiGetQuery)
        {
            _bmiGetAllQuery = bmiGetAllQuery;
            _createBmiCommand = createBmiCommand;
            _editBmicommand = editBmicommand;
            _bmiGetQuery = bmiGetQuery;
        }
        // GET: api/<Bmi>
        [HttpGet("{UserId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<BmiQueryResultDto>> Get(string UserId)
        {
            var result = _bmiGetAllQuery.GetAll(UserId).ToList();
            if (!result.Any())
            
                return NotFound();

            return result.ToList();
            
        }

        // GET: api/<Bmi>
        [HttpGet("{id}/{UserId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BmiQueryResultDto> Get(int id , string UserId)
        {
            var result = _bmiGetQuery.Get(id,UserId);


            return result;

        }

        // POST api/<Bmi>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Post(BmiCreateRequestDto request)
        {
            try
            {
                _createBmiCommand.Create(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
             
            }
            
        }

        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put([FromBody] BmiEditRequestDto request)
        {
            try
            {
                _editBmicommand.Edit(request);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            
            }
            

        }

        // DELETE api/<Bmi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
