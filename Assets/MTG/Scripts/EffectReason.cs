using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Condition
{
    ENTERED_FROM_LIBRARY,
    CAST_FROM_LIBRARY,
}

public enum Trigger
{
    ON_CAST,
    ETB,
    ON_LEAVE_BATTLEFIELD,
    ON_CREATURE_DIE,
    ON_COMBAT_DAMAGE,
    ON_LOOSE_LIFE,
    ON_DRAW,
    ON_LOOK_IN_LIBRARY,
    ON_BECOMES_TAPPED,
    ON_BECOMES_UNTAPPED,
    ON_COUNTER_PLACED,
    ON_END_STEP,
    ON_COMBAT,
    ON_UNTAP,
    ON_UPKEEP,
    ON_BECOMES_LEGAL_TARGET
}

public enum Activated
{
    TAP,
    PAY_MANA,
    PAY_LIFE,
    SACRIFACE,
    DISCARD
}


