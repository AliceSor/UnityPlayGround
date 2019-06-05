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
        RoomOptions roomOptions;

        roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        roomOptions.MaxPlayers = 10;
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }
}
