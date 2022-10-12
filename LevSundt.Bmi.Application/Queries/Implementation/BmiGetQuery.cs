using LevSundt.Bmi.Application.Repositories;

namespace LevSundt.Bmi.Application.Queries.Implementation;

public class BmiGetQuery : IBmiGetQuery
{
    private readonly IBmiRepository _repository;

    public BmiGetQuery(IBmiRepository repository)
    {
        _repository = repository;
    }
    BmiQueryResultDto IBmiGetQuery.Get(int id , string userId)
    {
        return _repository.Get(id, userId);
    }
}