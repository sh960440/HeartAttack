using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private CardStack cardStack;
    private GameUIController gameUI;
    private List<Player> players;
    private bool[] didPlayersSlap;
    private int currentPlayer;
    private int currentNumber;
    

    private void Start()
    {
        gameUI = FindObjectOfType<GameUIController>();
        cardStack = FindObjectOfType<CardStack>();
        players = new List<Player>();
        didPlayersSlap = new bool[] {false, false, false, false};

        currentPlayer = Random.Range(0, 4);
        gameUI.SetCardButtonColor(currentPlayer, new Color(0.5f, 1.0f, 1.0f));

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

            if (players[playerIndex].GetCardAmount() <= 0)
            {
                Debug.Log("玩家" + playerIndex + "沒牌了!");
            }

            currentNumber++;
            if (currentNumber > 13) currentNumber = 1;
            gameUI.UpdateNumberTrackers(currentNumber);
            
            currentPlayer++;
            if (currentPlayer > 3) currentPlayer = 0;
            gameUI.SetCardButtonColor(currentPlayer, new Color(0.5f, 1.0f, 1.0f));
        }
    }

    public void SlapButtonPressed(int playerIndex)
    {
        if (cardStack.cardsOnTable.Count <= 0) return; // 假如桌上沒有任何牌

        gameUI.ShowSlapImage(playerIndex);

        if (currentNumber == cardStack.GetCardNumberOnTop())
        {
            if (CheckHowManyPlayersSlapped() >= 2)
            {
                didPlayersSlap[playerIndex] = true;
                LoseThisTurn(GetSlowestPlayer());
            }
            else
            {
                didPlayersSlap[playerIndex] = true;
            }            
        }
        else
        {
            LoseThisTurn(playerIndex);
        }
    }

    private int CheckHowManyPlayersSlapped()
    {
        int count = 0;
        foreach (bool b in didPlayersSlap)
        {
            if (b) count++;
        }

        return count;
    }

    private int GetSlowestPlayer()
    {
        for (int i = 0; i < didPlayersSlap.Length; i++)
        {
            if (didPlayersSlap[i] == false) return i;
        }

        return -1;
    }

    private void LoseThisTurn(int playerIndex)
    {
        players[playerIndex].CollectAllCardsOnTable(cardStack); // 輸家收下桌上所有的牌
        gameUI.UpdateCardButtonText(playerIndex, players[playerIndex].GetCardAmount()); // 更新輸家的卡牌數
        gameUI.HideHands(); // 隱藏蓋下的手

        currentNumber = 0; // 重置數字
        currentPlayer = playerIndex; // 從輸家開始下一回合
        gameUI.SetCardButtonColor(currentPlayer, new Color(0.5f, 1.0f, 1.0f));

        for (int i = 0; i < didPlayersSlap.Length; i++) // 把didPlayersSlap全部設置為false
        {
            didPlayersSlap[i] = false;
        }

        gameUI.UpdateNumberTrackers(-1);
    }

    private void SetCurrentPlayer(int playerIndex)
    {

    }
}
