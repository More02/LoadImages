using System.Collections.Generic;
using UnityEngine;

public class CardHolder : MonoBehaviour 
{

    private List<Card> _allCards = new List<Card>();

    public List<Card> AllCards
    {
        get { return _allCards; }
    }

    private static CardHolder _instanse;
    public static CardHolder Instanse 
    { 
        get { return _instanse; }  
        private set { _instanse = value; } 
    }

    private void Start()
    {
        FillListOfCards(transform);
        Instanse = this;
    }
    private void FillListOfCards(Transform cardHolder)
    {
        foreach (var card in cardHolder.GetComponentsInChildren<Card>())
        {
            _allCards.Add(card);
        }
    }
}
