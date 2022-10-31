//using LevSundt.Bmi.Application.Commands;
//using LevSundt.Bmi.Application.Queries;
//using LevSundt_Semesterprojekt.Pages.Coach;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Metadata;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace levsundt.api.Controllers
//{

//    [Route("api/[controller]")]
//    [ApiController]
//    public class Coach : ControllerBase
//    {
//        private readonly CoachIndexVeiwModel _CoachIndexVeiwModel;
//        private readonly ICreateBmiCommand _createBmiCommand;
//        private readonly IEditBmiCommand _editBmicommand;

//        // constructor
//        public List<CoachIndexVeiwModel> Users { get; set; } = new();
//        public Coach(CoachIndexVeiwModel CoachIndexVeiwModel, ICreateBmiCommand createBmiCommand, IEditBmiCommand editBmicommand)
//        {
//            _CoachIndexVeiwModel = CoachIndexVeiwModel;
//            _createBmiCommand = createBmiCommand;
//            _editBmicommand = editBmicommand;
//        }
//        // GET: api/<Bmi>
//        [HttpGet("{UserId}")]
//        public IEnumerable<BmiQueryResultDto> Get(string UserId)
//        {
//            var users = from user in _userDb.Users
//                join claims in _userDb.UserClaims
//                    on user.Id equals claims.UserId
//                    into userClaimsGroup
//                from claim in userClaimsGroup.DefaultIfEmpty()
//                where claim.ClaimValue == null || claim.ClaimType != "Coach"
//                select new CoachIndexVeiwModel { UserId = user.UserName };

//            Users.AddRange(users);
//        }


//        // POST api/<Bmi>
//        [HttpPost]
//        public void Post([FromBody] BmiCreateRequestDto request)
//        {
//            _createBmiCommand.Create(request);
//        }

//        // PUT api/<Bmi>/5
//        [HttpPut("{UserId}")]
//        public void Put([FromBody] BmiEditRequestDto request)
//        {

//            _editBmicommand.Edit(request);

//        }

//        // DELETE api/<Bmi>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}