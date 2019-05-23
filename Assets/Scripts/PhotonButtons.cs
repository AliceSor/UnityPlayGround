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
        pHandler.JoinRoom(joinRoomInput.text);
    }

    public void OnClickCreateRoom()
    {
        pHandler.CreateNewRoom(createRoomInput.text);
    }

    
}
