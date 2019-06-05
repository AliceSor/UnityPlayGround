using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomButton : MonoBehaviour
{
    public string roomName;

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomName);
    }
}
