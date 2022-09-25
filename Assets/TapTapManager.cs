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

    // �^�C���̐�
    private readonly int TILE_COUNT = 16;

    private void Start()
    {
        _tapOrder = CreateTapOrder(_startedOrderCount);
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

    /// <summary>
    /// �������m�F
    /// </summary>
    public void CreateTapOrder()
    {
        _tapOrder = CreateTapOrder(_startedOrderCount);
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
        if (tile.ID == _tapOrder[0])
        {
            Debug.Log("OK");
        }
        else
        {
            Debug.Log("MISS");
        }
    }

    public List<int> GetTapOrder()
    {
        return _tapOrder;
    }
    #endregion
}