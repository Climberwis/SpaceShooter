using SpaceShooterEngine.PositionCalculatorLogic;
using System.Drawing;

namespace SpaceShooterEngineTests;

internal class PlayerPositionCalculatorLogicSpecification
{
    private PositionConfiguration _configuration;
    private PlayerPositionCalculatorLogic _calculator;

    [SetUp]
    public void SetUp()
    {
        _configuration = Any.Instance<PositionConfiguration>();
        _calculator = new PlayerPositionCalculatorLogic(_configuration);
    }

    [Test]
    public void WhenNewPositionCalculatedYValueIsNeverChanged()
    {
        // ARRANGE
        var testPosition = Any.Instance<Point>();
        var movement = Any.Instance<PlayerMovement>();

        // ACT
        var newPosition = _calculator.GetNewPosition(testPosition, movement);

        // ASSERT
        newPosition.Y.Should().Be(testPosition.Y);
    }

    [Test]
    public void ShouldReturnNewPositionToTheLeftOfCurrentPositionWhenMovingLeft()
    {
        // ARRANGE
        var testPosition = new Point(_configuration.MinXPosition + 10, Any.Instance<int>());

        // ACT
        var newPosition = _calculator.GetNewPosition(testPosition, PlayerMovement.LEFT);

        // ASSERT
        newPosition.X.Should().BeLessThan(testPosition.X);
    }

    [Test]
    public void ShouldReturnNewPositionToTheRightOfCurrentPositionWhenMovingRight()
    {
        // ARRANGE
        var testPosition = new Point(_configuration.MaxXPosition -10, Any.Instance<int>());

        // ACT
        var newPosition = _calculator.GetNewPosition(testPosition, PlayerMovement.RIGHT);

        // ASSERT
        newPosition.X.Should().BeGreaterThan(testPosition.X);
    }

    [Test]
    public void ShouldNotExceedMinimumLeftPositionWhenMovingLeft()
    {
        // ARRANGE
        var testPosition = Any.Instance<Point>();
        testPosition.X = _configuration.MinXPosition;

        // ACT
        var newPosition = _calculator.GetNewPosition(testPosition, PlayerMovement.LEFT);

        // ASSERT
        newPosition.X.Should().Be(testPosition.X);
    }

    [Test]
    public void ShouldNotExceedMaximumRightPositionWhenMovingRight()
    {
        // ARRANGE
        var testPosition = Any.Instance<Point>();
        testPosition.X = _configuration.MaxXPosition;

        // ACT
        var newPosition = _calculator.GetNewPosition(testPosition, PlayerMovement.RIGHT);

        // ASSERT
        newPosition.X.Should().Be(testPosition.X);
    }

    [Test]
    public void ShouldMovePlayerWithSpeedModifierWhenMovingRight()
    {
        // ARRANGE
        var configuration = new PositionConfiguration(0, Any.Instance<int>(), 10, Any.Instance<int>());
        int testSpeedModifier = 5;
        var calculator = new PlayerPositionCalculatorLogic(configuration, testSpeedModifier);
        var testCurrentPosition = new Point(0, 0);

        // ACT
        var newPosition = calculator.GetNewPosition(testCurrentPosition, PlayerMovement.RIGHT);

        newPosition.X.Should().Be(testCurrentPosition.X + testSpeedModifier);
    }

    [Test]
    public void ShouldMovePlayerWithSpeedModifierWhenMovingLeft()
    {
        // ARRANGE
        var configuration = new PositionConfiguration(0, Any.Instance<int>(), 10, Any.Instance<int>());
        int testSpeedModifier = 5;
        var calculator = new PlayerPositionCalculatorLogic(configuration, testSpeedModifier);
        var testCurrentPosition = new Point(10, 0);

        // ACT
        var newPosition = calculator.GetNewPosition(testCurrentPosition, PlayerMovement.LEFT);

        newPosition.X.Should().Be(testCurrentPosition.X - testSpeedModifier);
    }

    [Test]
    public void ShouldNotExceedBordersWhenMovingPlayerWithSpeedModifierRight()
    {
        // ARRANGE
        var configuration = new PositionConfiguration(0, Any.Instance<int>(), 10, Any.Instance<int>());
        int testSpeedModifier = 15;
        var calculator = new PlayerPositionCalculatorLogic(configuration, testSpeedModifier);
        var testCurrentPosition = new Point(0, 0);

        // ACT
        var newPosition = calculator.GetNewPosition(testCurrentPosition, PlayerMovement.RIGHT);

        newPosition.X.Should().Be(configuration.MaxXPosition);
    }

    [Test]
    public void ShouldNotExceedBordersWhenMovingPlayerWithSpeedModifierLeft()
    {
        // ARRANGE
        var configuration = new PositionConfiguration(0, Any.Instance<int>(), 10 , Any.Instance<int>());
        int testSpeedModifier = 15;
        var calculator = new PlayerPositionCalculatorLogic(configuration, testSpeedModifier);
        var testCurrentPosition = new Point(10, 0);

        // ACT
        var newPosition = calculator.GetNewPosition(testCurrentPosition, PlayerMovement.LEFT);

        newPosition.X.Should().Be(configuration.MinXPosition);
    }
}
