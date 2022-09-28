using LevSundt.Bmi.Application.Queries;
using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Application.Repositories;

public interface IBmiRepository
{
    //Repository's ansvar er at danne og administrere lifecycle for entity objekter
    void Add(BmiEntity bmi);
    int GetNextKey();
    IEnumerable<BmiQueryResultDto> GetAll();
}