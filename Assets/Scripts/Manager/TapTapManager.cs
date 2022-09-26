using UnityEngine;

/// <summary>
/// �Q�[�����Ǘ�����N���X
/// ���^�b�v�̏��Ԃ�[����]�ƒ�`����
/// </summary>
public class TapTapManager : MonoBehaviour, ITapTapManager
{
    [SerializeField]
    private GameObject _setOfInGame;

    [SerializeField]
    private int _defaultOrderCount;

    #region Unity Function
    private void OnEnable()
    {
        if (!ServiceLocator<ITapTapManager>.IsValid)
        {
            ServiceLocator<ITapTapManager>.Regist(this);
        }
    }

    private void OnDisable()
    {
        if (ServiceLocator<ITapTapManager>.IsValid)
        {
            ServiceLocator<ITapTapManager>.UnRegist(this);
        }
    }
    #endregion

    #region Method Of Interface
    void ITapTapManager.GameStart()
    {
        GameStart();
    }
    #endregion

    #region Used Button
    public void GameStart()
    {
        if (ServiceLocator<IOrderGenerator>.IsValid)
        {
            ServiceLocator<IOrderGenerator>.Instance.CreateOrder(_defaultOrderCount);
        }

        if (ServiceLocator<ICountDown>.IsValid)
        {
            ServiceLocator<ICountDown>.Instance.CountDown(() =>
            {
                if (ServiceLocator<ITileManager>.IsValid)
                {
                    ServiceLocator<ITileManager>.Instance.ConfirmOrder();
                }
            });
        }
    }
    #endregion
}

