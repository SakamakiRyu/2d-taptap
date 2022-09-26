using UnityEngine;

/// <summary>
/// オーダー確認のボタン
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
