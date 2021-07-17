using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerIndex
{
    FirstPlayer,
    SecondPlayer,
    ThirdPlayer,
    FourthPlayer
}

public class GameHandler : MonoBehaviour
{
    GameUIController gameUI;
    CardStack cardStack;

    void Start()
    {
        gameUI = FindObjectOfType<GameUIController>();
        cardStack = FindObjectOfType<CardStack>();
    }

    void Update()
    {

    }

    public void CardButtonPressed(int index)
    {
        cardStack.SpawnCard();
        Debug.Log((PlayerIndex)index + "出牌");
    }

    public void SlapButtonPressed(int index)
    {
        gameUI.ShowSlapImage(index);
        Debug.Log((PlayerIndex)index + "拍!!");
    }
}
