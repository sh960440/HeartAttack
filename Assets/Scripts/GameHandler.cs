using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    private CardStack cardStack;
    private GameUIController gameUI;
    private List<Player> players;
    private int currentPlayer;

    private void Start()
    {
        gameUI = FindObjectOfType<GameUIController>();
        cardStack = FindObjectOfType<CardStack>();
        players = new List<Player>();
        currentPlayer = 0;

        for (int i = 0; i < 4; i++)
        {
            players.Add(new Player(cardStack.DistributeCards()));
        }

        // for (int i = 0; i < 4; i++)
        // {
        //     for (int j = 0; j < 4; j++)
        //     {
        //         Debug.Log("玩家" + (i + 1).ToString() + "的第" + (j + 1).ToString() + "張卡片是" + players[i].cardsInHand[j].cardName);
        //     }
        // }
    }

    public void CardButtonPressed(int index)
    {
        if (currentPlayer == index)
        {
            cardStack.SpawnCard(players[currentPlayer].GetNextCardToPlay());
            
            currentPlayer++;
            if (currentPlayer > 3)
            {
                currentPlayer = 0;
            }
        }
        else
        {
            Debug.Log("不是你的回合");
        }
    }

    public void SlapButtonPressed(int index)
    {
        gameUI.ShowSlapImage(index);
    }
}
