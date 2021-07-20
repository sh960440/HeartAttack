using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUIController : MonoBehaviour
{
    private RectTransform hands;
    private RectTransform numberTrackers;
    private RectTransform gameMessage;
    [SerializeField] private Image[] cardButtonImages;
    [SerializeField] private TMP_Text[] cardButtonTexts;

    private void Awake()
    {
        hands = transform.Find("HandIcons").GetComponent<RectTransform>();
        numberTrackers = transform.Find("NumberTrackers").GetComponent<RectTransform>();
        gameMessage = transform.Find("GameMessage").GetComponent<RectTransform>();
    }

    public void ShowSlapImage(int index)
    {
        string handIconName = "Player_" + index + "_Hand";
        hands.Find(handIconName).gameObject.SetActive(true);
        hands.Find(handIconName).SetAsLastSibling();
    }

    public void HideHands()
    {
        foreach(RectTransform hand in hands)
        {
            hand.gameObject.SetActive(false);
        }
    }

    public void UpdateCardButtonText(int playerIndex, int amount)
    {
        cardButtonTexts[playerIndex].text = amount.ToString();
    }

    public void UpdateNumberTrackers(int currentNumber)
    {
        foreach (RectTransform rectTransform in numberTrackers)
        {
            TMP_Text t;
            if (rectTransform.TryGetComponent<TMP_Text>(out t))
            {
                switch (currentNumber)
                {
                    default:
                        t.text = currentNumber.ToString(); break;
                    case -1:
                        t.text = "-"; break;
                    case 1:
                        t.text = "A"; break;
                    case 11:
                        t.text = "J"; break;
                    case 12:
                        t.text = "Q"; break;
                    case 13:
                        t.text = "K"; break;   
                }                
            }
        }
    }

    public void SetCardButtonColor(int playerIndex, Color targetColor)
    {
        foreach(Image img in cardButtonImages)
        {
            img.color = Color.white;
        }

        cardButtonImages[playerIndex].color = targetColor;
    }

    public void ShowWinGameMessage(int playerIndex)
    {
        string winner = "Someone";
        switch (playerIndex)
        {
            case 0:
                winner = "Green"; break;
            case 1:
                winner = "Yellow"; break;
            case 2:
                winner = "Blue"; break;
            case 3:
                winner = "Red"; break;
        }
        
        foreach (RectTransform rectTransform in gameMessage)
        {
            TMP_Text t;
            if (rectTransform.TryGetComponent<TMP_Text>(out t))
            {
                t.text = "Player " + winner + " Wins!";
            }
        }
        gameMessage.gameObject.SetActive(true);
    }
}