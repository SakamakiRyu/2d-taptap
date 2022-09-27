using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �^�C���̊Ǘ��N���X
/// </summary>
public class TileManager : MonoBehaviour, ITileManager
{
    // �^�C���̔z��
    [SerializeField]
    private TileController[] _tileArray;

    // �_�ł̊Ԋu
    [SerializeField]
    private float _interval = 0.5f;

    #region Unity Function
    private void Start()
    {
        SetID(_tileArray);
    }

    private void OnEnable()
    {
        if (!ServiceLocator<ITileManager>.IsValid)
        {
            ServiceLocator<ITileManager>.Regist(this);
        }
    }

    private void OnDisable()
    {
        if (ServiceLocator<ITileManager>.IsValid)
        {
            ServiceLocator<ITileManager>.UnRegist(this);
        }
    }
    #endregion

    #region Private Function
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
    #endregion

    /// <summary>
    /// ���Ԃ̊m�F
    /// </summary>
    void ITileManager.ConfirmOrder()
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

        if (ServiceLocator<IOrderGenerator>.IsValid)
        {
            // tapOrder = ServiceLocator<IOrderGenerator>.Instance.GetOrder();
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