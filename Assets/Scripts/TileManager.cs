using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �^�C���̊Ǘ��N���X
/// </summary>
public class TileManager : MonoBehaviour
{
    // �^�C���̔z��
    [SerializeField]
    private TileController[] _tileArray;

    /// <summary>
    /// �^�C���̐�
    /// </summary>
    public int TileCount => _tileArray.Length;

    // �_�ł̊Ԋu
    [SerializeField]
    private float _interval = 0.5f;

    private void Start()
    {
        SetID(_tileArray);
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
        List<int> tapOrder = null;

        if (ServiceLocator<ITapTapManager>.IsValid)
        {
            tapOrder = ServiceLocator<ITapTapManager>.Instance.GetTapOrder();
        }

        yield return null;

        foreach (var item in tapOrder)
        {
            while (timer < _interval)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            timer = 0f;
            yield return _tileArray[item].FlashAsync();
        }
    }
}