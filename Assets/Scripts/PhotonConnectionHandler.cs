using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotonConnectionHandler : MonoBehaviour
{
    public GameObject mainPlayer;

    private void Awake()
    {
        DontDestroyOnLoad(this.transform);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }


    public void GoToGameScene()
    {
        Debug.Log("GoToGameScene");
        PhotonNetwork.LoadLevel("GameScene");
    }

    public void CreateNewRoom(string roomName)
    {
        if (roomName.Length > 0)
            PhotonNetwork.CreateRoom(roomName, new RoomOptions() { MaxPlayers = 4 }, null);
    }

    public void JoinRoom(string roomName)
    {
        RoomOptions roomOptions;

        if (roomName.Length > 0)
        {
            roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 4;

            PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
        }
    }

    private void OnJoinedRoom()
    {
        Debug.Log("We are joined room!");

        //SceneManager.LoadScene(1);
        GoToGameScene();
    }

    public void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneFinishedLoading");
        if (scene.name == "GameScene")
        {
            SpawnPlayer();
        }
    }

    private void SpawnPlayer()
    {
        Debug.Log("SpawnPlayer " + mainPlayer.name);
        PhotonNetwork.Instantiate(mainPlayer.name, mainPlayer.transform.position, mainPlayer.transform.rotation, 0);
    }
}
