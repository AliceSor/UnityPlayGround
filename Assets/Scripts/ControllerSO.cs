#define PERSISTENT_DATA_HANDLER
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu()]
public class ControllerSO : ScriptableObject
{
    public ModelSO model;

#if PERSISTENT_DATA_HANDLER
    public PersistentDataHandler persistentDataHandler;
#endif

    public UnityEventTObj playerGOcreatedEvent;

    public void ConnectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void SetPlayerName(string newName)
    {
        model.playerSO.playerName = newName;
        PhotonNetwork.NickName = newName;
#if PERSISTENT_DATA_HANDLER
        persistentDataHandler.persistentData.userName = newName;
#endif
    }

    public void InstantiatePlayer(int pointIndex)
    {
        if (model.spawnPoints.Length <= 0 || model.spawnPoints.Length <= pointIndex)
            return;
        model.player = PhotonNetwork.Instantiate(model.playerPrefab.name, model.spawnPoints[pointIndex].position, model.spawnPoints[pointIndex].rotation);
        playerGOcreatedEvent.Invoke(model.player);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadScenePhoton(int index)
    {
        PhotonNetwork.LoadLevel(index);
    }

public void CloseApp()
    {
#if PERSISTENT_DATA_HANDLER
        if (persistentDataHandler != null)
            persistentDataHandler.SaveProgres();
#endif
        Application.Quit();
    }
}
