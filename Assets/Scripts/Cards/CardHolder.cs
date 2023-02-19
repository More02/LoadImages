using System.Collections.Generic;
using UnityEngine;

namespace Cards
{
    /// <summary>
    /// Хранение списка карточек
    /// </summary>
    public class CardHolder : MonoBehaviour
    {
        public List<Card> AllCards { get; } = new();

        public static CardHolder Instanse { get; private set; }

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
                AllCards.Add(card);
            }
        }
    }
}