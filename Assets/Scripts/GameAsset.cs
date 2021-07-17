using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAsset : MonoBehaviour
{
    private static GameAsset _instance;

    public static GameAsset Instance 
    {
        get
        {
            if (_instance == null) _instance = (Instantiate(Resources.Load("GameAsset")) as GameObject).GetComponent<GameAsset>();
            return _instance;
        }
    }

    public GameObject cardTemplate;

    public Sprite[] clubs;
    public Sprite[] diamonds;
    public Sprite[] hearts;
    public Sprite[] spades;
}