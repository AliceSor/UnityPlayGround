using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Custom/MTG/CardData")]
public class CardData : ScriptableObject
{
    public string cardName;
    public ManaCost manaCost;
    public Sprite sprite;
    public CardType type;
    [TextArea]
    public string abilityText;
    public Ability[] abilities;
    [TextArea]
    public string flavor;
    public Vector2 power_toughness;
    public int loyalty;
}
