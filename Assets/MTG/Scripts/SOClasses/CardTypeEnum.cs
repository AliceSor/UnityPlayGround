using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Just Collection of all CardTypes
/// </summary>
[CreateAssetMenu(fileName = "CardTypeEnum", menuName = "Custom/MTG/CardTypeEnum")]
public class CardTypeEnum : ScriptableObject
{
    public CardType[] cardTypes;
}
