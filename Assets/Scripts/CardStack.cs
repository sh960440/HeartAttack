using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStack : MonoBehaviour
{
    public List<Card> cardsOnTable; 

    public void SpawnCard(Card card)
    {
        cardsOnTable.Add(card);

        RectTransform cardRectTransform = transform.Find(card.cardName).GetComponent<RectTransform>();
        cardRectTransform.localPosition = new Vector3(Random.Range(-120.0f, 120.0f), Random.Range(-120.0f, 120.0f));
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

    public int GetCardNumberOnTop() => cardsOnTable[cardsOnTable.Count - 1].cardNumber;
    public int GetCardAmountOnTable() => cardsOnTable.Count;
}
