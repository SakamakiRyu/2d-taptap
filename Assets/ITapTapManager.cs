using System.Collections.Generic;

public interface ITapTapManager
{
    /// <summary>
    /// 注文を取得
    /// </summary>
    List<int> GetTapOrder();

    /// <summary>
    /// 注文の発行をリクエストする
    /// </summary>
    void RequestCreateTapOrder();
}