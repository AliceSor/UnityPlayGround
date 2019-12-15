using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Part of sriptable enum CardTypeEnum
/// </summary>
[CreateAssetMenu(fileName = "CardType", menuName = "Custom/MTG/CardType")]
public class CardType : ScriptableObject
{
    public string typeName;
    public bool isPermanent;
    public bool nonland;
}
