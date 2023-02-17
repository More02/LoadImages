using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    private RawImage _cardImage;
    private ImageLoader _imageLoader;

    public ImageLoader ImageLoader
    {
        get { return _imageLoader; }
    }

    public RawImage CardImage
    { 
        get { return _cardImage; } 
    }

    private void Awake()
    {
        _imageLoader = new ImageLoader();
    }
}
