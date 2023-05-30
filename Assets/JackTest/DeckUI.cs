using System;
using System.Collections;
using System.Collections.Generic;
using JackTest;
using TMPro;
using UnityEngine;

public class DeckUI : MonoBehaviour
{
    public Deck Deck;

    [SerializeField] TMP_Text drawPile;
    [SerializeField] TMP_Text discardPile;
    [SerializeField] TMP_Text hand;

    void Start()
    {
        if (Deck != null)
        {
            Deck.playCard.AddListener(OnPlayCard);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        int drawCardsLeft = Deck.DrawPile.Count;
        drawPile.text = drawCardsLeft.ToString();
        
        int discardCardsLeft = Deck.DiscardPile.Count;
        discardPile.text = discardCardsLeft.ToString();

        int numCardsInHand = Deck.Hand.Count;
        hand.text = numCardsInHand.ToString();
    }

    void OnPlayCard(Card card)
    {
        UpdateUI();
    }
}
