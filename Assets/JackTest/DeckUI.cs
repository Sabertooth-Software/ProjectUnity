using System.Linq;
using JackTest;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeckUI : MonoBehaviour
{
    public Deck deck;

    [SerializeField] TMP_Text drawPile;
    [SerializeField] TMP_Text discardPile;
    [SerializeField] TMP_Text hand;
    [SerializeField] Image currentCard;

    void Start()
    {
        if (deck != null)
        {
            deck.playCard.AddListener(OnPlayCard);
            Card firstCard = deck.Hand.First();
            UpdateUI(firstCard);
        }
    }

    void UpdateUI(Card card)
    {
        int drawCardsLeft = deck.DrawPile.Count;
        drawPile.text = drawCardsLeft.ToString();
        
        int discardCardsLeft = deck.DiscardPile.Count;
        discardPile.text = discardCardsLeft.ToString();

        int numCardsInHand = deck.Hand.Count;
        hand.text = numCardsInHand.ToString();

        if (numCardsInHand > 0)
        {
            currentCard.sprite = deck.Hand.First().image;
        }
    }

    void OnPlayCard(Card card)
    {
        UpdateUI(card);
    }
}
