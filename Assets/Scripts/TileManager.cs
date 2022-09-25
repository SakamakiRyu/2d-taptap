using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイルの管理クラス
/// </summary>
public class TileManager : MonoBehaviour
{
    // タイルの配列
    [SerializeField]
    private TileController[] _tileArray;

    /// <summary>
    /// タイルの数
    /// </summary>
    public int TileCount => _tileArray.Length;

    // 点滅の間隔
    [SerializeField]
    private float _interval = 0.5f;

    private void Start()
    {
        SetID(_tileArray);
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
        List<int> tapOrder = null;

        if (ServiceLocator<ITapTapManager>.IsValid)
        {
            tapOrder = ServiceLocator<ITapTapManager>.Instance.GetTapOrder();
        }

        yield return null;

        foreach (var item in tapOrder)
        {
            while (timer < _interval)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            timer = 0f;
            yield return _tileArray[item].FlashAsync();
        }
    }
}