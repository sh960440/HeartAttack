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

    public void ShowSlapImage(int index) // TODO: 可以考慮簡化
    {
        switch (index)
        {
            case 0:
                hands.Find("Player_1_Hand").gameObject.SetActive(true);
                hands.Find("Player_1_Hand").SetAsLastSibling();
                break;
            case 1:
                hands.Find("Player_2_Hand").gameObject.SetActive(true);
                hands.Find("Player_2_Hand").SetAsLastSibling();
                break;
            case 2:
                hands.Find("Player_3_Hand").gameObject.SetActive(true);
                hands.Find("Player_3_Hand").SetAsLastSibling();
                break;
            case 3:
                hands.Find("Player_4_Hand").gameObject.SetActive(true);
                hands.Find("Player_4_Hand").SetAsLastSibling();
                break;
        }
    }

    public void HideHands()
    {
        foreach(RectTransform hand in hands)
        {
            hand.gameObject.SetActive(false);
        }
    }
}
