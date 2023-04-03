using NSubstitute;
using SpaceShooterEngine.PositionLogic;
using System.Drawing;

namespace SpaceShooterEngineTests;
internal class PositionCalculatorSpecification
{

    [Test]
    public void ShouldReturnNewPointCalculatedByPositionLogicWhenRequested()
    {
        // ARRANGE
        var testPositionLogic = Substitute.For<IPositionLogic>();
        var _positionCalculator = new PositionCalculator(testPositionLogic);
        var testPosition = Any.Instance<Point>();
        var testReturnPosition = Any.Instance<Point>();
        testPositionLogic.CalculatePosition(testPosition).Returns(testReturnPosition);

        // ACT
        var retVal = _positionCalculator.CalculatePosition(testPosition);

        // ASSERT
        Assert.That(retVal,Is.EqualTo(testReturnPosition));
    }
}
