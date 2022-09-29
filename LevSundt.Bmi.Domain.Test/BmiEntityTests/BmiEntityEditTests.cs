using LevSundt.Bmi.Domain.Model;
using LevSundt.Bmi.Domain.Model.DomainServices;
using Moq;

namespace LevSundt.Bmi.Domain.Test.BmiEntityTests;

public class BmiEntityEditTests
{
    /// <summary>
    ///     Acceptabel højde er [100; 250]
    ///     Acceptabel vægt er [40,0; 250,0]
    /// </summary>
    [Theory]
    [InlineData(190, 90, 24.9)]
    [InlineData(100, 100, 100)]
    [InlineData(250, 100, 16)]
    public void Given_Height_Is_Valid__Then_BmiEntity_Is_Updated(double height, double weight, double bmi)
    {
        //Arrange
        var mock = new Mock<IBmiDomainService>();
        var sut = new BmiEntity(mock.Object, 180, 80);
        
        //Act
        sut.Edit(weight, height, null);

        //Assert
        Assert.Equal(height, sut.Height);
        Assert.Equal(weight, sut.Weight);
        Assert.Equal(bmi, Math.Round(sut.Bmi, 1));
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
        mock.Setup(m => m.BmiExistsOnDate(It.IsAny<DateTime>())).Returns(false);
        var sut = new BmiEntity(mock.Object, 180, 80);
        
        //Act

        //Assert
        Assert.Throws<ArgumentException>(() => sut.Edit(height, 80, null));
    }

    /// <summary>
    ///     Acceptabel vægt er [40,0; 250,0]
    /// </summary>
    [Theory]
    [InlineData(100, 100, 100)]
    [InlineData(100, 250, 250)]
    [InlineData(100, 40, 40)]
    public void Given_Weight_Is_Valid__Then_BmiEntity_Is_Updated(double height, double weight, double bmi)
    {
        //Arrange
        var mock = new Mock<IBmiDomainService>();
        var sut = new BmiEntity(mock.Object, 180, 80);
        
        //Act
        sut.Edit(weight, height, null);

        //Assert
        Assert.Equal(height, sut.Height);
        Assert.Equal(weight, sut.Weight);
        Assert.Equal(bmi, Math.Round(sut.Bmi));
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
        mock.Setup(m => m.BmiExistsOnDate(It.IsAny<DateTime>())).Returns(false);
        var sut = new BmiEntity(mock.Object, 180, 80);

        //Act

        //Assert
        Assert.Throws<ArgumentException>(() => sut.Edit(weight, 80, null));
    }
}