using LevSundt.Bmi.Application.Queries;
using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.Model;
using LevSundt.SqlServerContext;
using Microsoft.EntityFrameworkCore;

namespace LevSundt.Bmi.Infrastructor.Repositories;

public class BmiRepository : IBmiRepository
{    
    //public static readonly Dictionary<int, BmiEntity> _database = new(); //public fordi der ikke er db på endnu, ellers private
    private readonly LevSundtContext _db;

    public BmiRepository(LevSundtContext db)
    {
        _db = db;
    }

    void IBmiRepository.Add(BmiEntity bmi)
    {
        _db.Add(bmi);
        _db.SaveChanges();        
    }

    IEnumerable<BmiQueryResultDto> IBmiRepository.GetAll()
    {
        foreach (var entity in _db.BmiEntities.AsNoTracking().ToList())
            yield return new BmiQueryResultDto
            {
                Bmi = entity.Bmi,
                Weight = entity.Weight,
                Height = entity.Height,
                Date = entity.Date,
                Id = entity.Id,
                RowVersion = entity.RowVersion,
                UserId = entity.UserId,
            };
    }

    void IBmiRepository.Update(BmiEntity model)
    {
        _db.Update(model);
        _db.SaveChanges();
    }

    BmiEntity IBmiRepository.Load(int id, string userId)
    {
        var dbEntity = _db.BmiEntities.AsNoTracking().FirstOrDefault(a => a.Id == id && a.UserId == userId);
        if (dbEntity == null) throw new Exception("Bmi måling findes ikke i databasen");
        
        return dbEntity;
    }

    BmiQueryResultDto IBmiRepository.Get(int id)
    {

        var dbEntity = _db.BmiEntities.AsNoTracking().FirstOrDefault(a => a.Id == id);
        if (dbEntity == null) throw new Exception("Bmi måling findes ikke i databasen");
        
        return new BmiQueryResultDto
        {
            Bmi = dbEntity.Bmi,
            Weight = dbEntity.Weight,
            Height = dbEntity.Height,
            Date = dbEntity.Date,
            Id = dbEntity.Id,
            RowVersion = dbEntity.RowVersion
        };
    }
}