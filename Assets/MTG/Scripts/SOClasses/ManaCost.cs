using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ManaCost
{
    public int converted = 0;
    public int uncolored = 0;
    public ManaType[] manaTypes;

    public override string ToString()
    {
        string res = (uncolored > 0) ? uncolored.ToString() : "";
        if (manaTypes != null)
        {
            foreach (ManaType i in manaTypes)
                res += i.manaSymbol;
        }
        return res;
    }
}
