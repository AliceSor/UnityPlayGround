using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerButton : MonoBehaviour
{
    [SerializeField] Text nameText;

    public void SetData(string name)
    {
        nameText.text = name;
    }
}
