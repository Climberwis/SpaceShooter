using NSubstitute;
using NSubstitute.ReceivedExtensions;
using SpaceShooterEngine.PositionCalculatorLogic;
using SpaceShooterEngine.Resources;
using System.Drawing;

namespace SpaceShooterEngineTests;

internal class PlayerResourceSpecification
{
    [Test]
    public void NewCreatedPlayerShouldNotMoveWhenCallingCalculatePosition()
    {
        // ARRANGE
        var startPosition = Any.Instance<Point>();
        var testPlayerPositionCalculatorLogic = Substitute.For<IPlayerPositionCalculatorLogic>();
        var playerResource = new PlayerResource(testPlayerPositionCalculatorLogic, startPosition);
        testPlayerPositionCalculatorLogic.GetNewPosition(startPosition, PlayerMovement.NO_MOVEMENT).Returns(startPosition);

        // ACT
        playerResource.CalculatePosition();

        // ASSERT
        var calculatedPosition = playerResource.CurrentPosition;

        calculatedPosition.Should().Be(startPosition);
        testPlayerPositionCalculatorLogic.Received(1).GetNewPosition(startPosition, PlayerMovement.NO_MOVEMENT);
    }

    [Test]
    public void PlayerShouldMoveLeftWhenRequested()
    {
        // ARRANGE
        var newTestPosition = Any.Instance<Point>();
        var testPlayerPositionCalculatorLogic = Substitute.For<IPlayerPositionCalculatorLogic>();
        
        var startPosition = Any.Instance<Point>();
        var playerResource = new PlayerResource(testPlayerPositionCalculatorLogic, startPosition);
        testPlayerPositionCalculatorLogic.GetNewPosition(startPosition, PlayerMovement.LEFT).Returns(newTestPosition);
        
        // ACT
        playerResource.MoveLeft();
        playerResource.CalculatePosition();

        // ASSERT
        var calculatedPosition = playerResource.CurrentPosition;

        calculatedPosition.Should().Be(newTestPosition);
        testPlayerPositionCalculatorLogic.Received(1).GetNewPosition(startPosition, PlayerMovement.LEFT);
    }

    [Test]
    public void PlayerShouldMoveRightWhenRequested()
    {
        // ARRANGE
        var newTestPosition = Any.Instance<Point>();
        var testPlayerPositionCalculatorLogic = Substitute.For<IPlayerPositionCalculatorLogic>();

        var startPosition = Any.Instance<Point>();
        var playerResource = new PlayerResource(testPlayerPositionCalculatorLogic, startPosition);
        testPlayerPositionCalculatorLogic.GetNewPosition(startPosition, PlayerMovement.RIGHT).Returns(newTestPosition);

        // ACT
        playerResource.MoveRight();
        playerResource.CalculatePosition();

        // ASSERT
        var calculatedPosition = playerResource.CurrentPosition;

        calculatedPosition.Should().Be(newTestPosition);
        testPlayerPositionCalculatorLogic.Received(1).GetNewPosition(startPosition, PlayerMovement.RIGHT);
    }

    [Test]
    public void PlayerShouldNotMoveWhenStopMovingRequested()
    {
        // ARRANGE
        var newTestPosition = Any.Instance<Point>();
        var testPlayerPositionCalculatorLogic = Substitute.For<IPlayerPositionCalculatorLogic>();

        var startPosition = Any.Instance<Point>();
        var playerResource = new PlayerResource(testPlayerPositionCalculatorLogic, startPosition);
        testPlayerPositionCalculatorLogic.GetNewPosition(startPosition, PlayerMovement.RIGHT).Returns(newTestPosition);
        playerResource.MoveRight();
        playerResource.CalculatePosition();
        testPlayerPositionCalculatorLogic.GetNewPosition(newTestPosition, PlayerMovement.NO_MOVEMENT).Returns(newTestPosition);


        // ACT
        playerResource.StopMoving();
        playerResource.CalculatePosition();

        // ASSERT
        var calculatedPosition = playerResource.CurrentPosition;

        calculatedPosition.Should().Be(newTestPosition);
        testPlayerPositionCalculatorLogic.Received(1).GetNewPosition(startPosition, PlayerMovement.RIGHT);
        testPlayerPositionCalculatorLogic.Received(1).GetNewPosition(newTestPosition, PlayerMovement.NO_MOVEMENT);
    }
}
