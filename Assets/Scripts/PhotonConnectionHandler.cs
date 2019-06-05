using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnectionHandler : MonoBehaviourPunCallbacks
{
    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {

        Debug.Log("We are connected to photon master");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Dis from photon services" + cause.ToString());
    }

    private void CreateRoom(string roomName)
    {
        RoomOptions roomOptions;

        roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        roomOptions.MaxPlayers = 10;
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }

}
