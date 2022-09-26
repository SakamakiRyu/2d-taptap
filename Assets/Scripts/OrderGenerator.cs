using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

/// <summary>
/// íçï∂ÇçÏê¨Ç∑ÇÈÉNÉâÉX
/// </summary>
public class OrderGenerator : MonoBehaviour, IOrderGenerator
{
    private void OnEnable()
    {
        if (!ServiceLocator<IOrderGenerator>.IsValid)
        {
            ServiceLocator<IOrderGenerator>.Regist(this);
        }
    }

    private void OnDisable()
    {
        if (ServiceLocator<IOrderGenerator>.IsValid)
        {
            ServiceLocator<IOrderGenerator>.UnRegist(this);
        }
    }

    void IOrderGenerator.CreateOrder(int tileCount)
    {
        List<int> order = null;

        for (int i = 0; i < tileCount; i++)
        {
            var item = Range(0, tileCount);
            order.Add(item);
        }
    }
}