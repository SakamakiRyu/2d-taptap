using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �Q�[�����ł̃R�[���o�b�N�֐�
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
