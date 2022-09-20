using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEngine.Random;

/// <summary>
/// �^�C���̊Ǘ��N���X
/// </summary>
public class TileManager : MonoBehaviour
{
    // �^�C���̔z��
    private TileController[] _tileArray;

    // �^�b�v���鏇��
    private Queue<int> _tapOrder;

    [SerializeField]
    private int _orderCount;

    private void Start()
    {
        // �^�C���̎擾
        _tileArray = FindObjectsOfType<TileController>();
        SortTileArray(_tileArray);
        SetID(_tileArray);
        _tapOrder = CreateTapOrder(_orderCount);
    }

    /// <summary>
    /// �z��̃\�[�g
    /// </summary>
    /// <param name="tiles"></param>
    private void SortTileArray(TileController[] tiles)
    {
        _tileArray = tiles.Reverse().ToArray();
    }

    /// <summary>
    /// �^�C����ID��ݒ肷��
    /// </summary>
    private void SetID(TileController[] tile)
    {
        for (int count = 0; count < tile.Length; count++)
        {
            tile[count].ID = count;
        }
    }

    /// <summary>
    /// �^�b�v���鏇�Ԃ��쐬
    /// </summary>
    private Queue<int> CreateTapOrder(int count)
    {
        var tapOrder = new Queue<int>();

        for (int i = 0; i < count; i++)
        {
            var item = Range(0, _tileArray.Length);
            tapOrder.Enqueue(item);
        }

        return tapOrder;
    }

    /// <summary>
    /// ���Ԃ̊m�F
    /// </summary>
    public void OrderConfirm()
    {
        StartCoroutine(TilesFlashAsync());
    }

    /// <summary>
    /// ���Ԃɓ_�ł���
    /// </summary>
    private IEnumerator TilesFlashAsync()
    {
        foreach (var item in _tapOrder)
        {
            Debug.Log(item);
            yield return _tileArray[item].FlashAsync();
        }
    }
}
