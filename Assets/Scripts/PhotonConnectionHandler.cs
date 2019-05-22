using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnectionHandler : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.transform);
    }

    public void GoToGameScene()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
