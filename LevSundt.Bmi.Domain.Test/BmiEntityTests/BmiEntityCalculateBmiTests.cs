using LevSundt.Bmi.Domain.Model;
using LevSundt.Bmi.Domain.Model.DomainServices;
using Moq;

namespace LevSundt.Bmi.Domain.Test.BmiEntityTests;

public class BmiEntityCalculateBmiTests
{
    [Theory]
    [InlineData(200, 100, 25)]
    [InlineData(190, 90, 24.9)]
    public void Given_Height_And_Weight__The_Bmi_Is_Calculated_Correct(double height, double weight, double expected)
    {
        //Arrange
        var mock = new Mock<IBmiDomainService>();
        var sut = new BmiEntityTest(mock.Object, height, weight);

        //Act
        sut.CalculateBmi();

        //Assert
        Assert.Equal(expected, Math.Round(sut.Bmi, 1));
    }

    public class BmiEntityTest : BmiEntity
    {
        public BmiEntityTest(IBmiDomainService domainService, double height, double weight) : base(domainService, height, weight,  String.Empty)
        {
        }

        public new void CalculateBmi()
        {
            base.CalculateBmi();
        }
    }
}