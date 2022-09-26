using UnityEngine;

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
