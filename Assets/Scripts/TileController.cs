using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// タイルクラス
/// </summary>
public class TileController : MonoBehaviour
{
    // 点滅する時間
    private float _flashTime = 0.5f;

    // タイルの識別番号
    public int ID { get; set; }

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        ChengeColor(Color.white);
    }

    /// <summary>
    /// 色を変える
    /// </summary>
    public void ChengeColor(Color color)
    {
        _image.color = color;
    }

    /// <summary>
    /// 点滅
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