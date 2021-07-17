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

    void Start()
    {
        gameUI = FindObjectOfType<GameUIController>();
    }

    void Update()
    {

    }

    public void CardButtonPressed(int index)
    {
        Debug.Log((PlayerIndex)index + "出牌");
    }

    public void SlapButtonPressed(int index)
    {
        gameUI.ShowSlapImage(index);
        Debug.Log((PlayerIndex)index + "拍!!");
    }
}
