using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class RoomsMenu : MonoBehaviourPunCallbacks, ILobbyCallbacks
{
    [SerializeField] RoomsHolderPanel roomsHolderPanel;
    public UnityEvent enteredRoomEvent;


	public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("List updated " + roomList.Count);
        if (roomsHolderPanel != null)
            roomsHolderPanel.UpdateRooms(roomList);
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

    public override void OnJoinedRoom()
    {
        if (enteredRoomEvent != null)
            enteredRoomEvent.Invoke();
        PhotonNetwork.NickName = "Alice";
        Debug.Log(PhotonNetwork.PlayerList[0].NickName);
    }

    public void JoinLobbyOnClick()
    {
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }

}//RoomsMenu
