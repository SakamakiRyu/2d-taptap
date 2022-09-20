using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Random;

/// <summary>
/// タイルの管理クラス
/// </summary>
public class TileManager : MonoBehaviour
{
    // タイルの配列
    private TileController[] _tileArray;

    // タップする順番
    private List<int> _tapOrder;

    [Header("最初の注文")]
    [SerializeField]
    private int _startedOrderCount;

    // 間隔
    private float Interval = 0.5f;

    private void Start()
    {
        _tileArray = FindObjectsOfType<TileController>();
        SortTileArray(_tileArray);
        SetID(_tileArray);
        _tapOrder = CreateTapOrder(_startedOrderCount);
    }

    /// <summary>
    /// 配列のソート
    /// </summary>
    /// <param name="tiles"></param>
    private void SortTileArray(TileController[] tiles)
    {
        _tileArray = tiles.Reverse().ToArray();
    }

    /// <summary>
    /// タイルにIDを設定する
    /// </summary>
    private void SetID(TileController[] tile)
    {
        for (int count = 0; count < tile.Length; count++)
        {
            tile[count].ID = count;
        }
    }

    /// <summary>
    /// タップする順番を作成
    /// </summary>
    private List<int> CreateTapOrder(int count)
    {
        var tapOrder = new List<int>();

        for (int i = 0; i < count; i++)
        {
            var item = Range(0, _tileArray.Length);
            tapOrder.Add(item);
        }

        return tapOrder;
    }

    /// <summary>
    /// 順番の確認
    /// </summary>
    public void TapOrderConfirm()
    {
        StartCoroutine(TilesFlashAsync());
    }

    /// <summary>
    /// 順番に点滅する
    /// </summary>
    private IEnumerator TilesFlashAsync()
    {
        var timer = 0f;
        yield return null;

        foreach (var item in _tapOrder)
        {
            if (timer < Interval)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            else
            {
                Debug.Log("flash");
                timer = 0f;
                yield return _tileArray[item].FlashAsync();
            }
        }
    }
}
