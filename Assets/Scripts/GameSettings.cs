using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings
{
    public static int playerAmount = 2;
    public static int cardAmount = 52;
    public static bool hasNumberTracker = true;
    public static bool isEnglishUI = true;

    public static void Reset()
    {
        playerAmount = 2;
        cardAmount = 52;
        hasNumberTracker = true;
        isEnglishUI = true;
    }
}
