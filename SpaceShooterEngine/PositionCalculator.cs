using SpaceShooterEngine.PositionLogic;
using System.Drawing;

namespace SpaceShooterEngine;

public class PositionCalculator
{
    IPositionLogic _positionLogic;
    public PositionCalculator(IPositionLogic positionLogic)
    {
        _positionLogic = positionLogic;
    }
    public Point CalculatePosition(Point currentPosition)
    {
        return _positionLogic.CalculatePosition(currentPosition);
    }
}
