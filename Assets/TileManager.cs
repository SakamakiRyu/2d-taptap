using System.Linq;
using UnityEngine;

/// <summary>
/// タイルの管理クラス
/// </summary>
public class TileManager : MonoBehaviour
{
    [SerializeField]
    private TileController[] _tiles;

    // タップする順番
    private int[] _tapOrder;

    private void Start()
    {
        SetNumber(_tiles);
        _tapOrder = CreateTapOrder(_tiles.Length);
    }

    /// <summary>
    /// タイルにIDを設定する
    /// </summary>
    /// <param name="tile"></param>
    private void SetNumber(TileController[] tile)
    {
        for (int count = 0; count < tile.Length; count++)
        {
            tile[count].ID = count;
        }
    }

    /// <summary>
    /// タップする順番を作成
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    private int[] CreateTapOrder(int count)
    {
        var numbers = new int[count];

        // 数字リストを作成
        for (int i = 0; i < count; i++)
        {
            numbers[i] = i;
        }

        int[] order = ShuffleNumbersList(numbers);

        return order;
    }

    /// <summary>
    /// リストの中身をシャッフルする
    /// </summary>
    private int[] ShuffleNumbersList(int[] order)
    {
        // ランダムな数列を作成
        System.Random rand = new();
        var randList = order.OrderBy(x => rand.Next()).ToArray();
        return randList;
    }
}
