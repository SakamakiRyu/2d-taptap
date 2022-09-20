using System.Linq;
using UnityEngine;

/// <summary>
/// �^�C���̊Ǘ��N���X
/// </summary>
public class TileManager : MonoBehaviour
{
    [SerializeField]
    private TileController[] _tiles;

    // �^�b�v���鏇��
    private int[] _tapOrder;

    private void Start()
    {
        SetNumber(_tiles);
        _tapOrder = CreateTapOrder(_tiles.Length);
    }

    /// <summary>
    /// �^�C����ID��ݒ肷��
    /// </summary>
    /// <param name="tile"></param>
    private void SetNumber(TileController[] tile)
    {
        for (int count = 0; count < tile.Length; count++)
        {
            tile[count].ID = count;
        }
    }

    /// <summary>
    /// �^�b�v���鏇�Ԃ��쐬
    /// </summary>
    /// <param name="count"></param>
    /// <returns></returns>
    private int[] CreateTapOrder(int count)
    {
        var numbers = new int[count];

        // �������X�g���쐬
        for (int i = 0; i < count; i++)
        {
            numbers[i] = i;
        }

        int[] order = ShuffleNumbersList(numbers);

        return order;
    }

    /// <summary>
    /// ���X�g�̒��g���V���b�t������
    /// </summary>
    private int[] ShuffleNumbersList(int[] order)
    {
        // �����_���Ȑ�����쐬
        System.Random rand = new();
        var randList = order.OrderBy(x => rand.Next()).ToArray();
        return randList;
    }
}
