using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private CardStack cardStack;
    private GameUIController gameUI;
    private List<Player> players;
    private int currentPlayer;
    private int currentNumber;
    private bool isSlappable;

    private void Start()
    {
        gameUI = FindObjectOfType<GameUIController>();
        cardStack = FindObjectOfType<CardStack>();
        players = new List<Player>();
        currentPlayer = 0;
        currentNumber = 0;
        isSlappable = false;

        for (int i = 0; i < 4; i++)
        {
            players.Add(new Player(cardStack.DistributeCards()));
        }
    }

    public void CardButtonPressed(int playerIndex)
    {
        if (currentPlayer == playerIndex)
        {
            players[playerIndex].PlayCard(cardStack);

            currentNumber++;
            if (currentNumber > 13) currentNumber = 1;
            
            currentPlayer++;
            if (currentPlayer > 3) currentPlayer = 0;
        }
    }

    public void SlapButtonPressed(int index)
    {
        gameUI.ShowSlapImage(index);

        if (currentNumber == cardStack.GetCardNumberOnTop())
        {
            Debug.Log("玩家" + index + "安全");
        }
        else
        {
            Debug.Log("玩家" + index + "輸了");
        }
    }
}
