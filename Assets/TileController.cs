using UnityEngine;
using UnityEngine.UI;

public class TileController : MonoBehaviour
{
    public int ID { get; set; }

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ChengeColor(Color color)
    {
        _image.color = color;
    }
}