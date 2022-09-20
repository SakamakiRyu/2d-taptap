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
    private Queue<int> _tapOrder;

    [SerializeField]
    private int _orderCount;

    private void Start()
    {
        // タイルの取得
        _tileArray = FindObjectsOfType<TileController>();
        SortTileArray(_tileArray);
        SetID(_tileArray);
        _tapOrder = CreateTapOrder(_orderCount);
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
    private Queue<int> CreateTapOrder(int count)
    {
        var tapOrder = new Queue<int>();

        for (int i = 0; i < count; i++)
        {
            var item = Range(0, _tileArray.Length);
            tapOrder.Enqueue(item);
        }

        return tapOrder;
    }

    /// <summary>
    /// 順番の確認
    /// </summary>
    public void OrderConfirm()
    {
        StartCoroutine(TilesFlashAsync());
    }

    /// <summary>
    /// 順番に点滅する
    /// </summary>
    private IEnumerator TilesFlashAsync()
    {
        foreach (var item in _tapOrder)
        {
            Debug.Log(item);
            yield return _tileArray[item].FlashAsync();
        }
    }
}
