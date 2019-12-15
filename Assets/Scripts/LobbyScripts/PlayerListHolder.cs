using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListHolder : MonoBehaviour
{
    [SerializeField] Transform holderPanel;
    [SerializeField] PlayerButtonPool pool;

    public void UpdatePlayerList(Player[] playerList)
    {
        HideAll();
        foreach (Player i in playerList)
        {
            PlayerButton rb = pool.Get();
            rb.transform.SetParent(holderPanel);
            rb.SetData(i.NickName);
            rb.gameObject.SetActive(true);
        }
    }

    private void HideAll()
    {
        PlayerButton[] roomButtons = holderPanel.GetComponentsInChildren<PlayerButton>();
        if (roomButtons.Length > 0)
            for (int i = roomButtons.Length - 1; i >= 0; i--)
            {
                pool.ReturnObject(roomButtons[i]);
            }
    }
}
