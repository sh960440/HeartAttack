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

    private void Start()
    {
        gameUI = FindObjectOfType<GameUIController>();
        cardStack = FindObjectOfType<CardStack>();
        players = new List<Player>();
        currentPlayer = 0;
        currentNumber = 0;

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
            gameUI.UpdateCardButtonText(playerIndex, players[playerIndex].GetCardAmount());

            currentNumber++;
            if (currentNumber > 13) currentNumber = 1;
            
            currentPlayer++;
            if (currentPlayer > 3) currentPlayer = 0;
        }
    }

    public void SlapButtonPressed(int playerIndex)
    {
        gameUI.ShowSlapImage(playerIndex);

        if (currentNumber == cardStack.GetCardNumberOnTop())
        {
            Debug.Log("玩家" + playerIndex + "安全");
        }
        else
        {
            Debug.Log("玩家" + playerIndex + "輸了");
            players[playerIndex].CollectAllCardsOnTable(cardStack); // 輸家收下桌上所有的牌
            gameUI.UpdateCardButtonText(playerIndex, players[playerIndex].GetCardAmount()); // 更新輸家的卡牌數

            currentPlayer = playerIndex; // 從輸家開始下一回合
        }
    }
}
