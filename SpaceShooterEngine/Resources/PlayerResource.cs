using SpaceShooterEngine.PositionCalculatorLogic;
using System.Drawing;

namespace SpaceShooterEngine.Resources;

public class PlayerResource
{
    private IPlayerPositionCalculatorLogic _playerPositionCalculatorLogic;
    private PlayerMovement _currentMovement = PlayerMovement.NO_MOVEMENT;
    private Point _currentPosition;

    public Point CurrentPosition { get => _currentPosition; }

    public PlayerResource(IPlayerPositionCalculatorLogic playerPositionCalculatorLogic, Point startPosition)
    {
        _playerPositionCalculatorLogic = playerPositionCalculatorLogic;
        _currentPosition = startPosition;
    }

    public void CalculatePosition()
    {
        _currentPosition = _playerPositionCalculatorLogic.GetNewPosition(_currentPosition, _currentMovement);
    }

    public void MoveLeft()
    {
        _currentMovement = PlayerMovement.LEFT;
    }

    public void MoveRight()
    {
        _currentMovement = PlayerMovement.RIGHT;
    }

    public void StopMoving()
    {
        _currentMovement = PlayerMovement.NO_MOVEMENT;
    }
}
