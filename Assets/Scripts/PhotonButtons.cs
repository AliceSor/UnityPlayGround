using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhotonButtons : MonoBehaviour
{
    public InputField joinRoomInput, createRoomInput;

    public PhotonConnectionHandler pHandler;

    public void OnClickJoinRoom()
    {
        RoomOptions roomOptions;

        if (joinRoomInput.text.Length > 0)
        {
            roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 4;

            PhotonNetwork.JoinOrCreateRoom(joinRoomInput.text, roomOptions, TypedLobby.Default);
        }
    }

    public void OnClickCreateRoom()
    {
        if (createRoomInput.text.Length > 0)
            PhotonNetwork.CreateRoom(createRoomInput.text, new RoomOptions() { MaxPlayers = 4 }, null);
    }

    private void OnJoinedRoom()
    {
        Debug.Log("We are joined room!");

        //SceneManager.LoadScene(1);
        pHandler.GoToGameScene();
    }
}
