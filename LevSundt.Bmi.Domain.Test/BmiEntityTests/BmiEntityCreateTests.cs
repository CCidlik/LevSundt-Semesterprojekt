using LevSundt.Bmi.Domain.Model;
using LevSundt.Bmi.Domain.Model.DomainServices;
using Moq;

namespace LevSundt.Bmi.Domain.Test.BmiEntityTests;

public class BmiEntityCreateTests
{
    /// <summary>
    ///     Acceptabel højde er [100; 250]
    ///     Acceptabel vægt er [40,0; 250,0]
    /// </summary>
    [Theory]
    [InlineData(200)]
    [InlineData(250)]
    [InlineData(100)]
    public void Given_Height_Is_Valid__Then_BmiEntity_Is_Created(double height)
    {
        //Arrange
        var mock = new Mock<IBmiDomainService>();

        //Act
        var sut = new BmiEntity(mock.Object, height, 100, "");

        //Assert
    }

    /// <summary>
    ///     Acceptabel højde er [100; 250]
    ///     Acceptabel vægt er [40,0; 250,0]
    /// </summary>
    [Theory]
    [InlineData(250.01)]
    [InlineData(99.99)]
    public void Given_Height_Is_InValid__Then_ArgumentException_Is_Thrown(double height)
    {
        //Arrange
        var mock = new Mock<IBmiDomainService>();
        mock.Setup(m => m.BmiExistsOnDate(It.IsAny<DateTime>(), "1")).Returns(false);

        //Act

        //Assert
        Assert.Throws<ArgumentException>(() => new BmiEntity(mock.Object, height, 100, ""));
    }

    /// <summary>
    ///     Acceptabel vægt er [40,0; 250,0]
    /// </summary>
    [Theory]
    [InlineData(100)]
    [InlineData(250)]
    [InlineData(40)]
    public void Given_Weight_Is_Valid__Then_BmiEntity_Is_Created(double weight)
    {
        //Arrange
        var mock = new Mock<IBmiDomainService>();

        //Act
        var sut = new BmiEntity(mock.Object, 200, weight, "");
        //Assert
    }

    /// <summary>
    ///     Acceptabel vægt er [40,0; 250,0]
    /// </summary>
    [Theory]
    [InlineData(250.01)]
    [InlineData(39.99)]
    public void Given_Weight_Is_InValid__Then_ArgumentException_Is_Thrown(double weight)
    {
        //Arrange
        var mock = new Mock<IBmiDomainService>();
        mock.Setup(m => m.BmiExistsOnDate(It.IsAny<DateTime>(), "1")).Returns(false);

        //Act

        //Assert
        Assert.Throws<ArgumentException>(() => new BmiEntity(mock.Object, 200, weight, ""));
    }

    [Theory]
    [InlineData(200, 100, 25)]
    [InlineData(190, 90, 24.9)]
    public void Given_Height_And_Weight__The_Bmi_Is_Calculated_Correct(double height, double weight, double expected)
    {
        //Arrange
        var mock = new Mock<IBmiDomainService>();

        //Act
        var sut = new BmiEntity(mock.Object, height, weight, "");

        //Assert
        Assert.Equal(expected, Math.Round(sut.Bmi, 1));
    }

    [Fact]
    public void Given_Date_Is_Valid__Then_BmiEntity_Is_Created()
    {
        //Arrange
        var mock = new Mock<IBmiDomainService>();
        mock.Setup(m => m.BmiExistsOnDate(It.IsAny<DateTime>(), "1")).Returns(false);

        //Act
        var sut = new BmiEntity(mock.Object, 100, 100, "");
        //Assert
    }

    [Fact]
    public void Given_Date_Is_InValid__Then_ArgumentException_Is_Thrown()
    {
        //Arrange
        var mock = new Mock<IBmiDomainService>();
        mock.Setup(m => m.BmiExistsOnDate(It.IsAny<DateTime>(), "1")).Returns(true);

        //Act

        //Assert
        Assert.Throws<ArgumentException>(() => new BmiEntity(mock.Object, 100, 100, "1"));
    }
}