using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class PlayerName : MonoBehaviour
{
	[SerializeField] PlayerSO playerSO;

	private Text text;

	void OnEnable()
	{
		text = GetComponent<Text>();
		if (playerSO != null)
		{
			text.text = playerSO.playerName;
		}
		else
		{
			text.text = "";
		}
	}
}
