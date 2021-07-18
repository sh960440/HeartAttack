using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public List<Card> cardsInHand; 

    public Player(List<Card> initialHand)
    {
        cardsInHand = initialHand;
    }

    public string GetNextCardToPlay()
    {
        if (cardsInHand.Count > 0)
        {
            string nextCard = cardsInHand[0].cardName;
            cardsInHand.RemoveAt(0);
            return nextCard;
        }
        else
        {
            return null;
        }
    }
}