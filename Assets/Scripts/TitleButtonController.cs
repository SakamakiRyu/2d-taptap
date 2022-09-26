using UnityEngine;

/// <summary>
/// タイトルのボタン
/// </summary>
public class TitleButtonController : MonoBehaviour
{
    public void OnClick()
    {
        if (ServiceLocator<IGameManager>.IsValid)
        {
            ServiceLocator<IGameManager>.Instance.GoToInGame();
        }
    }
}
