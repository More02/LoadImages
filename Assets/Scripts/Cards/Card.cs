using Animation;
using Loading;
using UnityEngine;
using UnityEngine.UI;

namespace Cards
{
    /// <summary>
    /// Базовый класс для карты
    /// </summary>
    public class Card : MonoBehaviour
    {
        [SerializeField] 
        private RawImage _cardImage;

        public ImageLoader ImageLoader { get; private set; }

        public RotateCard RotateCards { get; private set; }

        public RawImage CardImage => _cardImage;

        private void Awake()
        {
            ImageLoader = new ImageLoader();
            RotateCards = GetComponent<RotateCard>();
        }
    }
}