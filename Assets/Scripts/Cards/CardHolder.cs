using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Хранение списка карточек
/// </summary>
public class CardHolder : MonoBehaviour 
{
    private List<Card> _allCards = new List<Card>();
    private static CardHolder _instanse;

    public List<Card> AllCards
    {
        get { return _allCards; }
    }   
    public static CardHolder Instanse 
    { 
        get { return _instanse; }  
        private set { _instanse = value; } 
    }

    private void Awake()
    {       
        Instanse = this;
    }

    private void Start()
    {
        FillListOfCards();
    }

    private void FillListOfCards()
    {
        foreach (var card in transform.GetComponentsInChildren<Card>())
        {
            _allCards.Add(card);
        }
    }
}
