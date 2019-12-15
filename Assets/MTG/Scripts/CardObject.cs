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
    public TextMeshProUGUI abilityAndFlavor;
    public TextMeshProUGUI powerAndToughness;

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
        abilityAndFlavor.text = data.abilityText;
        //if (data.flavor.Length > 0)
        //{
        //    if (data.abilityText.Length > 0)
        //        abilityAndFlavor.text += "<br><br>";
        //    abilityAndFlavor.text  += "<i>" + data.flavor + "</i>";
        //}
        if (data.type.typeName == "Creature")
        {
            powerAndToughness.text = data.power_toughness.x.ToString() + "/" + data.power_toughness.y.ToString();
        }
        else if (data.type.typeName == "Planswalker")
        {
            powerAndToughness.text = data.loyalty.ToString();
        }
    }
}
