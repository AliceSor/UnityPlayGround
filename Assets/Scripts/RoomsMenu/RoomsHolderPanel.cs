using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsHolderPanel : MonoBehaviour
{
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
            rb.gameObject.SetActive(true);
        }
    }

    private void HideAll()
    {
        RoomButton[] roomButtons = holderPanel.GetComponentsInChildren<RoomButton>();
        if (roomButtons.Length > 0)
            for (int i = roomButtons.Length - 1; i >= 0; i--)
            {
                pool.ReturnObject(roomButtons[i]);
            }
    }

}
