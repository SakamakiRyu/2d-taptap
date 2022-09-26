using UnityEngine;

/// <summary>
/// �^�C�g���̃{�^���p
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
