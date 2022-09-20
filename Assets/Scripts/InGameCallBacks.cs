using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ゲーム内でのコールバック関数
/// </summary>
public class InGameCallBacks : MonoBehaviour
{
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
        Debug.Log(tile.ID);
    }
}
