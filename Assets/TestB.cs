using UnityEngine;

public class TestB : ITestB
{
    ITestA _testA;

    public TestB(ITestA testA)
    {
        _testA = testA;
    }
}

public interface ITestB
{
    void B()
    {
        Debug.Log("Hello");
    }
}