using System.Linq;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private TileController[] _tile;

    // タップする順番
    private int[] _tapOrder;

    private void Start()
    {
        SetNumber(_tile);
        _tapOrder = CreateOrder(_tile.Length);
    }

    private void SetNumber(TileController[] tile)
    {
        for (int count = 0; count < tile.Length; count++)
        {
            tile[count].ID = count;
        }
    }

    private int[] CreateOrder(int count)
    {
        var numbers = new int[count];

        // 数字リストを作成
        for (int i = 0; i < count; i++)
        {
            numbers[i] = i;
        }

        int[] order = CreateRandamNumberList(numbers);

        return order;
    }

    private int[] CreateRandamNumberList(int[] order)
    {
        // ランダムな数列を作成
        System.Random rand = new System.Random();
        var randList = order.OrderBy(x => rand.Next()).ToArray();
        return randList;
    }
}
