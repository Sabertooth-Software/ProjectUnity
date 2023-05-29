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
        int discardCardsLeft = Deck.DiscardPile.Count;
        drawPile.text = drawCardsLeft.ToString();
        discardPile.text = discardCardsLeft.ToString();
    }

    void OnPlayCard(Card card)
    {
        UpdateUI();
    }
}
