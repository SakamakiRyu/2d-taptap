using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

/// <summary>
/// ゲームを管理するクラス
/// ※タップの順番を[注文]と定義する
/// </summary>
public class TapTapManager : MonoBehaviour, ITapTapManager
{
    [SerializeField]
    private GameObject _setOfInGame;

    [SerializeField]
    private int _startedOrderCount;

    // タイルの数
    private readonly int TILE_COUNT = 16;

    #region Unity Function
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
    #endregion

    /// <summary>
    /// 注文を作成
    /// </summary>
    private List<int> CreateTapOrder(int count)
    {
        var tapOrder = new List<int>();

        for (int i = 0; i < count; i++)
        {
            var item = Range(0, TILE_COUNT);
            tapOrder.Add(item);
        }

        _orderCount = tapOrder.Count;
        return tapOrder;
    }

    #region Method Of Interface
    List<int> ITapTapManager.GetTapOrder()
    {
        return _tapOrder;
    }

    void ITapTapManager.RequestCreateOrder()
    {
        _tapOrder = CreateTapOrder(_startedOrderCount);
    }

    void ITapTapManager.RequestStart()
    {
        GameStart();
    }
    #endregion

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
        if (_orderCount == 0)
        {
            return;
        }

        Check(tile);
    }

    private void Check(TileController tile)
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

        if (_orderCount == 0)
        {
            Debug.Log("SUCCESS");
        }
    }
    #endregion

    #region Used Button
    public void GameStart()
    {
        if (ServiceLocator<ICountDown>.IsValid)
        {
            StartCoroutine(ServiceLocator<ICountDown>.Instance.RequestCountDown
                (() => _setOfInGame.SetActive(true),
                () => ServiceLocator<ITileManager>.Instance.ConfirmOrder()));
        }
    }
    #endregion
}