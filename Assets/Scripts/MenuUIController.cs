using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUIController : MonoBehaviour
{
    RectTransform playerAmountPanel;
    RectTransform cardAmountPanel;
    RectTransform numberTrackerPanel;
    RectTransform languagePanel;
    
    void Awake()
    {
        playerAmountPanel = transform.Find("PlayerAmount").GetComponent<RectTransform>();
        cardAmountPanel = transform.Find("CardAmount").GetComponent<RectTransform>();
        numberTrackerPanel = transform.Find("NumberTracker").GetComponent<RectTransform>();
        languagePanel = transform.Find("Language").GetComponent<RectTransform>();
    }

    // void Start()
    // {
    //     SwapButtonTransparency(playerAmountPanel);
    //     SwapButtonTransparency(cardAmountPanel);
    //     SwapButtonTransparency(numberTrackerPanel);
    //     SwapButtonTransparency(languagePanel);
    // }

    public void SetPlayerAmount(int playerAmount)
    {
        if (GameSettings.playerAmount == playerAmount) return;
        GameSettings.playerAmount = playerAmount;
        SwapButtonTransparency(playerAmountPanel);
    }

    public void SetCardAmount(int cardAmount)
    {
        if (GameSettings.cardAmount == cardAmount) return;
        GameSettings.cardAmount = cardAmount;
        SwapButtonTransparency(cardAmountPanel);
    }

    public void SetNumberTrackerVisiablity(bool isVisiable)
    {
        if (GameSettings.hasNumberTracker == isVisiable) return;
        GameSettings.hasNumberTracker = isVisiable;
        SwapButtonTransparency(numberTrackerPanel);
    }

    public void SetLanguage(bool isEnglish)
    {
        if (GameSettings.isEnglishUI == isEnglish) return;
        GameSettings.isEnglishUI = isEnglish;
        SwapButtonTransparency(languagePanel);
    }

    private void SwapButtonTransparency(RectTransform panel)
    {
        Button[] buttons = panel.GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            if (button.gameObject.GetComponent<Image>().color.a < 1)
            {
                button.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            else
            {
                button.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.4f);
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
