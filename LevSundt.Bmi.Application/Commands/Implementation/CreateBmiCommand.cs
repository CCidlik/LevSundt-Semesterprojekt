using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.Model;
using LevSundt.Bmi.Domain.Model.DomainServices;

namespace LevSundt.Bmi.Application.Commands.Implementation;

public class CreateBmiCommand : ICreateBmiCommand
{
    private readonly IBmiRepository _bmiRepository;
    private readonly IBmiDomainService _domainService;

    public CreateBmiCommand(IBmiRepository bmiRepository, IBmiDomainService domainService)
    {
        _bmiRepository = bmiRepository;
        _domainService = domainService;
    }

    void ICreateBmiCommand.Create(BmiCreateRequestDto bmiCreateRequestDto)
    {
        var bmi = new BmiEntity(_domainService, bmiCreateRequestDto.Height, bmiCreateRequestDto.Weight);
        _bmiRepository.Add(bmi);
    }
}