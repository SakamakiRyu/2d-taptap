using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TileController : MonoBehaviour
{
    public int ID { get; set; }

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.color = Color.white;
    }

    public void ChengeColor(Color color)
    {
        _image.color = color;
    }

    /// <summary>
    /// “_–Å
    /// </summary>
    public IEnumerator FlashAsync()
    {
        _image.color = Color.red;
        var time = 0f;
        yield return null;

        while (time < 0.5f)
        {
            time += Time.deltaTime;
            yield return null;
        }

        _image.color = Color.white;
        yield return null;
    }
}