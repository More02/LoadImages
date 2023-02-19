using UnityEngine;

namespace Cards
{
    /// <summary>
    /// Создание карточек
    /// </summary>
    public class CardFactory : MonoBehaviour
    {
        [SerializeField] 
        private GameObject _cardPrefab;
        [SerializeField] 
        private int _numberCards = 5;

        private void InstantiateCards(int numberCards)
        {
            for (var i = 0; i < numberCards; i++)
            {
                Instantiate(_cardPrefab, transform);
            }
        }

        private void Awake()
        {
            InstantiateCards(_numberCards);
        }
    }
}