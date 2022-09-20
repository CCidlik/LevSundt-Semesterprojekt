using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Domain.Test.BmiEntityTests;

public class BmiEntityCalculateBmiTests
{
    [Theory]
    [InlineData(200, 100, 25)]
    [InlineData(190, 90, 24.9)]
    public void Given_Height_And_Weight__The_Bmi_Is_Calculated_Correct(double height, double weight, double expected)
    {
        //Arrange
        var sut = new BmiEntityTest(height, weight);

        //Act
        sut.CalculateBmi();

        //Assert
        Assert.Equal(expected, Math.Round(sut.Bmi, 1));
    }

    public class BmiEntityTest : BmiEntity
    {
        public BmiEntityTest(double height, double weight) : base(height, weight, 1)
        {
        }

        public new void CalculateBmi()
        {
            base.CalculateBmi();
        }
    }
}