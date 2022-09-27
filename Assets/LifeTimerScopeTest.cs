using VContainer;
using VContainer.Unity;

public class LifeTimerScopeTest : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ITestA, TestA>(Lifetime.Singleton);
        builder.Register<ITestB, TestB>(Lifetime.Singleton);


    }
}