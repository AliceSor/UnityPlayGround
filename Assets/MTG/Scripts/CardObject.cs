using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardObject : MonoBehaviour
{
    public CardData data;

    public TextMeshProUGUI cardName;
    public TextMeshProUGUI manaCost;
    public Image image;
    public TextMeshProUGUI cardType;
    public TextMeshProUGUI abilityAndFlawor;

    void Start()
    {
        if (data == null)
        {
            Debug.Log("No card data");
            return;
        }

        cardName.text = data.cardName;
        manaCost.text = data.manaCost.ToString();
        image.sprite = data.sprite;
        cardType.text = data.type.typeName;
        abilityAndFlawor.text = "<i>" + data.flawor + "</i>";
    }
}
