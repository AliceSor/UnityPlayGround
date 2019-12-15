using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class RoomButton : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text playerCountText;
    private string roomName;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(JoinRoom);
    }

    public void SetData(string name, string playerNumber)
    {
        roomName = name;
        nameText.text = name;
        playerCountText.text = playerNumber;
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(roomName);
    }
}
