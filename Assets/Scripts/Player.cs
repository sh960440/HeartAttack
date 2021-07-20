using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private List<Card> cardsInHand; 

    public Player(List<Card> initialHand)
    {
        cardsInHand = initialHand;
    }

    public void PlayCard(CardStack cardStack)
    {
        if (cardsInHand.Count > 0)
        {
            cardStack.SpawnCard(cardsInHand[0]);
            cardsInHand.RemoveAt(0);
        }
    }

    public void CollectAllCardsOnTable(CardStack cardStack)
    {
        cardsInHand.AddRange(cardStack.cardsOnTable);
        cardStack.cardsOnTable.Clear();
        cardStack.HideAllCards();
        // 洗牌?
    }

    public int GetCardAmount() => cardsInHand.Count;
    public bool HasNoCards() => cardsInHand.Count <= 0; 
}