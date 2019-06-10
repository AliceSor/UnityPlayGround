using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStart : MonoBehaviour
{
    public GameObject button;
	public void OnEnterRoom ()
    {
		if (!PhotonNetwork.IsMasterClient)
        {
            if (button != null)
                button.SetActive(false);
            Debug.Log("Not master client");
        }
	}

    public void OnMasterClientChanged(object obj)
    {
        Debug.Log("MasterClient Changed");
        if (button != null)
            button.SetActive(PhotonNetwork.IsMasterClient);
    }
	

}
