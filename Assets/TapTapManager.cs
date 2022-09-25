using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

/// <summary>
/// ゲームを管理するクラス
/// ※タップの順番を注文と定義する
/// </summary>
public class TapTapManager : MonoBehaviour, ITapTapManager
{
    [SerializeField]
    private int _startedOrderCount;

    // タップする順番
    private List<int> _tapOrder;

    // 現在の注文
    private int _currentTapOrder = 0;

    private int _orderCount { get; set; }

    // タイルの数
    private readonly int TILE_COUNT = 16;

    private void Start()
    {
        _tapOrder = CreateTapOrder(_startedOrderCount);
        _orderCount = _tapOrder.Count;
    }

    private void OnEnable()
    {
        if (!ServiceLocator<ITapTapManager>.IsValid)
        {
            ServiceLocator<ITapTapManager>.Regist(this);
        }
    }

    private void OnDisable()
    {
        if (ServiceLocator<ITapTapManager>.IsValid)
        {
            ServiceLocator<ITapTapManager>.UnRegist(this);
        }
    }

    /// <summary>
    /// 注文を作成
    /// </summary>
    public void RequestCreateTapOrder()
    {
        _tapOrder = CreateTapOrder(_startedOrderCount);
    }

    /// <summary>
    /// タップする順番を作成
    /// </summary>
    private List<int> CreateTapOrder(int count)
    {
        var tapOrder = new List<int>();

        for (int i = 0; i < count; i++)
        {
            var item = Range(0, TILE_COUNT);
            tapOrder.Add(item);
        }

        return tapOrder;
    }

    #region InGame CallBacks
    public void OnEnter(TileController tile)
    {
        tile.ChengeColor(Color.blue);
    }

    public void OnExit(TileController tile)
    {
        tile.ChengeColor(Color.white);
    }

    public void OnClick(TileController tile)
    {
        if (tile.ID == _tapOrder[_currentTapOrder])
        {
            _currentTapOrder++;
            _orderCount--;
            Debug.Log("OK");
        }
        else
        {
            Debug.Log("MISS");
        }

        if (_orderCount==0)
        {
            Debug.Log("SUCCESS");
        }
    }

    public List<int> GetTapOrder()
    {
        return _tapOrder;
    }
    #endregion
}