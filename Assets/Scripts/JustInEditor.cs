using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script disable object in playmode
/// </summary>
public class JustInEditor : MonoBehaviour
{
	
	void Start()
	{
		gameObject.SetActive(false);
	}
}
