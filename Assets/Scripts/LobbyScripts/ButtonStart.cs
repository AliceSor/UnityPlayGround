using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStart : MonoBehaviourPunCallbacks
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
        else
        {
            if (button != null)
                button.SetActive(PhotonNetwork.IsMasterClient);
        }
	}

    public override void OnJoinedRoom()
    {
        if (button != null)
            button.SetActive(PhotonNetwork.IsMasterClient);
    }


    public void OnMasterClientChanged(object obj)
    {
        Debug.Log("MasterClient Changed");
        if (button != null)
            button.SetActive(PhotonNetwork.IsMasterClient);
    }
	

}
