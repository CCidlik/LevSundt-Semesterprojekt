using System.ComponentModel.DataAnnotations;
using LevSundt.Bmi.Domain.Model.DomainServices;

namespace LevSundt.Bmi.Domain.Model;

public class BmiEntity
{
    private readonly IBmiDomainService _domainService;

    // For Entity Framework only!!!
    internal BmiEntity()
    {

    }
    
    public BmiEntity(IBmiDomainService domainService, double height, double weight, string userid ) // Hack for ikke at skulle rette i unit test - Skal rettes senere
    {
        _domainService = domainService;
        //Check pre-condition
        Height = height;
        Weight = weight;
        Date = DateTime.Now;
        UserId = userid;
        if (!IsValid()) throw new ArgumentException("Pre-conditions er ikke overholdt");
        if (_domainService.BmiExistsOnDate(Date.Date, userid)) throw new ArgumentException("Der eksisterer allerede en BMI måling for i dag");

        CalculateBmi();
    }

    public double Height { get; private set; }
    public double Weight { get; private set; }
    public double Bmi { get; private set; }
    public DateTime Date { get; private set; }
    public int Id { get; }
    public string UserId { get; private set; }

    [Timestamp]
    public byte[] RowVersion { get; private set; }
    
    /// <summary>
    /// Acceptabel højde er [100; 250]
    /// Acceptabel vægt er [40,0; 250,0]
    /// </summary>
    protected bool IsValid()
    {
        if (Height < 100) return false;
        if (Height > 250) return false;
        if (Weight < 40) return false;
        if (Weight > 250) return false;

        return true;
    }

    protected void CalculateBmi()
    {
        Bmi = Weight / (Height/100 * Height/100);
    }

    public void Edit(double weight, double height, byte[] rowVersion)
    {
        Height = height;
        Weight = weight;
        RowVersion = rowVersion;

        if (!IsValid()) throw new ArgumentException("Pre-conditions er ikke overholdt");

        CalculateBmi();
    }
}
