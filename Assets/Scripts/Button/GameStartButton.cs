using UnityEngine;

/// <summary>
/// �Q�[���X�^�[�g�̃{�^��
/// </summary>
public class GameStartButton : MonoBehaviour
{
    public void OnClick()
    {
        if (ServiceLocator<ITapTapManager>.IsValid)
        {
            ServiceLocator<ITapTapManager>.Instance.RequestStart();
        }
    }
}
