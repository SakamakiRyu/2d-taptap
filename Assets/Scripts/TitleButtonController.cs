using UnityEngine;

/// <summary>
/// �^�C�g���̃{�^��
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
