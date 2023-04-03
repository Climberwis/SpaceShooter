namespace SpaceShooterEngineTests;

public class EngineFactorySpecificaiton
{
    private EngineFactory engineFactory;

    [SetUp]
    public void Setup()
    {
        engineFactory = new EngineFactory();
    }

    [Test]
    public void ShouldReturnMainEngine()
    {
        // ACT
        var mainEngine = engineFactory.GetMainEngine();
        
        // ASSERT
        Assert.IsNotNull(mainEngine);
    }
}