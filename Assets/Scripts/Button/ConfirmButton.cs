using UnityEngine;

/// <summary>
/// �I�[�_�[�m�F�̃{�^��
/// </summary>
public class ConfirmButton : MonoBehaviour
{
    public void OnClick()
    {
        if (ServiceLocator<ITileManager>.IsValid)
        {
            ServiceLocator<ITileManager>.Instance.ConfirmOrder();
        }
    }
}
