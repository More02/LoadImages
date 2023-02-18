using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Базовый класс для карты
/// </summary>
public class Card : MonoBehaviour
{
    [SerializeField]
    private RawImage _cardImage;
    private ImageLoader _imageLoader;
    private RotateCard _rotateCards;

    public ImageLoader ImageLoader
    {
        get { return _imageLoader; }
    }

    public RotateCard RotateCards
    {
        get {return _rotateCards;}
    }

    public RawImage CardImage
    { 
        get { return _cardImage; } 
    }

    private void Awake()
    {
        _imageLoader = new ImageLoader();
        _rotateCards = GetComponent<RotateCard>();
    }
}
