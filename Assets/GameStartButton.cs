using UnityEngine;

/// <summary>
/// ゲームスタートボタン
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
