using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

/// <summary>
/// 注文を作成するクラス
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

    List<int> IOrderGenerator.CreateOrder(int tileCount)
    {
        List<int> order = null;

        for (int i = 0; i < tileCount; i++)
        {
            var item = Range(0, tileCount);
            order.Add(item);
        }

        return order;
    }
}