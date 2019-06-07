using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsHolderPanel : MonoBehaviour
{
    [SerializeField] GameObject roomButtonPrefab;
    [SerializeField] Transform holderPanel;
    [SerializeField] RoomButtonPool pool;

    public void UpdateRooms(List<RoomInfo> roomList)
    {
        HideAll();
        foreach (RoomInfo i in roomList)
        {
            RoomButton rb = pool.Get();
            rb.transform.SetParent(holderPanel);
            rb.SetData(i.Name, i.PlayerCount.ToString());
        }
    }

    private void HideAll()
    {
        RoomButton[] roomButtons = holderPanel.GetComponentsInChildren<RoomButton>();
        for (int i = roomButtons.Length; i >= 0; i--)
        {
            pool.ReturnObject(roomButtons[i]);
        }
    }

}
