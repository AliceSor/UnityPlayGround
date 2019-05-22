using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnect : MonoBehaviour
{
    public string versionName = "0.1";

    public GameObject section1, section2, section3;
    
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);

        Debug.Log("Connecting to photon...");
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);

        Debug.Log("We are connected to photon master");
    }

    private void OnJoinedLobby()
    {
        section1.SetActive(false);
        section2.SetActive(true);
        Debug.Log("On joined lobby");
    }

    private void OnDisconnectedFromPhoton()
    {
        if (section1.activeSelf)
            section1.SetActive(false);
        if (section2.activeSelf)
            section2.SetActive(false);
        section3.SetActive(true);

        Debug.Log("Dis from photon services");
    }
}
