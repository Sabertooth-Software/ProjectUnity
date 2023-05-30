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
        public List<Card> drawPile = new List<Card>();
        public List<Card> Hand { get; private set; }
        public List<Card> DiscardPile { get; private set; }
        public int handSize = 5;
        
        public List<Card> AllCards => (List<Card>) drawPile.Concat(DiscardPile);
        public CardEvent playCard;

        void Awake()
        {
            DiscardPile = new List<Card>();
            // foreach (int i in Enumerable.Range(1, 10))
            // {
            //     AddCard(gameObject.AddComponent<Card>());
            // }
            Hand = new List<Card>();
            playCard = new CardEvent();
            FillHand();
        }

        public void AddCard(Card newCard)
        {
            drawPile.Add(newCard);
        }

        public void Use()
        {
            if (Hand.Count <= 0)
            {
                FillHand();
                return;
            }
            Card cardToRemove = Hand.First();
            Hand.Remove(cardToRemove);
            DiscardPile.Add(cardToRemove);
            playCard.Invoke(cardToRemove);
        }
        
        public void Draw()
        {
            if (drawPile.Count <= 0)
            {
                return;
            }
            Card draw = drawPile.First();
            drawPile.Remove(draw);
            Hand.Add(draw);
            playCard.Invoke(draw);
        }

        private void FillHand()
        {
            foreach (int i in Enumerable.Range(1, handSize))
            {
                Draw();
            }
        }
    }
}
