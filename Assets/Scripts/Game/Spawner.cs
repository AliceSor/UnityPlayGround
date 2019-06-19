using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhotonView))]
public class Spawner : MonoBehaviour, IPunObservable
{
    [SerializeField] ControllerSO controllerSO;
    private int _currentPlace = 0;

    #region Unity
    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            controllerSO.InstantiatePlayer(0);
        }
        else
        {
            int index = GetIndex();
            if (index > 0)
            {
                controllerSO.InstantiatePlayer(index);
            }
        }
    }
    #endregion

    #region Photon
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //
    }
    #endregion

    private int GetIndex()
    {
        int index = -1;
        Player[] list = PhotonNetwork.PlayerList;

        for (int i = 1; i < list.Length; i++)
        {
            if (PhotonNetwork.LocalPlayer.UserId == list[i].UserId)
            {
                return i;
            }
        }

        return index;
    }
}
