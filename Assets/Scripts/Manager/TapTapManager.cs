using System.Collections;
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
    private int _defaultOrderCount;

    // タイルの数
    private readonly int TILE_COUNT = 16;

    #region Unity Function
    private void Start()
    {
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

    #region Method Of Interface
    void ITapTapManager.GameStart()
    {
        GameStart();
    }
    #endregion

    #region Used Button
    public void GameStart()
    {
        if (ServiceLocator<IOrderControl>.IsValid)
        {
            ServiceLocator<IOrderControl>.Instance.CreateOrder(_defaultOrderCount);
        }

        if (ServiceLocator<ICountDown>.IsValid)
        {
            ServiceLocator<ICountDown>.Instance.CountDown(() =>
            {
                if (ServiceLocator<ITileManager>.IsValid)
                {
                    ServiceLocator<ITileManager>.Instance.ConfirmOrder();
                }
            });
        }
    }
    #endregion
}

