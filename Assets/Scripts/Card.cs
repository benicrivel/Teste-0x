using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]

public class Card : ScriptableObject
{
    public int cost;
    public string cardName;
    public int attack;
    public int defense;
    public string effect;
    public Sprite art;    
}
