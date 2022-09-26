using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �^�C���N���X
/// </summary>
public class TileController : MonoBehaviour
{
    // �_�ł��鎞��
    private float _flashTime = 0.5f;

    // �^�C���̎��ʔԍ�
    public int ID { get; set; }

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        ChengeColor(Color.white);
    }

    /// <summary>
    /// �F��ς���
    /// </summary>
    public void ChengeColor(Color color)
    {
        _image.color = color;
    }

    /// <summary>
    /// �_��
    /// </summary>
    public IEnumerator FlashAsync()
    {
        _image.color = Color.red;
        var timer = 0f;
        yield return null;

        while (timer < _flashTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        _image.color = Color.white;
        yield return null;
    }
}