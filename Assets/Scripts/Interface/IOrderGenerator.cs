using System.Collections.Generic;

public interface IOrderGenerator
{
    /// <summary>
    /// 注文の作成
    /// </summary>
    List<int> CreateOrder(int count);
}