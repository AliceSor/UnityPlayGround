using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability
{
    public enum AbilityType { STATIC, ACTIVATED, TRIGGER }

    public string abilityName;
    public AbilityType type;

    public Trigger[] triggers;
    public bool allConditionMustBeMet = false;
    public Condition[] conditions;
    public Activated[] activateds;
    public Effect[] effects;
}
