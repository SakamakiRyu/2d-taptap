using UnityEngine;

/// <summary>
/// �Q�[���X�^�[�g�{�^��
/// </summary>
public class GameStartButton : MonoBehaviour
{
    public void GameStart()
    {
        if (ServiceLocator<ITapTapManager>.IsValid)
        {
            ServiceLocator<ITapTapManager>.Instance.RequestStart();
        }
    }
}
