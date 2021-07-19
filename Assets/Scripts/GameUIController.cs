using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUIController : MonoBehaviour
{
    private RectTransform hands;
    [SerializeField] private TMP_Text[] cardButtonTexts;

    private void Awake()
    {
        hands = transform.Find("HandIcons").GetComponent<RectTransform>();
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
}