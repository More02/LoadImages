using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    private RawImage _cardImage;

    public RawImage CardImage
    { 
        get { return _cardImage; } 
    }
}
