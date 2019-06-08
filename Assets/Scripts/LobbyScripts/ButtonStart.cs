using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStart : MonoBehaviour {

	void Start ()
    {
		if (!PhotonNetwork.IsMasterClient)
        {
            gameObject.SetActive(false);
        }
	}
	

}
