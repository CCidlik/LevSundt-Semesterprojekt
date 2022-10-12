namespace LevSundt.Bmi.Domain.Model.DomainServices;

public interface IBmiDomainService
{
    bool BmiExistsOnDate(DateTime date, string userid);
}