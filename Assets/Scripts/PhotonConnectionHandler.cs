﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhotonConnectionHandler : MonoBehaviourPunCallbacks
{
    public UnityEvent connectedToPhotonEvent;
    public UnityEventTObj onMasterClientSwitched;

    [SerializeField] ModelSO model;

    public void OnPhotonInstantiate(PhotonMessageInfo info)
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        //PhotonNetwork.ConnectUsingSettings();
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnConnectedToMaster()
    {
        if (model != null)
            PhotonNetwork.NickName = model.playerSO.playerName;
        Debug.Log("We are connected to photon master");
        if (connectedToPhotonEvent != null)
            connectedToPhotonEvent.Invoke();
       // PhotonNetwork.JoinLobby();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log(message);
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined lobby");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Dis from photon services" + cause.ToString());
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room");
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        if (onMasterClientSwitched != null)
            onMasterClientSwitched.Invoke(new GameObject());
    }

}
