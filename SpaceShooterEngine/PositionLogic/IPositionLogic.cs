using System.Drawing;

namespace SpaceShooterEngine.PositionLogic;

public interface IPositionLogic
{
    Point CalculatePosition(Point oldPosition);
}
