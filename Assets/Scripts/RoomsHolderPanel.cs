using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomsHolderPanel : MonoBehaviourPunCallbacks
{
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("List updated");
    }

    public void CreateRoom(TextMeshProUGUI textField)
    {
        RoomOptions roomOptions;

        roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        roomOptions.MaxPlayers = 10;
        PhotonNetwork.CreateRoom(textField.text, roomOptions);

        Debug.Log("Attemp to create room " + textField.text);
    }

}
