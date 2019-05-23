using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : Photon.MonoBehaviour
{
    public GameObject playerCam;
    public float moveSpeed = 100f;
    public float jumpForce = 800f;

    public bool devTest = false;

    private Vector3 selfPos;

    private GameObject sceneCam;

    void Awake()
    {
        if (!devTest && photonView.isMine)
        {
            sceneCam = GameObject.Find("Main Camera");
            sceneCam.SetActive(false);
            playerCam.SetActive(true);
        }
    }

    private void Update()
    {
        if (!devTest)
        {
            if (photonView.isMine)
            {
                CheckInput();
            }
            else
            {
                SmoothNetMovement();
            }
        }
        else
            CheckInput();
    }

    private void CheckInput()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0);

        transform.position += move * moveSpeed * Time.deltaTime;
    }

    private void SmoothNetMovement()
    {
        transform.position = Vector3.Lerp(transform.position, selfPos, Time.deltaTime * 8);
    }

    private void OnPhotonSerializeView(PhotonStream photonStream, PhotonMessageInfo info)
    {
        if (photonStream.isWriting)
        {
            photonStream.SendNext(transform.position);
        }
        else
        {
            selfPos = (Vector3)photonStream.ReceiveNext();
        }
    }
}
