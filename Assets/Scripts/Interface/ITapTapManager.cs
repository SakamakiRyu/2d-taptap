using System.Collections.Generic;

public interface ITapTapManager
{
    /// <summary>
    /// 注文を取得
    /// </summary>
    public List<int> GetTapOrder();

    /// <summary>
    /// 注文の発行をリクエストする
    /// </summary>
    void RequestCreateOrder();

    /// <summary>
    /// ゲームができるようにする
    /// </summary>
    void RequestStart();
}