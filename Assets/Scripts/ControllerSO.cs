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

    public void ConnectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void SetPlayerName(string newName)
    {
        model.playerSO.playerName = newName;
#if PERSISTENT_DATA_HANDLER
        persistentDataHandler.persistentData.userName = newName;
#endif
    }

    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
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
