using UnityEngine;

/// <summary>
/// タイトルのボタン用
/// </summary>
public class TitleButtonController : MonoBehaviour
{
    public void GoToInGame()
    {
        if (ServiceLocator<IGameManager>.IsValid)
        {
            ServiceLocator<IGameManager>.Instance.GoToInGame();
        }
    }
}
