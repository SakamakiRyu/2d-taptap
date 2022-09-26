using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

/// <summary>
/// �Q�[�����Ǘ�����N���X
/// ���^�b�v�̏��Ԃ�[����]�ƒ�`����
/// </summary>
public class TapTapManager : MonoBehaviour, ITapTapManager
{
    [SerializeField]
    private GameObject _setOfInGame;

    [SerializeField]
    private int _startedOrderCount;

    // �^�b�v���鏇��
    private List<int> _tapOrder;

    // ���݂̒���
    private int _currentTapOrder = 0;

    // ������
    private int _orderCount { get; set; }

    // �^�C���̐�
    private readonly int TILE_COUNT = 16;

    #region Unity Function
    private void Start()
    {
        _tapOrder = CreateTapOrder(_startedOrderCount);
        _orderCount = _tapOrder.Count;
    }

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

    /// <summary>
    /// �^�b�v���鏇�Ԃ��쐬
    /// </summary>
    private List<int> CreateTapOrder(int count)
    {
        var tapOrder = new List<int>();

        for (int i = 0; i < count; i++)
        {
            var item = Range(0, TILE_COUNT);
            tapOrder.Add(item);
        }

        return tapOrder;
    }

    #region Method Of Interface
    List<int> ITapTapManager.GetTapOrder()
    {
        return _tapOrder;
    }

    void ITapTapManager.RequestCreateTapOrder()
    {
        _tapOrder = CreateTapOrder(_startedOrderCount);
    }

    void ITapTapManager.RequestStart()
    {
        GameStart();
    }
    #endregion

    #region InGame CallBacks
    public void OnEnter(TileController tile)
    {
        tile.ChengeColor(Color.blue);
    }

    public void OnExit(TileController tile)
    {
        tile.ChengeColor(Color.white);
    }

    public void OnClick(TileController tile)
    {
        if (tile.ID == _tapOrder[_currentTapOrder])
        {
            _currentTapOrder++;
            _orderCount--;
            Debug.Log("OK");
        }
        else
        {
            Debug.Log("MISS");
        }

        if (_orderCount == 0)
        {
            Debug.Log("SUCCESS");
        }
    }
    #endregion

    #region Used Button
    public void GameStart()
    {
        if (ServiceLocator<ICountDown>.IsValid)
        {
            ServiceLocator<ICountDown>.Instance.RequestCountDown(
                () => _setOfInGame.SetActive(true));
        }
    }
    #endregion
}