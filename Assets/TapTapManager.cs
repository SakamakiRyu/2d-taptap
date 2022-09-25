using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

/// <summary>
/// �Q�[�����Ǘ�����N���X
/// ���^�b�v�̏��Ԃ𒍕��ƒ�`����
/// </summary>
public class TapTapManager : MonoBehaviour, ITapTapManager
{
    [SerializeField]
    private int _startedOrderCount;

    // �^�b�v���鏇��
    private List<int> _tapOrder;

    // ���݂̒���
    private int _currentTapOrder = 0;

    private int _orderCount { get; set; }

    // �^�C���̐�
    private readonly int TILE_COUNT = 16;

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

    /// <summary>
    /// �������쐬
    /// </summary>
    public void RequestCreateTapOrder()
    {
        _tapOrder = CreateTapOrder(_startedOrderCount);
    }

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

        if (_orderCount==0)
        {
            Debug.Log("SUCCESS");
        }
    }

    public List<int> GetTapOrder()
    {
        return _tapOrder;
    }
    #endregion
}