using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour 
{
    private List<Card> _allCards = new List<Card>();
    private static CardManager _instanse;

    public List<Card> AllCards
    {
        get { return _allCards; }
    }   
    public static CardManager Instanse 
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
