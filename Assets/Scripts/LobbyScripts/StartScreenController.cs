using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenController : MonoBehaviour
{
	[SerializeField] PersistentDataHandler persistentDataHandler;
	[SerializeField] GameObject noNamePanel;
	[SerializeField] GameObject haveNamePanel;

	void Start()
	{
		if (persistentDataHandler != null && noNamePanel != null && haveNamePanel != null)
		{
			if (persistentDataHandler.isFirstApplicationLauch)
			{
				noNamePanel.SetActive(true);
				haveNamePanel.SetActive(false);
			}
			else
			{
				haveNamePanel.SetActive(true);
				noNamePanel.SetActive(false);
			}
		}
		else
		{
			if (noNamePanel != null)
				noNamePanel.SetActive(true);
		}
	}
}
