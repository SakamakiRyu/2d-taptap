using UnityEngine;
using VContainer.Unity;

public class EntryPointTest : IInitializable
{
    private ITestB _testB;

    public EntryPointTest(ITestB testB)
    {
        _testB = testB;
    }

    public void Initialize()
    {
        Debug.Log("Hello");
    }
}