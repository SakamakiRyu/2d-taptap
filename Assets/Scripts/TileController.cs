using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TileController : MonoBehaviour
{
    private float _showTime = 0.5f;

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
        var time = 0f;
        yield return null;

        while (time < _showTime)
        {
            time += Time.deltaTime;
            yield return null;
        }

        _image.color = Color.white;
        yield return null;
    }
}