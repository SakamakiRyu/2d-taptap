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
    private List<int> _tapOrder;

    [Header("�ŏ��̒���")]
    [SerializeField]
    private int _startedOrderCount;

    // �Ԋu
    private float Interval = 0.5f;

    private void Start()
    {
        _tileArray = FindObjectsOfType<TileController>();
        SortTileArray(_tileArray);
        SetID(_tileArray);
        _tapOrder = CreateTapOrder(_startedOrderCount);
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
    private List<int> CreateTapOrder(int count)
    {
        var tapOrder = new List<int>();

        for (int i = 0; i < count; i++)
        {
            var item = Range(0, _tileArray.Length);
            tapOrder.Add(item);
        }

        return tapOrder;
    }

    /// <summary>
    /// ���Ԃ̊m�F
    /// </summary>
    public void TapOrderConfirm()
    {
        StartCoroutine(TilesFlashAsync());
    }

    /// <summary>
    /// ���Ԃɓ_�ł���
    /// </summary>
    private IEnumerator TilesFlashAsync()
    {
        var timer = 0f;
        yield return null;

        foreach (var item in _tapOrder)
        {
            if (timer < Interval)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            else
            {
                Debug.Log("flash");
                timer = 0f;
                yield return _tileArray[item].FlashAsync();
            }
        }
    }
}
