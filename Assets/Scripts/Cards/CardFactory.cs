using UnityEngine;

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
        for (int i = 0; i < numberCards; i++)
        {
            Instantiate(_cardPrefab, transform);
        }
    }

    private void Awake()
    {
        InstantiateCards(_numberCards);
    }
}
