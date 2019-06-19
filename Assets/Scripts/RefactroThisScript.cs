using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class RefactroThisScript : MonoBehaviour
{
	public string playerPrefabName;
	void Start ()
	{
		SpawnPlayer();
	}
	
	public void GetPosition()
	{
		
	}


	private void SpawnPlayer()
    {
        Debug.Log("SpawnPlayer " + playerPrefabName);
        PhotonNetwork.Instantiate(playerPrefabName, transform.position, transform.rotation, 0);
	}

}
