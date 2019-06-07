using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoomsMenu : MonoBehaviourPunCallbacks, ILobbyCallbacks
{
	public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("List updated " + roomList.Count);
        if (roomList.Count > 0)
        {
            Debug.Log(roomList[0].Name);
        }
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

}//RoomsMenu
