using UnityEngine;
using VContainer;
using VContainer.Unity;

internal class BuilderTest : MonoBehaviour
{
    private IObjectResolver _resolver;

    private void Start()
    {
        var builder = new ContainerBuilder();
        builder.Register<ITestA, TestA>(Lifetime.Singleton);
        builder.Register<ITestB, TestB>(Lifetime.Singleton);
        builder.RegisterEntryPoint<EntryPointTest>(Lifetime.Singleton);

        var resolver = builder.Build();
        _resolver = resolver;

        var service = resolver.Resolve<ITestB>();
        service.B();
    }
}