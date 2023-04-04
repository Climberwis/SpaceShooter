using System.Drawing;

namespace SpaceShooterEngine.PositionCalculatorLogic;

public class PlayerPositionCalculatorLogic
{
    private PositionConfiguration _positionConfiguration;
    private int _speedModifier;

    public PlayerPositionCalculatorLogic(PositionConfiguration positionConfiguration, int speedModifier = 1)
    {
        _positionConfiguration = positionConfiguration;
        _speedModifier = speedModifier;
    }

    public Point GetNewPosition(Point currentPosition, PlayerMovement movement)
    {
        if (movement == PlayerMovement.LEFT && currentPosition.X > _positionConfiguration.MinXPosition)
        {
            var newPosition = Math.Max(_positionConfiguration.MinXPosition, currentPosition.X - _speedModifier);
            return new Point(newPosition, currentPosition.Y);
        }
        else if (movement == PlayerMovement.RIGHT && currentPosition.X < _positionConfiguration.MaxXPosition)
        {
            var newPosition = Math.Min(_positionConfiguration.MaxXPosition, currentPosition.X + _speedModifier);
            return new Point(newPosition, currentPosition.Y);
        }
        return currentPosition;
    }
}
