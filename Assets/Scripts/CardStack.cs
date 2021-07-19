using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStack : MonoBehaviour
{
    public List<Card> cardsOnTable; 
    public void SpawnRandomCard() // For testing only
    {
        RectTransform card = transform.GetChild(Random.Range(0, transform.childCount)).GetComponent<RectTransform>();
        card.localPosition = new Vector3(Random.Range(-200.0f, 200.0f), Random.Range(-200.0f, 200.0f));
        card.Rotate(new Vector3(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        card.transform.SetAsLastSibling();
        card.gameObject.SetActive(true);
    }

    public void SpawnCard(Card card)
    {
        cardsOnTable.Add(card);

        RectTransform cardRectTransform = transform.Find(card.cardName).GetComponent<RectTransform>();
        cardRectTransform.localPosition = new Vector3(Random.Range(-200.0f, 200.0f), Random.Range(-200.0f, 200.0f));
        cardRectTransform.Rotate(new Vector3(0.0f, 0.0f, Random.Range(0.0f, 360.0f)));
        cardRectTransform.SetAsLastSibling();
        cardRectTransform.gameObject.SetActive(true);  
    }

    public void HideAllCards()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public List<Card> DistributeCards()
    {
        if (cardsOnTable.Count > 0)
        {
            List<Card> selectedCards = new List<Card>();
            for (int i = 0; i < 13; i++)
            {
                int index = Random.Range(0, cardsOnTable.Count - 1);
                selectedCards.Add(cardsOnTable[index]);
                cardsOnTable.RemoveAt(index);
            }
            
            return selectedCards;
        }
        else
        {
            return null;
        }
    }

    public int GetCardNumberOnTop()
    {
        return cardsOnTable[cardsOnTable.Count - 1].cardNumber;
    }
}
