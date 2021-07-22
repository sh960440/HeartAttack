using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        SetCurrentPlayer(Random.Range(0, 4));

        currentNumber = 0;

        for (int i = 0; i < 4; i++)
        {
            players.Add(new Player(cardStack.DistributeCards()));
            //Debug.Log("玩家" + i + "有" + players[i].GetCardAmount() + "張卡");
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
            gameUI.UpdateNumberTrackers(currentNumber);
            
            AdvanceToNextPlayer();
            SetCurrentPlayer(currentPlayer);
        }
    }

    public void SlapButtonPressed(int playerIndex)
    {
        if (cardStack.GetCardAmountOnTable() <= 0) return; // 假如桌上沒有任何牌

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
                if (players[playerIndex].HasNoCards())
                {
                    WinThisGame(playerIndex);
                }
                else
                {
                    didPlayersSlap[playerIndex] = true;
                }
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
        gameUI.ShowLoseMessage(playerIndex, cardStack.GetCardAmountOnTable());
        players[playerIndex].CollectAllCardsOnTable(cardStack); // 輸家收下桌上所有的牌
        gameUI.UpdateCardButtonText(playerIndex, players[playerIndex].GetCardAmount()); // 更新輸家的卡牌數
        gameUI.HideHands(); // 隱藏蓋下的手

        currentNumber = 0; // 重置數字
        SetCurrentPlayer(playerIndex);

        for (int i = 0; i < didPlayersSlap.Length; i++) // 把didPlayersSlap全部設置為false
        {
            didPlayersSlap[i] = false;
        }

        gameUI.UpdateNumberTrackers(-1);
    }

    private void AdvanceToNextPlayer()
    {
        int tracker = 0;
        do {
            currentPlayer++;
            if (currentPlayer > 3) currentPlayer = 0;
            tracker++;
        } while (players[currentPlayer].HasNoCards() && tracker < 4);
    }

    private void WinThisGame(int playerIndex)
    {
        gameUI.ShowWinMessage(playerIndex);
    }

    private void SetCurrentPlayer(int playerIndex)
    {
        currentPlayer = playerIndex;
        gameUI.SetCardButtonColor(currentPlayer, new Color(0.5f, 1.0f, 1.0f));
    }

    public void Replay()
    {
        GameSettings.Reset();
        SceneManager.LoadScene("Menu");
    }
}
