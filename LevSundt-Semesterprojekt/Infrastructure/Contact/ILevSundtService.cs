
using BmiCreateRequestDto = LevSundt_Semesterprojekt.Infrastructure.Contact.Dto.BmiCreateRequestDto;
using BmiEditRequestDto = LevSundt_Semesterprojekt.Infrastructure.Contact.Dto.BmiEditRequestDto;
using BmiQueryResultDto = LevSundt_Semesterprojekt.Infrastructure.Contact.Dto.BmiQueryResultDto;

namespace LevSundt_Semesterprojekt.Infrastructure.Contact
{
    public interface ILevSundtService
    {
        Task Create(BmiCreateRequestDto dto);
        Task Edit(BmiEditRequestDto dto);
        Task<BmiQueryResultDto> Get(int id, string identityName);
        Task<IEnumerable<BmiQueryResultDto>> GetAll(string identityName);
    }
}
