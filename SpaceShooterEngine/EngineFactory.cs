namespace SpaceShooterEngine;

public class EngineFactory
{
    public IMainEngine GetMainEngine()
    {
        return new MainEngine();
    }
}
