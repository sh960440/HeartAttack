using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Scriptable Object/New Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public int cardNumber;
}
