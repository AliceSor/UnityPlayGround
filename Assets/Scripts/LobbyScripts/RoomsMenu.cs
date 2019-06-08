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
    [SerializeField] PlayerListHolder playerListHolder;
    public UnityEvent enteredRoomEvent;


	public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("List updated " + roomList.Count);
        if (roomsHolderPanel != null)
            roomsHolderPanel.UpdateRooms(roomList);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (playerListHolder != null)
            playerListHolder.UpdatePlayerList(PhotonNetwork.PlayerList);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (playerListHolder != null)
            playerListHolder.UpdatePlayerList(PhotonNetwork.PlayerList);
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
        
        Debug.Log(PhotonNetwork.PlayerList[0].NickName);
        if (playerListHolder != null)
            playerListHolder.UpdatePlayerList(PhotonNetwork.PlayerList);
    }

    public void JoinLobbyOnClick()
    {
        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
    }

}//RoomsMenu
