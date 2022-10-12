using LevSundt.Bmi.Application.Queries;
using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Application.Repositories;

public interface IBmiRepository
{
    //Repository's ansvar er at danne og administrere lifecycle for entity objekter
    void Add(BmiEntity bmi);
    IEnumerable<BmiQueryResultDto> GetAll(string userId);
    BmiEntity Load(int id, string userId);
    void Update(BmiEntity model);
    BmiQueryResultDto Get(int id, string userId);
}