using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace JackTest
{
    [System.Serializable]
    public class CardEvent : UnityEvent<Card>
    {
    }
    public class Deck : MonoBehaviour
    {
        public List<Card> DrawPile { get; private set; }
        public List<Card> DiscardPile { get; private set; }
        
        public List<Card> AllCards => (List<Card>) DrawPile.Concat(DiscardPile);
        public CardEvent playCard;

        void Start()
        {
            DrawPile = new List<Card>();
            DiscardPile = new List<Card>();
            foreach (int i in Enumerable.Range(1, 10))
            {
                AddCard(gameObject.AddComponent<Card>());
            }
            playCard = new CardEvent();
        }

        public void AddCard(Card newCard)
        {
            DrawPile.Add(newCard);
        }

        public void Use()
        {
            Card cardToRemove = DrawPile.First();
            DrawPile.Remove(cardToRemove);
            DiscardPile.Add(cardToRemove);
            playCard.Invoke(cardToRemove);
        }
    }
}
