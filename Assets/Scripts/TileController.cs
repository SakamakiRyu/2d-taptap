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
    /// êFÇïœÇ¶ÇÈ
    /// </summary>
    public void ChengeColor(Color color)
    {
        _image.color = color;
    }

    /// <summary>
    /// ì_ñ≈
    /// </summary>
    public IEnumerator FlashAsync()
    {
        _image.color = Color.red;
        var timer = 0f;
        yield return null;

        while (timer < _showTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        _image.color = Color.white;
        yield return null;
    }
}