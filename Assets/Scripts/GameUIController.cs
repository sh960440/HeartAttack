using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    private RectTransform hands;

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
}