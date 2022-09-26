using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class OrderControl : MonoBehaviour, IOrderControl
{
    // íçï∂
    private List<int> _order;

    private void OnEnable()
    {
        if (!ServiceLocator<IOrderControl>.IsValid)
        {
            ServiceLocator<IOrderControl>.Regist(this);
        }
    }

    private void OnDisable()
    {
        if (ServiceLocator<IOrderControl>.IsValid)
        {
            ServiceLocator<IOrderControl>.UnRegist(this);
        }
    }

    void IOrderControl.CreateOrder(int tileCount)
    {
        for (int i = 0; i < tileCount; i++)
        {
            var item = Range(0, tileCount);
            _order.Add(item);
        }
    }

    List<int> IOrderControl.GetOrder()
    {
        return _order;
    }
}