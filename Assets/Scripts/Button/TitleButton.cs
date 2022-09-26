using UnityEngine;

/// <summary>
/// タイトルのボタン
/// </summary>
public class TitleButton : MonoBehaviour
{
    public void OnClick()
    {
        if (ServiceLocator<IGameManager>.IsValid)
        {
            ServiceLocator<IGameManager>.Instance.LoadToInGame();
        }
    }
}
