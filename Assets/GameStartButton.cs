using UnityEngine;

/// <summary>
/// ゲームスタートのボタン
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
