using System.Collections.Generic;

internal interface IOrderControl
{
    /// <summary>
    /// 注文の作成
    /// </summary>
    void CreateOrder(int count);

    /// <summary>
    /// 注文の取得
    /// </summary>
    List<int> GetOrder();
}