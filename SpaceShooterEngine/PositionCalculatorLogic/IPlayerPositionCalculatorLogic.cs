using System.Drawing;
namespace SpaceShooterEngine.PositionCalculatorLogic;

public enum PlayerMovement
{
    NO_MOVEMENT,
    LEFT,
    RIGHT
}

public interface IPlayerPositionCalculatorLogic
{
    public Point GetNewPosition(Point currentPosition, PlayerMovement movement);
}
